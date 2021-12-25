using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Contracts.DataContracts;
using WSD.TaskCloud.Contracts.DataContracts.Dashboard;
using WSD.TaskCloud.Contracts.EF;

namespace WSD.TaskCloud.WcfServices.Business
{

    internal class BsDashboard : BusinessBase
    {
        public List<Task> GetTaskList(DashboardTaskFilter filter)
        {

            List<Task> result = new List<Task>();

            Role uRole = EFQueries.AccountEFQuesries.GetUserRole_CQ(TaskCloudContext, filter.UserID).Single();
            //özel olanlar sadece o kullanıcı tarafından görünecek.
            //diğerleri o rolde başkası girsede görünebilir.

            if (filter.TaskTypeID == 0)
            {

                List<Task> privateTasks = TaskCloudContext.Task.Where(t => t.UserID == filter.UserID).AsQueryable().AsEnumerable().ToList();

                privateTasks.ForEach(pr =>
                {
                    TaskCloudContext.TaskRequest.Where(r => r.TaskID == pr.TaskID).ToList().ForEach(o => { pr.TaskRequest.Add(o); });
                    result.Add(pr);
                });

                List<Task> publicTasks = TaskCloudContext.Task.Where(t => t.UserRoleID == filter.UserRoleID && t.PrivacyID == (byte)EnumPrivacy.Public).AsQueryable().AsEnumerable().ToList();
                publicTasks.ForEach(pb =>
                {
                    if (result.Where(t => t.TaskID == pb.TaskID).SingleOrDefault() == null)
                    {
                        TaskCloudContext.TaskRequest.Where(r => r.TaskID == pb.TaskID).ToList().ForEach(o => { pb.TaskRequest.Add(o); });
                        result.Add(pb);
                    }
                });

            }
            else
            {
                List<Task> privateTasks = TaskCloudContext.Task.Where(t => t.UserID == filter.UserID && t.TypeID == filter.TaskTypeID).AsQueryable().AsEnumerable().ToList();

                privateTasks.ForEach(pr =>
                {
                    TaskCloudContext.TaskRequest.Where(r => r.TaskID == pr.TaskID).ToList().ForEach(o => { pr.TaskRequest.Add(o); });
                    result.Add(pr);
                });

                List<Task> publicTasks = TaskCloudContext.Task.Where(t => t.UserRoleID == filter.UserRoleID && t.TypeID == filter.TaskTypeID).AsQueryable().AsEnumerable().ToList();
                publicTasks.ForEach(pb =>
                {
                    if (result.Where(t => t.TaskID == pb.TaskID).SingleOrDefault() == null)
                    {
                        TaskCloudContext.TaskRequest.Where(r => r.TaskID == pb.TaskID).ToList().ForEach(o => { pb.TaskRequest.Add(o); });
                        result.Add(pb);
                    }
                });
            }

            return result;

        }
    }
}