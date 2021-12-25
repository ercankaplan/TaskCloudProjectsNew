using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WSD.TaskCloud.Contracts.EF;

namespace WSD.TaskCloud.Contracts.ServiceContracts
{
    [ServiceContract(Namespace = Namespaces.ServiceContractNS)]
    public interface IGeneralDefinitionsService
    {
        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<Department> GetDepartments();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<TaskType> GetTaskTypes();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        void UpdateTaskTypes(List<TaskType> taskTypes);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<StateType> GetStateTypes();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        void UpdateStateTypes(List<StateType> stateTypes);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<PrivacyType> GetPrivacyTypes();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        void UpdatePrivacyTypes(List<PrivacyType> privacyTypes);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<PriorityType> GetPriortyTypes();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        void UpdatePriorityTypes(List<PriorityType> priorityTypes);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<ResultType> GetResultTypes();


        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        void UpdateResultTypes(List<ResultType> resultTypes);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<Role> GetRoles();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        void UpdateRoles(List<Role> roles);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<Title> GetTitles();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        void UpdateTitles(List<Title> titles);
    }
}
