using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Contracts.DataContracts;
using WSD.TaskCloud.Contracts.EF;

namespace WSD.TaskCloud.MVC.HelperClasses
{
    public static class CurrentUser
    {

        public static int UserID
        {
            get
            {

                return User.UserID;
            }
        }

        public static EnumUserGroup Grup
        {

            get
            {
                return (EnumUserGroup)User.UserGroupID;
            }

        }
        public static Users User
        {
            get
            {
                //if (HttpContext.Current.Session[SessionKeys.CurrentUser] == null)
                //throw new ApplicationException("Session Expired");

                return HttpContext.Current.Session[SessionKeys.CurrentUser] as Users;
            }
        }

        public static UserProfile Profile
        {
            get
            {
                return User.Profile;
            }
        }

        public static UserRole Role
        {
            get
            {
                return User.UserRoleData;
            }
        }

        public static int UserRoleID
        {
            get
            {

                return User.UserRoleData.UserRoleID;
            }
        }

        public static List<UserSettings> Settings
        {
            get
            {
                return User.UserSettings.ToList();
            }
        }

        public static void LogOff()
        {
            HttpContext.Current.Session[SessionKeys.CurrentUser] = null;
        }

        public static bool HasAccessPermission(string actionCode)
        {

            return User.PermissionCodes.Contains(actionCode);
        }


    }
}