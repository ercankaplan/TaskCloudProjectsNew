using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using WSD.TaskCloud.Contracts.DataContracts;
using WSD.TaskCloud.Contracts.DataContracts.Task;
using WSD.TaskCloud.Contracts.DataContracts.TaskBox;
using WSD.TaskCloud.Contracts.EF;

namespace WSD.TaskCloud.Contracts.ServiceContracts
{
  
   [ServiceContract(Namespace = Namespaces.ServiceContractNS)]
    public interface ITaskBoxService
    {
        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<TaskRequest> GetTaskRequestByUser(TaskRequestFilter request);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<TaskBoxMenuItem> GetTaskStatusByUser(int nUserID, int nUserRoleID, EnumTaskGroup nmGroup);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        Task GetTaskDetailByTaskRequestID(Guid taskRequstID, int nUserID, int nUserRoleID);



        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        TaskResponse GetTaskResponseDetailByID(Guid taskResponseID, int nUserID, int nUserRoleID);


        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        Attachment GetAttachmentByID(Guid ID);
    }
}
