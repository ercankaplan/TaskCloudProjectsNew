using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Data;
using WSD.TaskCloud.Contracts.DataContracts;
using WSD.TaskCloud.Contracts.DataContracts.Task;
using WSD.TaskCloud.Contracts.DataContracts.TaskBox;
using WSD.TaskCloud.Contracts.EF;

namespace WSD.TaskCloud.WcfServices.Business
{
    internal class BsTaskBox : BusinessBase
    {
        public List<TaskRequest> GetTaskRequestByUser(TaskRequestFilter request)
        {
            List<TaskRequest> result = new List<TaskRequest>();

            //Role uRole = EFQueries.AccountEFQuesries.GetUserRole_CQ(TaskCloudContext, request.UserID).Single();
            //özel olanlar sadece o kullanıcı tarafından görünecek.
            //diğerleri o rolde başkası girsede görünebilir.

            foreach (var item in TaskCloudContext.TaskType.Where(tt => tt.UpperTaskTypeID == request.TaskTypeID || tt.TaskTypeID == request.TaskTypeID).ToList())
            {



                List<TaskRequest> privateTaskRequests = EFQueries.TaskEFQueries.GetPrivateTaskRequest_CQ(TaskCloudContext, request.UserID, item.TaskTypeID).AsQueryable().AsEnumerable().ToList();

                privateTaskRequests.ForEach(pr =>
                {
                    pr.Task = TaskCloudContext.Task.Where(t => t.TaskID == pr.TaskID).SingleOrDefault();
                    pr.TaskFrom = TaskCloudContext.UserProfile.Where(prf => prf.UserID == pr.FromUserID).SingleOrDefault().FullName;
                    pr.TaskTo = TaskCloudContext.UserProfile.Where(prf => prf.UserID == pr.ToUserID).SingleOrDefault().FullName;

                    result.Add(pr);
                });

                List<TaskRequest> publicTaskRequests = EFQueries.TaskEFQueries.GetPublicTaskRequest_CQ(TaskCloudContext, request.UserRoleID, item.TaskTypeID).AsQueryable().AsEnumerable().ToList();


                foreach (var pb in publicTaskRequests)
                {


                    if (result.Where(t => t.TaskID == pb.TaskID).SingleOrDefault() != null)
                        continue;

                    pb.Task = TaskCloudContext.Task.Where(t => t.TaskID == pb.TaskID).SingleOrDefault();
                    pb.TaskFrom = TaskCloudContext.UserProfile.Where(prf => prf.UserID == pb.FromUserID).SingleOrDefault().FullName;
                    pb.TaskTo = TaskCloudContext.UserProfile.Where(prf => prf.UserID == pb.ToUserID).SingleOrDefault().FullName;
                    result.Add(pb);
                }
            }

            return result;

        }


        public List<TaskBoxMenuItem> GetTaskStatusByUser(int nUserID, int nUserRoleID, EnumTaskGroup nmGroup)
        {
            List<TaskBoxMenuItem> result = new List<TaskBoxMenuItem>();
            List<TaskBoxMenuItem> tempResult = null;

            if (nmGroup == EnumTaskGroup.Income)
                tempResult = TaskCloudContext.ExecuteStoreQuery<TaskBoxMenuItem>("exec GetTaskRequestStatusByUser_SP @ToUserID", new SqlParameter("ToUserID", nUserID)).ToList();
            else if (nmGroup == EnumTaskGroup.Sent)
                tempResult = TaskCloudContext.ExecuteStoreQuery<TaskBoxMenuItem>("exec GetTaskStatusByUser_SP @UserID", new SqlParameter("UserID", nUserID)).ToList();



            foreach (var item in tempResult.Where(x => x.UpperTaskTypeID == null))
            {
                if (tempResult.Where(x => x.UpperTaskTypeID == item.TaskTypeID).ToList().Count > 0)
                    BindMenuItem(item, tempResult);

                result.Add(item);
            }

            return result;

        }

        private static void BindMenuItem(TaskBoxMenuItem parent, List<TaskBoxMenuItem> all)
        {
            foreach (var item in all.Where(x => x.UpperTaskTypeID == parent.TaskTypeID).ToList())
            {
                if (all.Where(x => x.UpperTaskTypeID == item.TaskTypeID).ToList().Count > 0)
                    BindMenuItem(item, all);

                parent.SubTaskBoxMenuItem.Add(item);
                parent.UnreadCount += item.UnreadCount;
            }
        }

        public Task GetTaskDetailByTaskRequestID(Guid taskRequestID, int nUserID, int nUserRoleID)
        {
            Users oUser = TaskCloudContext.Users.Where(x => x.UserID == nUserID).SingleOrDefault();
            UserRole oUserRole = TaskCloudContext.UserRole.Where(u => u.UserID == nUserID).Single();

            if (oUserRole == null)
                throw new ApplicationException("Kullanıcı rolü bulunamadı");

            TaskRequest tr = TaskCloudContext.TaskRequest.Where(r => r.TaskRequestID == taskRequestID).SingleOrDefault();

            if (tr == null)
                throw new ApplicationException("Talep bulunamadı");
            else
            {
                if (tr.ViewState == (byte)EnumTaskViewState.Görülmedi)
                {

                    tr.ViewState = (byte)EnumTaskViewState.Görüldü;
                    TaskCloudContext.TaskRequest.ApplyChanges(tr);
                    TaskCloudContext.SaveChanges();
                }

            }

            Task tsk = GetTaskDetailByTaskID(tr.TaskID, nUserID, nUserRoleID);

            return tsk;

        }

        public Task GetTaskDetailByTaskID(Guid TaskID, int nUserID, int nUserRoleID)
        {
            Users oUser = TaskCloudContext.Users.Where(x => x.UserID == nUserID).SingleOrDefault();
            UserRole oUserRole = TaskCloudContext.UserRole.Where(u => u.UserID == nUserID).Single();

            if (oUserRole == null)
                throw new ApplicationException("Kullanıcı rolü bulunamadı");

            Task tsk = TaskCloudContext.Task.Include("TaskRequest").Where(o => o.TaskID == TaskID).SingleOrDefault();

            if (tsk == null)
                throw new ApplicationException("Talep detayı bulunamadı");

            tsk.Attachments = new List<Attachment>();

            List<Attachment> tskAttachments = EFQueries.TaskEFQueries.GetTaskAttachments_CQ(TaskCloudContext, tsk.TaskID).ToList();

            foreach (var item in tskAttachments)
            {
                if (item.Visible == true)
                {
                    tsk.Attachments.Add(item);
                }
                else if (item.UserID == nUserID)
                {
                    tsk.Attachments.Add(item);
                }
            }

            tsk.Users = BsFactory<BsAccount>.Instance(TaskCloudContext).GetUserByID(tsk.UserID);

            TrackableCollection<TaskRequest> listRequest = new TrackableCollection<TaskRequest>();

            List<Users> birimdekiGrupCalisanlari = EFQueries.AccountEFQuesries.GetGrupUsersInDepartment_CQ(TaskCloudContext, oUserRole.DepartmentID, oUser.UserGroupID).ToList();

            foreach (TaskRequest request in tsk.TaskRequest)
            {

                if (birimdekiGrupCalisanlari.Count() > 0 && birimdekiGrupCalisanlari.Select(x => x.UserID).ToList().Contains(request.ToUserID))
                {
                    listRequest.Add(request);
                    continue;
                }


                if (request.FromUserID == nUserID)
                {
                    listRequest.Add(request);
                }
                else if (request.ToUserID == nUserID)
                {
                    listRequest.Add(request);
                }


                if (tsk.PrivacyID == (byte)EnumPrivacy.Public)
                {
                    //Vekalet işleri
                    if (request.FromUserRoleID == nUserRoleID)
                    {
                        listRequest.Add(request);
                    }
                    else if (request.ToUserRoleID == nUserRoleID)
                    {
                        listRequest.Add(request);
                    }

                }




            }

            foreach (var request in listRequest)
            {
                List<TaskResponse> TaskResponselar = TaskCloudContext.TaskResponse.Where(r => r.TaskRequestID == request.TaskRequestID).OrderByDescending(x => x.Optime).ToList();

                TaskResponselar.ForEach(oTaskResponse =>
                {
                    oTaskResponse.Attachments = EFQueries.TaskEFQueries.GetTaskResponseAttachments_CQ(TaskCloudContext, oTaskResponse.TaskResponseID).ToList();

                    oTaskResponse.ResponseFrom = TaskCloudContext.UserProfile.Where(p => p.UserID == oTaskResponse.UserID).SingleOrDefault().FullName;

                    request.TaskResponse.Add(oTaskResponse);
                });
            }

            tsk.TaskRequest = listRequest;

            if (tsk.TypeID == (byte)EnumTaskTypes.PersonelTalebi)
            {
                tsk.PersonelData = EFQueries.TaskEFQueries.GetTaskPersonnel_CQ(TaskCloudContext, tsk.TaskID).SingleOrDefault();

                if (tsk.PersonelData != null)
                {

                    tsk.PersonelData.References = new List<Reference>();

                    List<PersonnelReference> oPersonnelReferences = EFQueries.TaskEFQueries.GetPersonnelReferences_CQ(TaskCloudContext, tsk.TaskID).ToList();

                    foreach (PersonnelReference pr in oPersonnelReferences)
                    {
                        if (pr.IsVisible == true)
                        {
                            Reference oReference = TaskCloudContext.Reference.Where(a => a.ReferenceID == pr.ReferenceID).Single();
                            tsk.PersonelData.References.Add(oReference);
                        }
                        else if (pr.OpUserID == nUserID)
                        {
                            //visible değil ise sadece yükleyen görsün
                            Reference oReference = TaskCloudContext.Reference.Where(a => a.ReferenceID == pr.ReferenceID).Single();
                            tsk.PersonelData.References.Add(oReference);

                        }
                    }



                    tsk.PersonelData.References.ForEach(r => { r.Attachments = EFQueries.TaskEFQueries.GetReferencesAttachment_CQ(TaskCloudContext, r.ReferenceID).ToList(); });
                }

            }

            GetLegacyTask(TaskCloudContext, tsk);

            return tsk;
        }

        private static void GetLegacyTask(TaskCloudEntities ctx, Task tsk)
        {
            Task oncekiTask = ctx.Task.Where(x => x.TaskID == tsk.UpperTaskID).SingleOrDefault();
            if (oncekiTask != null)
            {
                tsk.LegacyTask = oncekiTask;
                GetLegacyTask(ctx,oncekiTask);
            }
            else
                return;


        }

        public TaskResponse GetTaskResponseDetailByID(Guid taskResponseID, int nUserID, int nUserRoleID)
        {

            TaskResponse result = TaskCloudContext.TaskResponse.Where(x => x.TaskResponseID == taskResponseID).SingleOrDefault();

            result.Attachments = EFQueries.TaskEFQueries.GetTaskResponseAttachments_CQ(TaskCloudContext, result.TaskResponseID).ToList();

            return result;

        }


    }
}