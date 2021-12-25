using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WSD.TaskCloud.Contracts.DataContracts;
using WSD.TaskCloud.Contracts.DataContracts.OrgChart;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Contracts.ServiceContracts;
using WSD.TaskCloud.WcfServices.Business;

namespace WSD.TaskCloud.WcfServices.Implementation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthorizationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthorizationService.svc or AuthorizationService.svc.cs at the Solution Explorer and start debugging.
    internal class AccountService : ServiceBase, IAccountService
    {
        public Users GetUser(string userName, string password)
        {
            return BsFactory<BsAccount>.Instance(TaskCloudContext).GetUser(userName, password);
        }
        public Users GetUserByIDPassword(int userID, string password)
        {
            return BsFactory<BsAccount>.Instance(TaskCloudContext).GetUserByIDPassword(userID, password);
        }

        public Users GetUserByID(int userID)
        {
            return BsFactory<BsAccount>.Instance(TaskCloudContext).GetUserByID(userID);
        }
        public List<Users> GetUsersAll()
        {
            return BsFactory<BsAccount>.Instance(TaskCloudContext).GetUsersAll();
        }

        public List<Permission> GetPermissionsByUserRoleID(int nUserRoleID)
        {
            return BsFactory<BsAccount>.Instance(TaskCloudContext).GetPermissionsByUserRoleID(nUserRoleID);
        }

        public List<NodeViewModel> GetUsersByCurrentUserDepartment(int nUserRoleID)
        {
            return BsFactory<BsAccount>.Instance(TaskCloudContext).GetUsersByCurrentUserDepartment(nUserRoleID);

        }

        public void SaveUser(AddUserRequest request)
        {
            try
            {
                BeginTransaction();

                BsFactory<BsAccount>.Instance(TaskCloudContext).SaveUser(request);

                CommitTransaction();
            }
            catch (ApplicationException ax)
            {
                RollbackTransaction();
                throw ax;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }
        }

        public void UpdateUser(AddUserRequest request)
        {
            try
            {
                BeginTransaction();

                BsFactory<BsAccount>.Instance(TaskCloudContext).UpdateUser(request);

                CommitTransaction();
            }
            catch (ApplicationException ax)
            {
                RollbackTransaction();
                throw ax;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }
        }

        public void ResetPasswordPost(AddUserRequest request)
        {
            try
            {
                BeginTransaction();

                BsFactory<BsAccount>.Instance(TaskCloudContext).ResetPasswordPost(request);

                CommitTransaction();
            }
            catch (ApplicationException ax)
            {
                RollbackTransaction();
                throw ax;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }
        }
    }
}
