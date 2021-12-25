using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using WSD.TaskCloud.Contracts.DataContracts;
using WSD.TaskCloud.Contracts.DataContracts.Task;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Data;

namespace WSD.TaskCloud.WcfServices.Business
{
    internal class BsTask : BusinessBase
    {
        public static string ROOTPATH = System.Configuration.ConfigurationManager.AppSettings["FileUploadPath"].ToString();


        public string GenerateTaskNo()
        {



            string sSql = @" DECLARE @SerialNum as int 
                            
                            UPDATE TaskNoGenerator --WITH (rowlock) 
                            SET 	@SerialNum = SerialNum  = SerialNum + 1 
                            WHERE Year = @Year 

                            SELECT convert(varchar(4),@Year)+'/'+ RIGHT('000000'+ISNULL(convert(varchar(6), @SerialNum),''),6)  ";

            string TaskNo = TaskCloudContext.ExecuteStoreQuery<string>(sSql, new SqlParameter("@Year", DateTime.Today.Year)).FirstOrDefault();

            if (string.IsNullOrEmpty(TaskNo))
                throw new ApplicationException("Talep Numarası alınamadı");

            return TaskNo;
        }

        public void SaveNewTask(TaskRequestModel request)
        {



            Task newTask = new Task()
            {
                Deadline = request.Deadline,
                TaskNo = GenerateTaskNo(),
                Optime = DateTime.Now,
                PriorityID = request.PriorityID,
                PrivacyID = request.PrivacyID,
                StateID = (byte)EnumTaskState.YeniKayit,
                Description = request.TaskDescription,
                StartDate = request.StartDate,
                TypeID = request.TaskTypeID,
                UserID = request.OpUser,
                TaskID = Guid.NewGuid(),
                UserRoleID = request.UserRoleID,
                Subject = request.Subject,
                ByID = request.ByID


            };

            TaskCloudContext.Task.AddObject(newTask);
            TaskCloudContext.SaveChanges();


            AssignTask(request.AtananKullanicilar, newTask);


            if (request.IlgiliPersonel != null)//IK taleplerinde
                SavePersonnelData(request, newTask.TaskID);


            if (request.TaskAttachedFiles != null)
                SaveAttachedFile(request.TaskAttachedFiles, request.OpUser, newTask.TaskID);


            if (request.TaskSourceData != null)
            {

                TaskSource ts = new TaskSource()
                {
                    FirstName = request.TaskSourceData.FirstName,
                    LastName = request.TaskSourceData.LastName,
                    //PersonnelID = request.TaskSourceData.PersonnelID,
                    TaskID = newTask.TaskID,
                    Visible = request.TaskSourceData.Visible,
                    Organization = request.TaskSourceData.Organization,
                    Title = request.TaskSourceData.Title

                };

                if (!string.IsNullOrEmpty(request.TaskSourceData.ProfessionNumber))
                {

                    Personnel oPersonnel = BsFactory<BsPersonnel>.Instance(TaskCloudContext).GetPersonnelByProfessionNum(request.TaskSourceData.ProfessionNumber);

                    if (oPersonnel == null)
                        throw new ApplicationException("Talep kaynağı personel bulunamadı");

                    ts.PersonnelID = oPersonnel.PersonnelID;
                    ts.FirstName = oPersonnel.FirstName;
                    ts.LastName = oPersonnel.LastName;

                    TaskCloudContext.TaskSource.AddObject(ts);

                }
                else
                {

                    if (!string.IsNullOrEmpty(ts.FirstName) && !string.IsNullOrEmpty(ts.LastName))
                        TaskCloudContext.TaskSource.AddObject(ts);
                    //else
                    //    throw new ApplicationException("Talep kaynağı bilgilerini kontrol ediniz");

                }




            }

            TaskCloudContext.SaveChanges();

            if (request.SaveAsTemplate == true)
            {

                TaskTemplate template = new TaskTemplate()
                {
                    TaskTypeID = request.TaskTypeID,
                    DraftData = request.TaskDescription,
                    Name = request.Subject,
                    UserID = request.OpUser
                };

                TaskCloudContext.TaskTemplate.AddObject(template);

            }

            TaskCloudContext.SaveChanges();


        }

        public void SaveTaskRespose(TaskResponseModel request)
        {

            List<TaskRequest> taskReqs = TaskCloudContext.TaskRequest.Where(o => o.TaskRequestID == request.TaskRequestID).ToList();

            if (taskReqs.Count <= 0)
                throw new ApplicationException("Talep Atama kaydı bulunamadı");

            Guid tskID = taskReqs[0].TaskID;

            Task tsk = TaskCloudContext.Task.Where(x => x.TaskID == tskID).SingleOrDefault();

            if (tsk == null)
                throw new ApplicationException("Talep kaydı bulunamadı");

            string fileUploadPath = string.Format("{0}/{1}/{2}/", ROOTPATH, request.CurrentUserName, tsk.TaskID);

            if (!System.IO.Directory.Exists(fileUploadPath))
            {
                System.IO.Directory.CreateDirectory(fileUploadPath);
            }


            //Regex StripHTMLExpression = new Regex("<\\S[^><]*>", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled);


            //string plainDesc = StripHTMLExpression.Replace(request.ResponseDescription, string.Empty);

            TaskResponse newResponse = new TaskResponse()
            {
                Description = request.ResponseDescription,
                Optime = DateTime.Now,
                Subject = request.Subject,
                //Summary = request.ResponseDescription.Substring(0, plainDesc.Length > 100 ? 100 : plainDesc.Length),
                TaskRequestID = request.TaskRequestID,
                TaskResponseID = Guid.NewGuid(),
                UserID = request.UserID,
                UserRoleID = request.UserRoleID,
                ViewState = (byte)EnumTaskViewState.Görülmedi,
                //CCUserRoleID

            };

            TaskCloudContext.TaskResponse.AddObject(newResponse);

            TaskCloudContext.SaveChanges();

            if (request.ResponseAttachedFiles != null)
            {
                request.ResponseAttachedFiles.ForEach(f =>
                {
                    Attachment atch = new Attachment()
                    {
                        AttachmentID = Guid.NewGuid(),
                        UserRoleID = request.UserRoleID,
                        UserID = request.UserRoleID,
                        Optime = DateTime.Now,
                        FilePath = fileUploadPath + f.FileName,
                        Name = f.FileName,
                        Extend = f.Extend.Replace(".", ""),
                        Visible = true
                    };

                    TaskResponseAttachment newTaskResponseAttachment = new TaskResponseAttachment()
                    {
                        AttachmentID = atch.AttachmentID,
                        TaskResponseID = newResponse.TaskResponseID
                    };

                    TaskCloudContext.TaskResponseAttachment.AddObject(newTaskResponseAttachment);

                    System.IO.File.Copy(f.TempFileName, fileUploadPath + f.FileName);

                    TaskCloudContext.Attachment.AddObject(atch);
                });

            }

            TaskCloudContext.SaveChanges();

        }

        public void SaveForwardTask(TaskForwardModel request)
        {

            List<TaskRequest> taskReqs = TaskCloudContext.TaskRequest.Where(o => o.TaskRequestID == request.TaskRequestID).ToList();

            if (taskReqs.Count <= 0)
                throw new ApplicationException("Talep Atama kaydı bulunamadı");

            Guid tskID = taskReqs[0].TaskID;

            Task tsk = TaskCloudContext.Task.Where(x => x.TaskID == tskID).SingleOrDefault();

            if (tsk == null)
                throw new ApplicationException("Talep kaydı bulunamadı");

            string fileUploadPath = string.Format("{0}/{1}/{2}/", ROOTPATH, request.CurrentUserName, tsk.TaskID);

            if (!System.IO.Directory.Exists(fileUploadPath))
            {
                System.IO.Directory.CreateDirectory(fileUploadPath);
            }


            TaskCloudContext.Task.Detach(tsk);

            tsk.TaskID = Guid.NewGuid();
            tsk.UpperTaskID = tskID;
            tsk.UserID = request.UserID;
            tsk.UserRoleID = request.UserRoleID;
            tsk.Subject = request.Subject;
            tsk.Description = request.TaskDescription;
            tsk.Optime = DateTime.Now;

            TaskCloudContext.Task.AddObject(tsk);

            AssignTask(request.AtananKullanicilar, tsk);

            if (request.ForwardAttachedFiles != null)
                SaveAttachedFile(request.ForwardAttachedFiles, request.UserID, tsk.TaskID);

            TaskCloudContext.SaveChanges();



        }

        private void AssignTask(List<int> AtananKullanicilar, Task tsk)
        {

            if (AtananKullanicilar != null)
            {


                List<TaskRequest> oAtananKullaniciRequestler = new List<TaskRequest>();

                foreach (var userID in AtananKullanicilar)
                {
                    Users oAtananUser = TaskCloudContext.Users.Where(x => x.UserID == userID).SingleOrDefault();
                    UserRole usrRole = TaskCloudContext.UserRole.Where(u => u.UserID == userID).Single();

                    if (usrRole == null)
                        throw new ApplicationException("Kullanıcı rolü bulunamadı");

                    TaskRequest tr = new TaskRequest()
                    {
                        Optime = DateTime.Now,
                        TaskRequestID = Guid.NewGuid(),
                        TaskID = tsk.TaskID,
                        ToUserID = usrRole.UserID,
                        ToUserRoleID = usrRole.UserRoleID,
                        FromUserID = tsk.UserID,
                        FromUserRoleID = tsk.UserRoleID,
                        ViewState = (byte)EnumTaskViewState.Görülmedi,
                        CC = false
                    };

                    oAtananKullaniciRequestler.Add(tr);

                    if (tsk.PrivacyID == (byte)EnumPrivacy.Public)
                    {

                        List<Users> birimdekiGrupCalisanlari = EFQueries.AccountEFQuesries.GetGrupUsersInDepartment_CQ(TaskCloudContext, usrRole.DepartmentID, oAtananUser.UserGroupID).ToList();

                        foreach (var item in birimdekiGrupCalisanlari)
                        {
                            if (!AtananKullanicilar.Contains(item.UserID))
                            {
                                if (oAtananKullaniciRequestler.Where(a => a.ToUserID == item.UserID).SingleOrDefault() == null)
                                {
                                    UserRole usrRoleForGroup = TaskCloudContext.UserRole.Where(u => u.UserID == item.UserID).Single();

                                    TaskRequest trGrup = new TaskRequest()
                                    {
                                        Optime = DateTime.Now,
                                        TaskRequestID = Guid.NewGuid(),
                                        TaskID = tsk.TaskID,
                                        ToUserID = usrRoleForGroup.UserID,
                                        ToUserRoleID = usrRoleForGroup.UserRoleID,
                                        FromUserID = tsk.UserID,
                                        FromUserRoleID = tsk.UserRoleID,
                                        ViewState = (byte)EnumTaskViewState.Görülmedi,
                                        CC = true
                                    };

                                    oAtananKullaniciRequestler.Add(trGrup);

                                }
                            }
                        }

                    }

                    TaskCloudContext.SaveChanges();
                }

                foreach (var tRequest in oAtananKullaniciRequestler)
                {
                    TaskCloudContext.TaskRequest.AddObject(tRequest);
                }


            }

            TaskCloudContext.SaveChanges();

        }

        private void SaveAttachedFile(List<AttachedFile> TaskAttachedFiles, int UserID, Guid taskID)
        {

            Users opUser = BsFactory<BsAccount>.Instance(TaskCloudContext).GetUserByID(UserID);

            string fileUploadPath = string.Format("{0}/{1}/{2}/", ROOTPATH, opUser.UserName, taskID);

            if (!System.IO.Directory.Exists(fileUploadPath))
            {
                System.IO.Directory.CreateDirectory(fileUploadPath);
            }

            foreach (var f in TaskAttachedFiles)
            {
                Attachment atch = new Attachment()
                {
                    AttachmentID = Guid.NewGuid(),
                    UserRoleID = opUser.UserRoleData.UserRoleID,
                    UserID = opUser.UserID,
                    Optime = DateTime.Now,
                    FilePath = fileUploadPath + f.FileName,
                    Name = f.FileName,
                    Extend = f.Extend.Replace(".", ""),
                    Visible = f.Visible

                };

                TaskAttachment newTaskAttachment = new TaskAttachment()
                {
                    AttachmentID = atch.AttachmentID,
                    TaskID = taskID,

                };

                TaskCloudContext.TaskAttachment.AddObject(newTaskAttachment);

                System.IO.File.Copy(f.TempFileName, fileUploadPath + f.FileName);

                TaskCloudContext.Attachment.AddObject(atch);
            }

        }
        private void SavePersonnelData(TaskRequestModel request, Guid taskID)
        {

            string fileUploadPath = string.Format("{0}/{1}/{2}/", ROOTPATH, request.CurrentUserName, taskID);

            if (!System.IO.Directory.Exists(fileUploadPath))
            {
                System.IO.Directory.CreateDirectory(fileUploadPath);
            }

            Personnel pPersonnelExists = TaskCloudContext.Personnel.Where(o => o.PersonnelID == request.IlgiliPersonel.PersonnelID).SingleOrDefault();

            if (pPersonnelExists == null)
            {
                request.IlgiliPersonel.MarkAsAdded();
                BsFactory<BsPersonnel>.Instance(TaskCloudContext).SaveNewPersonnel(request.IlgiliPersonel);
            }

            if (request.IlgiliPersonel.References != null)
            {

                foreach (Reference reference in request.IlgiliPersonel.References)
                {

                    Guid? attachmentID = null;

                    if (reference.AttachedReferenceFile != null)
                    {
                        attachmentID = Guid.NewGuid();




                        Attachment newAttachment = new Attachment()
                        {
                            AttachmentID = attachmentID.Value,
                            Extend = reference.AttachedReferenceFile.Extend.Replace(".", ""),
                            UserID = request.OpUser,
                            UserRoleID = request.UserRoleID,
                            Name = reference.AttachedReferenceFile.FileName,
                            Optime = DateTime.Now,
                            FilePath = fileUploadPath + reference.AttachedReferenceFile.FileName,
                            Visible = true
                        };

                        TaskCloudContext.Attachment.AddObject(newAttachment);

                        System.IO.File.Copy(reference.AttachedReferenceFile.TempFileName, fileUploadPath + reference.AttachedReferenceFile.FileName);


                    }

                    PersonnelReference newPersonelReference = new PersonnelReference()
                    {
                        PersonnelID = request.IlgiliPersonel.PersonnelID,
                        PersonnelReferenceID = Guid.NewGuid(),
                        ReferenceID = reference.ReferenceID,
                        Optime = DateTime.Now,
                        OpUserID = request.OpUser,
                        AttachmentID = attachmentID,
                        IsVisible = reference.IsVisible


                    };

                    TaskCloudContext.PersonnelReference.AddObject(newPersonelReference);


                }

            }

            TaskPersonnel tp = new TaskPersonnel()
            {
                TaskPersonnelID = Guid.NewGuid(),
                TaskID = taskID,
                PersonnelID = request.IlgiliPersonel.PersonnelID,
            };

            TaskCloudContext.TaskPersonnel.AddObject(tp);
            TaskCloudContext.SaveChanges();

        }

        public List<Task> SearchTask(string desc)
        {
            List<Task> result = TaskCloudContext.Task.Where(i => i.Description.Contains(desc)).ToList();
            return result;
        }
    }
}