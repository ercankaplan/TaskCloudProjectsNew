using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Contracts.DataContracts;
using WSD.TaskCloud.Contracts.DataContracts.Task;
using WSD.TaskCloud.Contracts.DataContracts.TaskBox;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Contracts.ServiceContracts;
using WSD.TaskCloud.MVC.HelperClasses;

namespace WSD.TaskCloud.MVC.Models
{
    public static class TaskBoxServiceProxy
    {
        public static List<TaskRequest> GetTaskRequestByUser(TaskRequestFilter request)
        {

            List<TaskRequest> result = null;

            new ProxyHelper<ITaskBoxService>().Use(svcProxy =>
            {
                result = svcProxy.GetTaskRequestByUser(request);


            }, WcfEndpoints.ITaskBoxService);


            return result;

        }

        public static List<TaskBoxMenuItem> GetTaskStatusByUser(int nUserID, int nUserRoleID, EnumTaskGroup nmGroup)
        {
            List<TaskBoxMenuItem> result = null;

            new ProxyHelper<ITaskBoxService>().Use(svcProxy =>
            {
                result = svcProxy.GetTaskStatusByUser(nUserID, nUserRoleID, nmGroup);


            }, WcfEndpoints.ITaskBoxService);


            return result;
        }

        public static Task GetTaskDetailByTaskRequestID(Guid taskRequestID, int nUserID, int nUserRoleID)
        {

            Task result = null;

            new ProxyHelper<ITaskBoxService>().Use(svcProxy =>
            {
                result = svcProxy.GetTaskDetailByTaskRequestID(taskRequestID, nUserID,nUserRoleID);


            }, WcfEndpoints.ITaskBoxService);


            return result;

        }

        public static TaskResponse GetTaskResponseDetailByID(Guid taskResponseID, int nUserID, int nUserRoleID)
        {

            TaskResponse result = null;

            new ProxyHelper<ITaskBoxService>().Use(svcProxy =>
            {
                result = svcProxy.GetTaskResponseDetailByID(taskResponseID, nUserID, nUserRoleID);


            }, WcfEndpoints.ITaskBoxService);


            return result;

        }

        public static Attachment GetAttachmentByID(Guid ID)
        {

            Attachment result = null;

            new ProxyHelper<ITaskBoxService>().Use(svcProxy =>
            {
                result = svcProxy.GetAttachmentByID(ID);


            }, WcfEndpoints.ITaskBoxService);


            return result;
        }
    }
}