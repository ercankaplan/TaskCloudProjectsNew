using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSD.TaskCloud.Contracts.DataContracts;
using WSD.TaskCloud.Contracts.DataContracts.Personel;
using WSD.TaskCloud.Contracts.DataContracts.Task;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.MVC.ClientContracts;
using WSD.TaskCloud.MVC.HelperClasses;
using WSD.TaskCloud.MVC.Models;

namespace WSD.TaskCloud.MVC.Controllers
{
    public class TaskController : BaseController
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();

        }



        public JsonResult _GetTitles()
        {
            List<Title> selectList = CacheHelper.GetCacheItem<Title>();
            return Json(selectList, JsonRequestBehavior.AllowGet);

        }

        public JsonResult _GetUserTemplate(int typeid)
        {
            List<TaskTemplate> selectList = TaskServiceProxy.GetUserTemplate(CurrentUser.UserID, typeid);
            Session[SessionKeys.CurrentUserTemplates] = selectList;
            return Json(selectList, JsonRequestBehavior.AllowGet);

        }

        public string GetTemplate(int tmpID)
        {

            List<TaskTemplate> selectList = Session[SessionKeys.CurrentUserTemplates] as List<TaskTemplate>;
            if (selectList == null)
                return string.Empty;
            else
            {

                TaskTemplate tmp = selectList.Where(x => x.TaskTemplateID == tmpID).SingleOrDefault();

                if (tmp == null)
                    return string.Empty;
                else
                    return tmp.DraftData;

            }

            return string.Empty;

        }


        public JsonResult _GetDepartments()
        {
            List<Department> selectList = CacheHelper.GetCacheItem<Department>();
            return Json(selectList, JsonRequestBehavior.AllowGet);

        }

        public JsonResult _GetPersonnel(string sicilNo)
        {
            Personnel p = TaskServiceProxy.GetPersonnelBySicilNo(sicilNo);
            if (p != null)
                return Json(p, JsonRequestBehavior.AllowGet);
            else
                return Json(string.Empty);

        }

        public JsonResult _GetSubTaskTypes(byte? baseTypeID)
        {
            List<TaskType> result = new List<TaskType>();

            if (baseTypeID != null)
            {
                result = CacheHelper.GetCacheItem<TaskType>().Where(x => x.UpperTaskTypeID == baseTypeID).ToList();

                if (result.Count <= 0)
                    result = CacheHelper.GetCacheItem<TaskType>().Where(x => x.TaskTypeID == baseTypeID).ToList();
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult _GetReferences()
        {
            List<Reference> list = TaskServiceProxy.GetReferenceAll();
            return Json(list, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AssignUsers(byte taskTypeID)
        {

            List<NodeViewModel> source = new List<NodeViewModel>();

            if (taskTypeID > 0)
            {

                if (Session[SessionKeys.AtanacakKullanicilar] == null)
                {
                    List<Department> departmentUserAll = TaskServiceProxy.GetDepartmentUserByRoleID(CurrentUser.User.UserRoleData.UserRoleID);

                    Department userDepartment = departmentUserAll.Where(d => d.DepartmentID == CurrentUser.User.UserRoleData.DepartmentID).Single();
                    Department rootDep = userDepartment;
                    if (taskTypeID == (byte)EnumTaskTypes.BilgiNotu && userDepartment.UpperDepartmentID.HasValue && CurrentUser.Grup == EnumUserGroup.Kullanici)
                    {
                        departmentUserAll = TaskServiceProxy.GetDepartmentUsersByUpperDepartmentID(userDepartment.UpperDepartmentID.Value, userDepartment.DepartmentID);
                        rootDep = departmentUserAll.Where(d => d.IsRoot == true).SingleOrDefault();

                        if (rootDep == null)
                            rootDep = userDepartment;
                    }
                    //TODO:Makama gönderme kavramı açık
                    NodeViewModel rootNode = new NodeViewModel()
                    {

                        Id = rootDep.DepartmentID,
                        Name = rootDep.Name,
                        Expanded = true,
                        IsUser = false,
                    };
                    ViewBag.inline = new List<TreeSchema>();
                    BindHierarchicalItem(rootNode, departmentUserAll, rootDep);
                    source.Add(rootNode);


                    Session[SessionKeys.AtanacakKullanicilar] = source;
                }
                else
                {
                    source = Session[SessionKeys.AtanacakKullanicilar] as List<NodeViewModel>;
                }
            }
            else
            {
                if (Session[SessionKeys.IletilecekKullanicilar] == null)
                {
                    List<Department> departmentUserAll = TaskServiceProxy.GetDepartmentUserByRoleID(CurrentUser.User.UserRoleData.UserRoleID);

                    Department userDepartment = departmentUserAll.Where(d => d.DepartmentID == CurrentUser.User.UserRoleData.DepartmentID).Single();
                    Department rootDep = userDepartment;
                    if (userDepartment.UpperDepartmentID.HasValue && CurrentUser.Grup != EnumUserGroup.Kullanici)
                    {
                        departmentUserAll = TaskServiceProxy.GetDepartmentUsersByUpperDepartmentID(userDepartment.UpperDepartmentID.Value, userDepartment.DepartmentID);
                        rootDep = departmentUserAll.Where(d => d.IsRoot == true).SingleOrDefault();

                        if (rootDep == null)
                            rootDep = userDepartment;
                    }
                   
                    NodeViewModel rootNode = new NodeViewModel()
                    {

                        Id = rootDep.DepartmentID,
                        Name = rootDep.Name,
                        Expanded = true,
                        IsUser = false,
                    };
                    ViewBag.inline = new List<TreeSchema>();
                    BindHierarchicalItem(rootNode, departmentUserAll, rootDep);
                    source.Add(rootNode);


                    Session[SessionKeys.IletilecekKullanicilar] = source;
                }
                else
                {
                    source = Session[SessionKeys.IletilecekKullanicilar] as List<NodeViewModel>;
                }
            }

            ViewBag.TreeSource = source;

            return PartialView();
        }


        public static void BindHierarchicalItem(NodeViewModel parentNode, List<Department> allDepartment, Department rootDep)
        {


            rootDep.UsersInDepartment.ForEach(u =>
            {

                NodeViewModel childUserNode = new NodeViewModel()
                {
                    Id = u.UserID,
                    Role = u.UserRoleData.RoleData.Name,
                    Name = u.Profile.FirstName + " " + u.Profile.LastName,
                    Expanded = true,
                    IsUser = true,
                    Logo = u.Logo
                };

                parentNode.Children.Add(childUserNode);

            });


            List<Department> childDeps = allDepartment.Where(x => x.UpperDepartmentID == rootDep.DepartmentID).ToList();
            foreach (Department chDep in childDeps)
            {
                NodeViewModel childNode = new NodeViewModel() { Id = chDep.DepartmentID, Name = chDep.Name, Expanded = true };


                parentNode.Children.Add(childNode);
                BindHierarchicalItem(childNode, allDepartment, chDep);


            }


        }

        [HttpPost]
        public ActionResult AddAssignedUsers(int id, bool isChecked)
        {
            List<NodeViewModel> source = Session[SessionKeys.AtanacakKullanicilar] as List<NodeViewModel>;

            Handy.SetNode(null, source[0], id, isChecked);

            return Content(string.Empty);
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
                if (file != null && file.ContentLength > 0)
                {
                    // extract only the filename
                    var fileName = Path.GetFileName(file.FileName);


                    string tmpFilePath = Path.GetTempFileName();

                    AttachedFile aFile = new AttachedFile()
                    {
                        FileName = fileName,
                        TempFileName = tmpFilePath,
                        Extend = Path.GetExtension(file.FileName),
                        ContentType = file.ContentType,
                        Size = file.ContentLength,
                        Visible = true

                    };
                    eklenenDosyalar.Add(aFile);



                    FileEncDec oFileEncoder = new FileEncDec();
                    oFileEncoder.EncryptFileV2(file.InputStream, tmpFilePath);

                    // file.SaveAs(tmpFileName);
                }

            }

            Session[SessionKeys.EklenenDosyalar] = eklenenDosyalar;

            return Content(string.Empty);
        }

        public ActionResult RemoveFile(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"
            List<AttachedFile> eklenenDosyalar = Session[SessionKeys.EklenenDosyalar] as List<AttachedFile>;

            if (fileNames != null && eklenenDosyalar != null)
            {


                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);

                    AttachedFile aFile = eklenenDosyalar.Where(f => f.FileName == fileName).SingleOrDefault();

                    if (aFile !=null && eklenenDosyalar.Contains(aFile))
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

        public ActionResult SetAttachmentView(string fileName, bool view)
        {
            List<AttachedFile> eklenenDosyalar = Session[SessionKeys.EklenenDosyalar] as List<AttachedFile>;

            if (fileName != null && eklenenDosyalar != null)
            {
                AttachedFile aFile = eklenenDosyalar.Where(f => f.FileName == fileName).SingleOrDefault();

                if (aFile != null && eklenenDosyalar.Contains(aFile))
                    aFile.Visible = view;
            }

            return Content(string.Empty);
        }
        private IEnumerable<string> GetFileInfo(IEnumerable<HttpPostedFileBase> files)
        {
            List<string> result = new List<string>();
            foreach (var a in files)
            {
                if (a != null)
                {
                    if (a.ContentLength >= 1024 * 1024)
                    {
                        result.Add(string.Format("{0} ({1} MB)", Path.GetFileName(a.FileName), (a.ContentLength / 1024 * 1024)));
                        continue;
                    }
                    if (a.ContentLength >= 1024)
                    {
                        result.Add(string.Format("{0} ({1} KB)", Path.GetFileName(a.FileName), (a.ContentLength / 1024 * 1024)));
                        continue;
                    }

                    result.Add(string.Format("{0} ({1} Bytes)", Path.GetFileName(a.FileName), a.ContentLength));


                }
            }

            return result;
            //return
            //    from a in files
            //    where a != null
            //    select string.Format("{0} ({1} bytes)", Path.GetFileName(a.FileName), a.ContentLength >= ? a.ContentLength);
        }

        #region PersonnelReferece

        public ActionResult AddPersonnelReferece()
        {
            PersonnelReferenceRequest request = new PersonnelReferenceRequest()
            {

            };
            return PartialView(request);

        }

        public ActionResult PersonnelReferences_Read([DataSourceRequest] DataSourceRequest request)
        {
            List<Reference> referanslar = Session[SessionKeys.EklenenReferanslar] as List<Reference>;

            if (referanslar == null)
            {
                referanslar = new List<Reference>();
                Session[SessionKeys.EklenenReferanslar] = referanslar;
            }

            return Json(referanslar.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PersonnelReferences_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<Reference> model)
        {


            if (model != null && ModelState.IsValid)
            {
                List<Reference> referanslar = Session[SessionKeys.EklenenReferanslar] as List<Reference>;

                model.ForEach(f =>
                {

                    Reference oReferans = referanslar.Where(x => x.ReferenceID == f.ReferenceID).SingleOrDefault();

                    referanslar.Remove(oReferans);


                });

                Session[SessionKeys.EklenenReferanslar] = referanslar;
            }

            return Json(model.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult PersonnelReferenceAddNew(PersonnelReferenceRequest model)
        {
            Reference oReference = Session[SessionKeys.EklenecekReferans] as Reference;
            if (oReference == null)
                oReference = TaskServiceProxy.GetReferenceByID(model.RefID);

            if (oReference == null)
                return Content(string.Format("<script>ShowMessage('{0}','{1}');</script>", "Referans eklenemedi !", (byte)ClientContracts.EnumMessageType.Error));

            List<Reference> referanslar = Session[SessionKeys.EklenenReferanslar] as List<Reference>;
            if (referanslar == null)
                referanslar = new List<Reference>();


            if (model != null) //&& ModelState.IsValid)
            {
                if (referanslar.Where(x => x.ReferenceID == oReference.ReferenceID).SingleOrDefault() != null)
                    return Content(string.Format("<script>ShowMessage('{0}','{1}');</script>", "Referans ekli !", (byte)ClientContracts.EnumMessageType.Warning));

                oReference.IsVisible = model.IsVisible;
                referanslar.Add(oReference);

                Session[SessionKeys.EklenenReferanslar] = referanslar;
                Session[SessionKeys.EklenecekReferans] = null;
            }
            else
            {
                return Content(string.Format("<script>ShowMessage('{0}','{1}');</script>", "Referans eklenemedi !", (byte)ClientContracts.EnumMessageType.Error));

            }






            return Content("<script>CloseReferansWin();</script>");
        }

        public ActionResult AttachReferenceFile(IEnumerable<HttpPostedFileBase> files, string RefID)
        {
            if (files == null || string.IsNullOrEmpty(RefID))
                return Content("dosya alınamadı");

            int nRefereceID = Convert.ToInt32(RefID);

            TempData["UploadedFiles"] = GetFileInfo(files);

            foreach (HttpPostedFileBase file in files)
            {

                if (file == null || file.ContentLength <= 0)
                    return Content("dosya alınamadı");

                var fileName = Path.GetFileName(file.FileName);


                string tmpFileName = Path.GetTempFileName();

                AttachedFile aFile = new AttachedFile()
                {
                    FileName = fileName,
                    TempFileName = tmpFileName,
                    Extend = Path.GetExtension(fileName),
                    ReferenceID = Convert.ToInt32(RefID)

                };



                FileEncDec oFileEncoder = new FileEncDec();
                oFileEncoder.EncryptFileV2(file.InputStream, tmpFileName);
                //file.SaveAs(tmpFileName);

                Reference oReference = TaskServiceProxy.GetReferenceByID(nRefereceID);

                if (oReference != null)
                {
                    oReference.AttachedReferenceFile = aFile;
                    Session[SessionKeys.EklenecekReferans] = oReference;
                }
                else

                    return Content("Referans bulunamadı");


            }



            return Content(string.Empty);
        }

        public ActionResult RemoveReferenceFile(string[] fileNames, int? RefID)
        {
            // The parameter of the Remove action must be called "fileNames"


            if (fileNames != null)
            {


                foreach (var fullName in fileNames)
                {

                    Reference eklenecekReferans = Session[SessionKeys.EklenecekReferans] as Reference;

                    if (eklenecekReferans != null && eklenecekReferans.AttachedReferenceFile != null)
                    {



                        if (System.IO.File.Exists(eklenecekReferans.AttachedReferenceFile.TempFileName))
                        {
                            // The files are not actually removed in this demo
                            System.IO.File.Delete(eklenecekReferans.AttachedReferenceFile.TempFileName);
                        }

                        eklenecekReferans.AttachedReferenceFile = null;
                    }

                    Session[SessionKeys.EklenecekReferans] = eklenecekReferans;



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

        #endregion

        public ActionResult PersonelBilgiTalebiKaydet(TaskRequestModel model)
        {
           
            model.UserRoleID = CurrentUser.User.UserRoleData.UserRoleID;
            model.OpUser = CurrentUser.UserID;
            model.CurrentUserName = CurrentUser.User.UserName;
            model.TaskDescription = Server.HtmlDecode(model.TaskDescription);
            string pageall = model.TaskDescription;
            string sptr = "<style>.pdf-page { margin: 10px auto; box-sizing: border-box; box-shadow: 0 5px 10px 0 rgba(0,0,0,.3); background-color: #fff; color: #333; position: relative; padding: 2.5cm 2.5cm 2.5cm 2.5cm; text-transform: uppercase; overflow:hidden; font-size: 12pt; } .size-a4 { width: 8.3in; max-height:8.3in; height: 11.7in; max-height:11.7in; } .pdf-allpage { margin: 0 auto; box-sizing: border-box; box-shadow: 0 5px 10px 0 rgba(0,0,0,.3); background-color: lightgrey; color: #333; position: relative; width: 8.3in; } </style>";
            model.TaskDescription = model.TaskDescription.Replace(sptr, "");
           //<div class="pdf-allpage"><div class="pdf-page size-a4">wertttttttt</div><div class="pdf-page size-a4"><p>cdscdscsdcdsc</p><p>sc&ccedil;sdcsd&ccedil;sdcvsd</p><p>dcsdpsdvsdv</p></div></div><style>.pdf-page { margin: 10px auto; box-sizing: border-box; box-shadow: 0 5px 10px 0 rgba(0,0,0,.3); background-color: #fff; color: #333; position: relative; padding: 20px; text-transform: uppercase; overflow:hidden; font-size: 12pt; } .size-a4 { width: 8.3in; max-height:8.3in; height: 11.7in; max-height:11.7in; } .pdf-allpage { margin: 0 auto; box-sizing: border-box; box-shadow: 0 5px 10px 0 rgba(0,0,0,.3); background-color: lightgrey; color: #333; position: relative; width: 8.3in; } </style> 

            List<NodeViewModel> selectedNodes = new List<NodeViewModel>();
            List<NodeViewModel> source = Session[SessionKeys.AtanacakKullanicilar] as List<NodeViewModel>;
            if (source != null)
            {
                Handy.GetSelectedNodes(selectedNodes, source[0]);

                model.AtananKullanicilar = selectedNodes.Select(x => x.Id).ToList();

               
            }

            model.TaskAttachedFiles = Session[SessionKeys.EklenenDosyalar] as List<AttachedFile>;

            List<Reference> Referanlar = Session[SessionKeys.EklenenReferanslar] as List<Reference>;

            if (Referanlar != null && Referanlar.Count() > 0)
                model.IlgiliPersonel.References = Referanlar;

            TaskServiceProxy.SaveNewTask(model);

            Session[SessionKeys.AtanacakKullanicilar] = null;
            Session[SessionKeys.EklenenDosyalar] = null;
            Session[SessionKeys.EklenenReferanslar] = null;



            return Content(string.Format("<script>ShowMessage('{0}','{1}')</script>", "Talep kaydedildi", (byte)EnumMessageType.Info));
        }


        [HttpPost]
        public ActionResult SearchTask(string desc)
        {
            List<Task> currentRef = TaskServiceProxy.SearchTask(desc);
            return PartialView("SearchGrid", currentRef);

        }

    }
}