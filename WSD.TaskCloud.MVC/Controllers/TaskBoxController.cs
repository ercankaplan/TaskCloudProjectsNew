
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSD.TaskCloud.Contracts.DataContracts;
using WSD.TaskCloud.Contracts.DataContracts.Task;
using WSD.TaskCloud.Contracts.DataContracts.TaskBox;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.MVC.ClientContracts;
using WSD.TaskCloud.MVC.HelperClasses;
using WSD.TaskCloud.MVC.Models;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.xml;
using iTextSharp.text.io;
using iTextSharp.text.xml.simpleparser;
using iTextSharp.text.html.simpleparser;

namespace WSD.TaskCloud.MVC.Controllers
{
    public class TaskBoxController : BaseController
    {
        // GET: TaskBox
        public ActionResult Index()
        {
            //List<TaskType> list = new List<TaskType>();
            //TaskType t = new TaskType() { Name = "Compose" };
            //list.Add(t);

            //CacheHelper.GetCacheItem<TaskType>().ForEach(p => { t.SubTypes.Add(p); });
            List<TaskBoxMenuItem> list = TaskBoxServiceProxy.GetTaskStatusByUser(CurrentUser.UserID, CurrentUser.UserRoleID, EnumTaskGroup.Income);

            @ViewData["TaskBoxMenuItems"] = list;
            return View();
        }

        public ActionResult Inbox(byte typeID)
        {
            TaskRequestFilter request = new TaskRequestFilter()
            {
                UserID = CurrentUser.UserID,
                UserRoleID = CurrentUser.UserRoleID,
                Optime = DateTime.Today.AddYears(-1),
                TaskTypeID = typeID
            };

            Session["TaskRequestFilter"] = request;
            return PartialView();

        }

        public ActionResult _GetCurrentUserTask_Read([DataSourceRequest] DataSourceRequest request)
        {


            TaskRequestFilter filter = Session["TaskRequestFilter"] as TaskRequestFilter;
            if (filter == null)
            {
                filter = new TaskRequestFilter()
                {
                    UserID = CurrentUser.UserID,
                    UserRoleID = CurrentUser.UserRoleID,
                    Optime = DateTime.Today.AddYears(-1)
                };
            }

            List<TaskRequest> tts = TaskBoxServiceProxy.GetTaskRequestByUser(filter).OrderByDescending(o => o.Optime).ToList();

            Session["InboxTaskRequest"] = tts;



            return Json(tts.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        public ActionResult Compose(byte gorevTipi)
        {
            Session[SessionKeys.AtanacakKullanicilar] = null;

            TaskRequestModel request = new TaskRequestModel()
            {

                StartDate = DateTime.Today,
                Deadline = DateTime.Today,
                BaseTaskTypeID = gorevTipi,
                TaskTypeID = gorevTipi //alt talep türü yok ise kendisi olacak
              
                

            };

            //if (gorevTipi == (byte)EnumTaskTypes.PersonelBilgiTalebi)
            return PartialView("PersonelBilgiTalebi", request);

           // return View(request);

        }

        public ActionResult PersonelBilgiTalebi()
        {

            Session[SessionKeys.AtanacakKullanicilar] = null;
            Session[SessionKeys.EklenenDosyalar] = null;
            Session[SessionKeys.EklenenReferanslar] = null;

            return View();
        }




        public JsonResult _GetTaskTypes()
        {
            List<TaskType> selectList = CacheHelper.GetCacheItem<TaskType>();
            return Json(selectList, JsonRequestBehavior.AllowGet);

        }

        public JsonResult _GetResultTypes()
        {
            List<ResultType> selectList = CacheHelper.GetCacheItem<ResultType>();
            return Json(selectList, JsonRequestBehavior.AllowGet);

        }

        

        public JsonResult _GetPriority()
        {
            List<PriorityType> selectList = CacheHelper.GetCacheItem<PriorityType>();
            return Json(selectList, JsonRequestBehavior.AllowGet);

        }

        public JsonResult _GetTaskByID()
        {
            List<TaskBy> selectList = CacheHelper.GetCacheItem<TaskBy>();
            return Json(selectList, JsonRequestBehavior.AllowGet);

        }
        

        public JsonResult _GetPrivacy()
        {
            List<PrivacyType> selectList = CacheHelper.GetCacheItem<PrivacyType>();
            return Json(selectList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TaskDetail(Guid taskID)
        {
            TaskRequest tskRequest = null;

            List<TaskRequest> tts = Session["InboxTaskRequest"] as List<TaskRequest>;
            if (tts != null)
                tskRequest = tts.Where(x => x.TaskID == taskID).SingleOrDefault();

            tskRequest.Task = TaskBoxServiceProxy.GetTaskDetailByTaskRequestID(tskRequest.TaskRequestID, CurrentUser.UserID, CurrentUser.UserRoleID);

            Session[SessionKeys.CurrentTaskRequest] = tskRequest;

            return PartialView(tskRequest);
        }

        public void GetAttachmentByID(Guid ID)
        {
            Attachment aFile = TaskBoxServiceProxy.GetAttachmentByID(ID);
            Response.Clear();
            FileEncDec Decryptor = new FileEncDec();
            Response.ContentType = string.Format("application/{0}", aFile.Extend);
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", aFile.Name));
            Response.Buffer = true;
            Decryptor.DecryptFileV2(aFile.FilePath, Response.OutputStream);
            Response.End();
        }

        public ActionResult ResponseView(Guid taskRequestID)
        {

            TaskRequest tReq = Session[SessionKeys.CurrentTaskRequest] as TaskRequest;

            TaskResponseModel request = new TaskResponseModel()
            {
                TaskRequestID = taskRequestID,
                Subject = tReq != null ? tReq.Task.Subject : string.Empty,


            };
            return PartialView(request);
        }

       
       

        public ActionResult ResponseDetail(Guid taskResponseID)
        {
            TaskResponse response = TaskBoxServiceProxy.GetTaskResponseDetailByID(taskResponseID, CurrentUser.UserID, CurrentUser.UserRoleID);
            return PartialView(response);

        }

        public ActionResult AttachFile(IEnumerable<HttpPostedFileBase> files)
        {
            if (files == null)
                return Content("alert('dosya alınamadı')");

            TempData["UploadedFiles"] = GetFileInfo(files);

            List<AttachedFile> eklenenDosyalar = Session[SessionKeys.EklenenCevapDosyalari] as List<AttachedFile>;

            if (eklenenDosyalar == null)
                eklenenDosyalar = new List<AttachedFile>();

            foreach (HttpPostedFileBase file in files)
            {
                if (file != null)
                {
                    if (file.ContentLength <= 0)
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                        List<string> errors = new List<string>();

                        errors.Add("boş dosya");

                        return Json(errors);

                    }
                    // extract only the filename
                    var fileName = Path.GetFileName(file.FileName);


                    string tmpFilePath = Path.GetTempFileName();

                    AttachedFile aFile = new AttachedFile()
                    {
                        FileName = fileName,
                        TempFileName = tmpFilePath,
                        Extend = Path.GetExtension(file.FileName),
                        ContentType = file.ContentType,
                        Size = file.ContentLength

                    };
                    eklenenDosyalar.Add(aFile);



                    FileEncDec oFileEncoder = new FileEncDec();
                    oFileEncoder.EncryptFileV2(file.InputStream, tmpFilePath);

                    // file.SaveAs(tmpFileName);
                }

            }

            Session[SessionKeys.EklenenCevapDosyalari] = eklenenDosyalar;

            return Content(string.Empty);
        }

        public ActionResult RemoveFile(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"
            List<AttachedFile> eklenenDosyalar = Session[SessionKeys.EklenenCevapDosyalari] as List<AttachedFile>;

            if (fileNames != null && eklenenDosyalar != null)
            {


                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);

                    AttachedFile aFile = eklenenDosyalar.Where(f => f.FileName == fileName).Single();

                    eklenenDosyalar.Remove(aFile);


                    //var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    // TODO: Verify user permissions

                    if (System.IO.File.Exists(aFile.TempFileName))
                    {
                        // The files are not actually removed in this demo
                        System.IO.File.Delete(aFile.TempFileName);
                    }
                }
            }

            /* string filePath = Server.MapPath("APP_DATA/TestDoc.docx");
            string filename = Path.GetFileName(filePath);

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            br.Close();
            fs.Close();*/
            // Return an empty string to signify success
            return Content("");
        }

        private IEnumerable<string> GetFileInfo(IEnumerable<HttpPostedFileBase> files)
        {
            return
                from a in files
                where a != null
                select string.Format("{0} ({1} bytes)", Path.GetFileName(a.FileName), a.ContentLength);
        }



        public ActionResult SaveTaskResponse(TaskResponseModel model)
        {
            model.CurrentUserName = CurrentUser.User.UserName;
            model.UserID = CurrentUser.UserID;
            model.UserRoleID = CurrentUser.User.UserRoleData.UserRoleID;
            model.ResponseDescription = Server.HtmlDecode(model.ResponseDescription);
            model.ResponseAttachedFiles = Session[SessionKeys.EklenenCevapDosyalari] as List<AttachedFile>;

            TaskServiceProxy.SaveTaskRespose(model);
            Session[SessionKeys.EklenenCevapDosyalari] = null;
            return Content(string.Format("<script>ShowMessage('{0}','{1}');</script>", "Cevap Gönderildi !", (byte)ClientContracts.EnumMessageType.Info));

        }

        public ActionResult PDFPopUp(Guid taskRequestID)
        {
            TaskRequest tskRequest = null;

            List<TaskRequest> tts = Session["InboxTaskRequest"] as List<TaskRequest>;
            if (tts != null)
                tskRequest = tts.Where(x => x.TaskRequestID == taskRequestID).SingleOrDefault();

            tskRequest.Task = TaskBoxServiceProxy.GetTaskDetailByTaskRequestID(tskRequest.TaskRequestID, CurrentUser.UserID, CurrentUser.UserRoleID);

           

            return PartialView(tskRequest);
           // return pdf(tskRequest.Task.Description);

            
           
        }

        public FileStreamResult GetSignImgFile(Guid taskRequestID)
        {
            TaskRequest tskRequest = null;
            List<TaskRequest> tts = Session["InboxTaskRequest"] as List<TaskRequest>;
            if (tts != null)
                tskRequest = tts.Where(x => x.TaskRequestID == taskRequestID).SingleOrDefault();

            if (tskRequest.Task.Users.SignImg == null)
                tskRequest.Task.Users.SignImg = new byte[0];

            MemoryStream workStream = new MemoryStream();

            workStream.Write(tskRequest.Task.Users.SignImg, 0, tskRequest.Task.Users.SignImg.Length);
            workStream.Position = 0;

            return new FileStreamResult(workStream, "image/png");
        }

        public FileStreamResult pdf(string htmlContent)
        {
           


            //Create a byte array that will eventually hold our final PDF
            Byte[] bytes;

            //Boilerplate iTextSharp setup here
            //Create a stream that we can write to, in this case a MemoryStream
            using (var ms = new MemoryStream())
            {

                //Create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF
                using (var doc = new Document())
                {

                    //Create a writer that's bound to our PDF abstraction and our stream
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {

                        //Open the document for writing
                        doc.Open();

                        //Our sample HTML and CSS
                        //var example_html = @"<p>This <em>is </em><span class=""headline"" style=""text-decoration: underline;"">some</span> <strong>sample <em> text</em></strong><span style=""color: red;"">!!!</span></p>";
                        var example_css = @".headline{font-size:200%}";

                        /**************************************************
                         * Example #1                                     *
                         *                                                *
                         * Use the built-in HTMLWorker to parse the HTML. *
                         * Only inline CSS is supported.                  *
                         * ************************************************/

                        //Create a new HTMLWorker bound to our document
                        //using (var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(doc))
                        //{

                        //    //HTMLWorker doesn't read a string directly but instead needs a TextReader (which StringReader subclasses)
                        //    using (var sr = new StringReader(example_html))
                        //    {

                        //        //Parse the HTML
                        //        htmlWorker.Parse(sr);
                        //    }
                        //}

                        /**************************************************
                         * Example #2                                     *
                         *                                                *
                         * Use the XMLWorker to parse the HTML.           *
                         * Only inline CSS and absolutely linked          *
                         * CSS is supported                               *
                         * ************************************************/

                        //XMLWorker also reads from a TextReader and not directly from a string

                       
                        using (var srHtml = new StringReader(htmlContent))
                        {

                            //Parse the HTML
                            iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, srHtml);
                        }

                        /**************************************************
                         * Example #3                                     *
                         *                                                *
                         * Use the XMLWorker to parse HTML and CSS        *
                         * ************************************************/

                        //In order to read CSS as a string we need to switch to a different constructor
                        //that takes Streams instead of TextReaders.
                        //Below we convert the strings into UTF8 byte array and wrap those in MemoryStreams
                        //using (var msCss = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_css)))
                        //{
                        //    using (var msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(htmlContent)))
                        //    {

                        //        //Parse the HTML
                        //        iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msHtml, msCss);
                        //    }
                        //}


                        doc.Close();
                    }
                }

                //After all of the PDF "stuff" above is done and closed but **before** we
                //close the MemoryStream, grab all of the active bytes from the stream
                bytes = ms.ToArray();
            }

            //Now we just need to do something with those bytes.
            //Here I'm writing them to disk but if you were in ASP.Net you might Response.BinaryWrite() them.
            //You could also write the bytes to a database in a varbinary() column (but please don't) or you
            //could pass them to another function for further PDF processing.

            //var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");
            //System.IO.File.WriteAllBytes(testFile, bytes);

            MemoryStream workStream = new MemoryStream();
            //Document document = new Document();
            //PdfWriter.GetInstance(document, workStream).CloseStream = false;

            //document.Open();
            //document.Add(new Paragraph("Hello World"));
            //document.Add(new Paragraph(DateTime.Now.ToString()));
            //document.Close();

           
            workStream.Write(bytes, 0, bytes.Length);
            workStream.Position = 0;

            return new FileStreamResult(workStream, "application/pdf");
        }


        public ActionResult ForwardView(Guid taskRequestID)
        {
            Session[SessionKeys.EklenenForwardDosyalari] = null;
            Session[SessionKeys.IletilecekKullanicilar] = null;

            TaskRequest tReq = Session[SessionKeys.CurrentTaskRequest] as TaskRequest;

            TaskForwardModel request = new TaskForwardModel()
            {
                TaskRequestID = taskRequestID,
                Subject = tReq != null ? tReq.Task.Subject : string.Empty,


            };
            return PartialView(request);

        }

        public ActionResult AttachFileForward(IEnumerable<HttpPostedFileBase> files)
        {
            if (files == null)
                return Content("alert('dosya alınamadı')");

            TempData["UploadedFiles"] = GetFileInfo(files);

            List<AttachedFile> eklenenDosyalar = Session[SessionKeys.EklenenForwardDosyalari] as List<AttachedFile>;

            if (eklenenDosyalar == null)
                eklenenDosyalar = new List<AttachedFile>();

            foreach (HttpPostedFileBase file in files)
            {
                if (file != null)
                {
                    if (file.ContentLength <= 0)
                    {
                        Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                        List<string> errors = new List<string>();

                        errors.Add("boş dosya");

                        return Json(errors);

                    }
                    // extract only the filename
                    var fileName = Path.GetFileName(file.FileName);


                    string tmpFilePath = Path.GetTempFileName();

                    AttachedFile aFile = new AttachedFile()
                    {
                        FileName = fileName,
                        TempFileName = tmpFilePath,
                        Extend = Path.GetExtension(file.FileName),
                        ContentType = file.ContentType,
                        Size = file.ContentLength

                    };
                    eklenenDosyalar.Add(aFile);



                    FileEncDec oFileEncoder = new FileEncDec();
                    oFileEncoder.EncryptFileV2(file.InputStream, tmpFilePath);

                    // file.SaveAs(tmpFileName);
                }

            }

            Session[SessionKeys.EklenenForwardDosyalari] = eklenenDosyalar;

            return Content(string.Empty);
        }

        public ActionResult RemoveFileForward(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"
            List<AttachedFile> eklenenDosyalar = Session[SessionKeys.EklenenForwardDosyalari] as List<AttachedFile>;

            if (fileNames != null && eklenenDosyalar != null)
            {


                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);

                    AttachedFile aFile = eklenenDosyalar.Where(f => f.FileName == fileName).Single();

                    eklenenDosyalar.Remove(aFile);


                    //var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    // TODO: Verify user permissions

                    if (System.IO.File.Exists(aFile.TempFileName))
                    {
                        // The files are not actually removed in this demo
                        System.IO.File.Delete(aFile.TempFileName);
                    }
                }
            }

            /* string filePath = Server.MapPath("APP_DATA/TestDoc.docx");
            string filename = Path.GetFileName(filePath);

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            br.Close();
            fs.Close();*/
            // Return an empty string to signify success
            return Content("");
        }

        
        [HttpPost]
        public ActionResult AddAssignedForwardUsers(int id, bool isChecked)
        {
            List<NodeViewModel> source = Session[SessionKeys.IletilecekKullanicilar] as List<NodeViewModel>;

            

            Handy.SetNode(null, source[0], id, isChecked);

            return Content(string.Empty);
        }

        public ActionResult SaveForwardTask(TaskForwardModel model)
        {
            model.CurrentUserName = CurrentUser.User.UserName;
            model.UserID = CurrentUser.UserID;
            model.UserRoleID = CurrentUser.User.UserRoleData.UserRoleID;
            model.TaskDescription = Server.HtmlDecode(model.TaskDescription);
            model.ForwardAttachedFiles = Session[SessionKeys.EklenenForwardDosyalari] as List<AttachedFile>;
           

            List<NodeViewModel> selectedNodes = new List<NodeViewModel>();
            List<NodeViewModel> source = Session[SessionKeys.IletilecekKullanicilar] as List<NodeViewModel>;
            if (source != null)
            {
                Handy.GetSelectedNodes(selectedNodes, source[0]);

                model.AtananKullanicilar = selectedNodes.Select(x => x.Id).ToList();
            }

            if (model.AtananKullanicilar.Count <= 0)
                throw new ApplicationException("İleticelecek kullanıcı yok");

            TaskServiceProxy.SaveForwardTask(model);
            Session[SessionKeys.EklenenForwardDosyalari] = null;
            return Content(string.Format("<script>ShowMessage('{0}','{1}');</script>", "Cevap Gönderildi !", (byte)ClientContracts.EnumMessageType.Info));

        }

        public ActionResult MyTask()
        {
            Session[SessionKeys.MyTask] = DashboardServiceProxy.GetTaskList(new Contracts.DataContracts.Dashboard.DashboardTaskFilter()
            {
                UserID = CurrentUser.UserID,
                UserRoleID = CurrentUser.UserRoleID,
                TaskTypeID = 0,
                Optime = DateTime.Today.AddYears(-1)

            });

            return View();

        }

        public ActionResult MyTask_Read([DataSourceRequest] DataSourceRequest request)
        {
            List<Task> referanslar = Session[SessionKeys.MyTask] as List<Task>;

            if (referanslar == null)
            {
                referanslar = new List<Task>();
                Session[SessionKeys.MyTask] = referanslar;
            }

            return Json(referanslar.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        

    }
}