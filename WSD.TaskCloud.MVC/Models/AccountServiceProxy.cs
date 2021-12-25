using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Contracts.DataContracts;
using WSD.TaskCloud.Contracts.DataContracts.OrgChart;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Contracts.ServiceContracts;
using WSD.TaskCloud.MVC.HelperClasses;

namespace WSD.TaskCloud.MVC.Models
{
    public static class AccountServiceProxy
    {

        public static Users GetUserByID(int nUserID)
        {
            Users result = null;
            new ProxyHelper<IAccountService>().Use(svcProxy =>
                {
                    result = svcProxy.GetUserByID(nUserID);
                  
                }, WcfEndpoints.IAccountService);

            return result;
        }

        public static List<Permission> GetPermissionsByUserRoleID(int nUserRoleID)
        {
            List<Permission> result = null;

            new ProxyHelper<IAccountService>().Use(svcProxy =>
            {
                result = svcProxy.GetPermissionsByUserRoleID(nUserRoleID);
              

            }, WcfEndpoints.IAccountService);


            return result;
        }


        public static List<NodeViewModel> GetUsersByCurrentUserDepartment(int nUserRoleID)
        {

            List<NodeViewModel> result = null;

            new ProxyHelper<IAccountService>().Use(svcProxy =>
            {
                result = svcProxy.GetUsersByCurrentUserDepartment(nUserRoleID);


            }, WcfEndpoints.IAccountService);


            return result;
        }

        public static List<Users> GetUsersAll()
        {
            List<Users> result = null;

            new ProxyHelper<IAccountService>().Use(svcProxy =>
            {
                result = svcProxy.GetUsersAll();


            }, WcfEndpoints.IAccountService);


            return result;
        }

        public static void SaveUser(AddUserRequest request)
        {
            

            new ProxyHelper<IAccountService>().Use(svcProxy =>
            {
                 svcProxy.SaveUser(request);


            }, WcfEndpoints.IAccountService);


            
        }

        public static void UpdateUser(AddUserRequest request)
        {


            new ProxyHelper<IAccountService>().Use(svcProxy =>
            {
                svcProxy.UpdateUser(request);


            }, WcfEndpoints.IAccountService);



        }

        public static void ResetPasswordPost(AddUserRequest request)
        {


            new ProxyHelper<IAccountService>().Use(svcProxy =>
            {
                svcProxy.ResetPasswordPost(request);


            }, WcfEndpoints.IAccountService);



        }
    }
}