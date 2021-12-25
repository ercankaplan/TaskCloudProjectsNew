using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WSD.TaskCloud.Contracts.DataContracts;
using WSD.TaskCloud.Contracts.DataContracts.OrgChart;
using WSD.TaskCloud.Contracts.EF;

namespace WSD.TaskCloud.Contracts.ServiceContracts
{
    [ServiceContract(Namespace = Namespaces.ServiceContractNS)]
    public interface IAccountService
    {

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        Users GetUser(string userName, string password);
        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        Users GetUserByIDPassword(int userID, string password);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        Users GetUserByID(int userID);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<Users> GetUsersAll();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<Permission> GetPermissionsByUserRoleID(int nUserRoleID);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<NodeViewModel> GetUsersByCurrentUserDepartment(int nUserRoleID);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        void SaveUser(AddUserRequest request);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        void UpdateUser(AddUserRequest request);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        void ResetPasswordPost(AddUserRequest request);



    }
}
