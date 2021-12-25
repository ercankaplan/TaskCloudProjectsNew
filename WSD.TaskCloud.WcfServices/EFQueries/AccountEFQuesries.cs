using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Data;

namespace WSD.TaskCloud.WcfServices.EFQueries
{
    internal class AccountEFQuesries
    {


        public static readonly Func<TaskCloudEntities, int, IQueryable<UserProfile>> GetUserProfilesInDepartment_CQ =
           CompiledQuery.Compile<TaskCloudEntities, int, IQueryable<UserProfile>>(
           (ctx, Id) => (from u in ctx.Users
                         join p in ctx.UserProfile on u.UserID equals p.UserID
                         join r in ctx.UserRole on u.UserID equals r.UserID
                         where
                         r.DepartmentID == Id
                         select p)
           );

        /// <summary>
        /// ctx, departmentID, UserGroupID
        /// </summary>
        public static readonly Func<TaskCloudEntities, int,int, IQueryable<Users>> GetGrupUsersInDepartment_CQ =
         CompiledQuery.Compile<TaskCloudEntities, int,int, IQueryable<Users>>(
         (ctx, departmentID, userGroupID) => (from u in ctx.Users
                       join p in ctx.UserProfile on u.UserID equals p.UserID
                       join r in ctx.UserRole on u.UserID equals r.UserID
                       where
                       r.DepartmentID == departmentID &&
                                 u.UserGroupID == userGroupID
                                              select u)
         );

        public static readonly Func<TaskCloudEntities, int, IQueryable<Role>> GetUserRole_CQ =
           CompiledQuery.Compile<TaskCloudEntities, int, IQueryable<Role>>(
           (ctx, Id) => (from u in ctx.UserRole
                         join r in ctx.Role on u.RoleID equals r.RoleID
                         where
                         u.UserID == Id
                         select r)
           );

    }
}