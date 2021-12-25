using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using WSD.TaskCloud.Contracts.DataContracts.Personel;
using WSD.TaskCloud.Contracts.DataContracts.Referans;
using WSD.TaskCloud.Contracts.DataContracts.Task;
using WSD.TaskCloud.Contracts.EF;

namespace WSD.TaskCloud.Contracts.ServiceContracts
{
    [ServiceContract(Namespace = Namespaces.ServiceContractNS)]
    public interface ITaskService
    {
       

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<Reference> GetReferenceAll();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        Reference GetReferenceByID(int refID);


        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        void SaveNewReference(ReferenceRequest request);
        

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        void UpdateReferences(List<Reference> references);


        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        void SaveNewPersonnel(PersonnelRequest request);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<Personnel> GetPersonnelsByDepartmentID(int DepartmentID);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        Personnel GetPersonnelBySicilNo(string sicilNo);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<Department> GetDepartmentUserByRoleID(int nUserRoleID);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<Department> GetDepartmentUsersByUpperDepartmentID(int nUpperDepartmentID, int nDepartmentID);


        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        void SaveNewTask(TaskRequestModel request);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        void SaveTaskRespose(TaskResponseModel request);


        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        void UpdatePersonel(Personnel model);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<Task> SearchTask(string desc);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]

       List<TaskTemplate> GetUserTemplate(int UserID, int typeID);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        void SaveForwardTask(TaskForwardModel request);

        
    }
}
