using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WSD.TaskCloud.Contracts.DataContracts;
using WSD.TaskCloud.Contracts.DataContracts.Task;
using WSD.TaskCloud.Contracts.DataContracts.TaskBox;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Contracts.ServiceContracts;
using WSD.TaskCloud.WcfServices.Business;

namespace WSD.TaskCloud.WcfServices.Implementation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TaskBoxService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TaskBoxService.svc or TaskBoxService.svc.cs at the Solution Explorer and start debugging.
    internal class TaskBoxService : ServiceBase, ITaskBoxService
    {
       

        public List<TaskRequest> GetTaskRequestByUser(TaskRequestFilter request)
        {
            try
            {

                return BsFactory<BsTaskBox>.Instance(TaskCloudContext).GetTaskRequestByUser(request);

            }
            catch (ApplicationException ax)
            {
                throw ax;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TaskBoxMenuItem> GetTaskStatusByUser(int nUserID, int nUserRoleID, EnumTaskGroup nmGroup)
        {
            try
            {

                return BsFactory<BsTaskBox>.Instance(TaskCloudContext).GetTaskStatusByUser(nUserID, nUserRoleID, nmGroup);

            }
            catch (ApplicationException ax)
            {
                throw ax;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task GetTaskDetailByTaskRequestID(Guid taskRequestID, int nUserID, int nUserRoleID)
        {
            try
            {

                return BsFactory<BsTaskBox>.Instance(TaskCloudContext).GetTaskDetailByTaskRequestID(taskRequestID, nUserID,nUserRoleID);

            }
            catch (ApplicationException ax)
            {
                throw ax;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TaskResponse GetTaskResponseDetailByID(Guid taskResponseID, int nUserID, int nUserRoleID)
        {

            try
            {

                return BsFactory<BsTaskBox>.Instance(TaskCloudContext).GetTaskResponseDetailByID(taskResponseID, nUserID, nUserRoleID);

            }
            catch (ApplicationException ax)
            {
                throw ax;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Attachment GetAttachmentByID(Guid ID)
        {

            try
            {

                return BsFactory<BsAttachment>.Instance(TaskCloudContext).GetAttachmentByID(ID);

            }
            catch (ApplicationException ax)
            {
                throw ax;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
