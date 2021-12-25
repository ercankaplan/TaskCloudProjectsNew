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
    public interface ICacheService
    {
        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<Profession> GetProfessions();
        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<Department> GetDepartments();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<PriorityType> GetPriorityTypes();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<StateType> GetStateTypes();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<TaskType> GetTaskTypes();


        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<PrivacyType> GetPrivacyTypes();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<ResultType> GetResultTypes();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<Role> GetRoles();


        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<Title> GetTitles();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<Reference> GetReferences();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<TaskBy> GetTaskBys();



    }
}
