using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WSD.TaskCloud.Contracts.DataContracts;
using WSD.TaskCloud.Contracts.DataContracts.OrgChart;
using WSD.TaskCloud.Contracts.DataContracts.Task;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Data;
using WSD.TaskCloud.WcfServices.EFQueries;

namespace WSD.TaskCloud.WcfServices.Business
{
    internal class BsAccount : BusinessBase
    {

        public Users GetUser(string userName, string password)
        {

            Users oUser = TaskCloudContext.Users.Where(x => x.UserName == userName && x.Password == password).SingleOrDefault();

            if (oUser == null)
                throw new ApplicationException("Kullanıcı kaydı bulunamadı");

            TaskCloudContext.UserRole.Where(x => x.UserID == oUser.UserID).ToList().ForEach(role =>
             {
                 List<string> actionCodes = TaskCloudContext.Permission.Where(o => o.UserRoleID == role.UserRoleID).Select(x => x.ActionCode).ToList();

                 if (actionCodes.Count > 0)
                     oUser.PermissionCodes.AddRange(actionCodes);

                 role.RoleData = TaskCloudContext.Role.Where(r => r.RoleID == role.RoleID).SingleOrDefault();
                 oUser.UserRoleData = role;//Proxyrole ü düşünücez

             });

            oUser.Profile = TaskCloudContext.UserProfile.Where(o => o.UserID == oUser.UserID).SingleOrDefault();

            UserSignImg oUserSignImg = TaskCloudContext.UserSignImg.Where(o => o.UserID == oUser.UserID).SingleOrDefault();
            if (oUserSignImg != null)
                oUser.SignImg = oUserSignImg.SignImg;


            return oUser;

        }
        public Users GetUserByIDPassword(int userID, string password)
        {

            Users oUser = TaskCloudContext.Users.Where(x => x.UserID == userID && x.Password == password).SingleOrDefault();

            if (oUser == null)
                throw new ApplicationException("Kullanıcı kaydı bulunamadı");

            TaskCloudContext.UserRole.Where(x => x.UserID == oUser.UserID).ToList().ForEach(role =>
            {
                List<string> actionCodes = TaskCloudContext.Permission.Where(o => o.UserRoleID == role.UserRoleID).Select(x => x.ActionCode).ToList();

                if (actionCodes.Count > 0)
                    oUser.PermissionCodes.AddRange(actionCodes);

                role.RoleData = TaskCloudContext.Role.Where(r => r.RoleID == role.RoleID).SingleOrDefault();
                oUser.UserRoleData = role;//Proxyrole ü düşünücez

            });

            oUser.Profile = TaskCloudContext.UserProfile.Where(o => o.UserID == oUser.UserID).SingleOrDefault();

            UserSignImg oUserSignImg = TaskCloudContext.UserSignImg.Where(o => o.UserID == oUser.UserID).SingleOrDefault();
            if (oUserSignImg != null)
                oUser.SignImg = oUserSignImg.SignImg;


            return oUser;

        }

        public Users GetUserByID(int userID)
        {

            Users oUser = TaskCloudContext.Users.Where(x => x.UserID == userID).SingleOrDefault();

            if (oUser == null)
                throw new ApplicationException("Kullanıcı kaydı bulunamadı");

            TaskCloudContext.UserRole.Where(x => x.UserID == oUser.UserID).ToList().ForEach(role =>
            {
                List<string> actionCodes = TaskCloudContext.Permission.Where(o => o.UserRoleID == role.UserRoleID).Select(x => x.ActionCode).ToList();

                if (actionCodes.Count > 0)
                    oUser.PermissionCodes.AddRange(actionCodes);

                role.RoleData = TaskCloudContext.Role.Where(r => r.RoleID == role.RoleID).SingleOrDefault();
                oUser.UserRoleData = role;//Proxyrole ü düşünücez

            });



            oUser.Profile = TaskCloudContext.UserProfile.Where(o => o.UserID == oUser.UserID).SingleOrDefault();

            UserSignImg oUserSignImg = TaskCloudContext.UserSignImg.Where(o => o.UserID == oUser.UserID).SingleOrDefault();
            if (oUserSignImg != null)
                oUser.SignImg = oUserSignImg.SignImg;


            return oUser;

        }


        public List<Users> GetUsersAll()
        {

            List<Users> result = TaskCloudContext.Users.ToList();

            result.ForEach(x =>
            {
                x.Profile = TaskCloudContext.UserProfile.Where(o => o.UserID == x.UserID).SingleOrDefault();
                x.UserRoleData = TaskCloudContext.UserRole.Where(r => r.UserID == x.UserID && r.IsActive == true && r.ProxyUserID.HasValue == false).SingleOrDefault();
                x.UserRoleData.RoleData = TaskCloudContext.Role.Where(r => r.RoleID == x.UserRoleData.RoleID).SingleOrDefault();
            });

            return result;

        }

        public List<Permission> GetPermissionsByUserRoleID(int nUserRoleID)
        {

            List<Permission> userPermissions = TaskCloudContext.Permission.Where(o => o.UserRoleID == nUserRoleID).ToList();

            return userPermissions;

        }

        public List<Department> GetDepartmentUserByRoleID(int nUserRoleID)
        {

            List<Department> result = new List<Department>();

            UserRole currentUserRole = TaskCloudContext.UserRole.Where(x => x.UserRoleID == nUserRoleID).SingleOrDefault();

            if (currentUserRole != null)
            {
                Department dp = TaskCloudContext.Department.Where(d => d.DepartmentID == currentUserRole.DepartmentID).SingleOrDefault();

                if (dp != null)
                {
                    dp.UsersInDepartment = new List<Users>();
                    TaskCloudContext.UserRole.Where(x => x.DepartmentID == dp.DepartmentID).ToList().ForEach(o =>
                    {

                        Users oUser = TaskCloudContext.Users.Where(x => x.UserID == o.UserID).SingleOrDefault();
                        oUser.Profile = TaskCloudContext.UserProfile.Where(p => p.UserID == o.UserID).SingleOrDefault();
                        oUser.UserRoleData = TaskCloudContext.UserRole.Where(r => r.UserID == o.UserID && r.IsActive == true && r.ProxyUserID.HasValue == false).SingleOrDefault();
                        oUser.UserRoleData.RoleData = TaskCloudContext.Role.Where(r => r.RoleID == o.RoleID).SingleOrDefault();

                        dp.UsersInDepartment.Add(oUser);
                    });
                    result.Add(dp);
                    BindDepartmentDownPath(TaskCloudContext, result, dp);
                }

            }

            return result;

        }
        public List<Department> GetDepartmentUsersByUpperDepartmentID(int nUpperDepartmentID, int nDepartmentID)
        {

            List<Department> result = new List<Department>();

            Department userDepartment = TaskCloudContext.Department.Where(d => d.DepartmentID == nDepartmentID).SingleOrDefault();
            Department userUpperDepartment = TaskCloudContext.Department.Where(d => d.DepartmentID == nUpperDepartmentID).SingleOrDefault();
            if (userUpperDepartment != null)
            {
                GetDepartmentUpPath(TaskCloudContext, userUpperDepartment, result);
                result.Add(userDepartment);
            }
            else
            {
                GetDepartmentUpPath(TaskCloudContext, userDepartment, result);
            }

            foreach (var dp in result)
            {
                dp.UsersInDepartment = new List<Users>();

                List<UserRole> UserRoleInDepartment = TaskCloudContext.UserRole.Where(x => x.DepartmentID == dp.DepartmentID).ToList();

                foreach (var o in UserRoleInDepartment)
                {
                    Users oUser = TaskCloudContext.Users.Where(x => x.UserID == o.UserID).SingleOrDefault();
                    oUser.Profile = TaskCloudContext.UserProfile.Where(p => p.UserID == o.UserID).SingleOrDefault();
                    oUser.UserRoleData = TaskCloudContext.UserRole.Where(r => r.UserID == o.UserID && r.IsActive == true && r.ProxyUserID.HasValue == false).SingleOrDefault();
                    oUser.UserRoleData.RoleData = TaskCloudContext.Role.Where(r => r.RoleID == o.RoleID).SingleOrDefault();

                    dp.UsersInDepartment.Add(oUser);
                }
            }


            //BindDepartments(TaskCloudContext, result, dp);

            return result;

        }

        public static void GetDepartmentUpPath(TaskCloudEntities ctx, Department dp, List<Department> path)
        {

            path.Add(dp);
            List<UserRole> UserRoleInDepartment = ctx.UserRole.Where(x => x.DepartmentID == dp.DepartmentID).ToList();

            if (UserRoleInDepartment.Count > 0)
            {
                dp.IsRoot = true;
                return;
            }
            else
            {
                dp = ctx.Department.Where(x => x.DepartmentID == dp.UpperDepartmentID).SingleOrDefault();
                GetDepartmentUpPath(ctx, dp, path);
            }
        }


        public static void BindDepartmentDownPath(TaskCloudEntities ctx, List<Department> result, Department parentNode)
        {

            List<Department> childDepartmanlar = ctx.Department.Where(d => d.UpperDepartmentID == parentNode.DepartmentID).ToList();

            foreach (Department ch in childDepartmanlar)
            {
                ch.UsersInDepartment = new List<Users>();
                ctx.UserRole.Where(x => x.DepartmentID == ch.DepartmentID).ToList().ForEach(o =>
                {

                    Users oUser = ctx.Users.Where(x => x.UserID == o.UserID).SingleOrDefault();
                    oUser.Profile = ctx.UserProfile.Where(p => p.UserID == o.UserID).SingleOrDefault();
                    oUser.UserRoleData = ctx.UserRole.Where(r => r.UserID == o.UserID && r.IsActive == true && r.ProxyUserID.HasValue == false).SingleOrDefault();
                    oUser.UserRoleData.RoleData = ctx.Role.Where(r => r.RoleID == o.RoleID).SingleOrDefault();

                    ch.UsersInDepartment.Add(oUser);
                });
                result.Add(ch);
                BindDepartmentDownPath(ctx, result, ch);
            }

        }

        public List<NodeViewModel> GetUsersByCurrentUserDepartment(int nUserRoleID)
        {


            List<NodeViewModel> root = new List<NodeViewModel>();

            UserRole result = TaskCloudContext.UserRole.Where(x => x.UserRoleID == nUserRoleID).SingleOrDefault();

            if (result != null)
            {

                Department dp = TaskCloudContext.Department.Where(d => d.DepartmentID == result.DepartmentID).SingleOrDefault();

                if (dp != null)
                {

                    root.Add(new NodeViewModel() { Id = dp.DepartmentID, Name = dp.Name });

                    List<Department> allDepartment = TaskCloudContext.Department.ToList();

                    BindHierarchicalItem(TaskCloudContext, allDepartment, root[0]);
                }
            }


            return root;


        }

        public static void BindHierarchicalItem(TaskCloudEntities ctx, List<Department> allDepartment, NodeViewModel parentNode)
        {

            parentNode.UsersInDepartment = AccountEFQuesries.GetUserProfilesInDepartment_CQ(ctx, parentNode.Id).ToList();

            parentNode.UsersInDepartment.ForEach(user =>
            {



                NodeViewModel childUserNode = new NodeViewModel()
                {
                    Id = user.UserID,
                    Role = AccountEFQuesries.GetUserRole_CQ(ctx, user.UserID).Single().Name,
                    Name = user.FirstName + " " + user.LastName,
                    Expanded = true,
                    IsUser = true,
                    Logo = ctx.Users.Where(u => u.UserID == user.UserID).Single().Logo
                };

                parentNode.Children.Add(childUserNode);
            });


            List<Department> childs = allDepartment.Where(x => x.UpperDepartmentID == parentNode.Id).ToList();
            foreach (Department child in childs)
            {
                NodeViewModel childNode = new NodeViewModel() { Id = child.DepartmentID, Name = child.Name, Expanded = true };


                parentNode.Children.Add(childNode);
                BindHierarchicalItem(ctx, allDepartment, childNode);


            }


        }


        public void SaveUser(AddUserRequest request)
        {




            Users newUser = new Users()
            {
                CreateDate = DateTime.Now,
                Comment = null,
                FailedPasswordAttemptCount = 5,
                IsActive = true,
                IsLockedOut = false,
                Password = request.Password,
                UserName = request.UserName,
                ISReset = true,
                Logo = request.Logo

            };

            TaskCloudContext.Users.AddObject(newUser);
            TaskCloudContext.SaveChanges();

            UserRole newRole = new UserRole()
            {
                DepartmentID = request.DepartmentID,
                IsActive = true,
                Optime = DateTime.Now,
                OpUserID = request.OpUserID,
                RoleID = request.RoleID,
                StartDate = DateTime.Now,
                UserID = newUser.UserID,

            };

            TaskCloudContext.UserRole.AddObject(newRole);
            TaskCloudContext.SaveChanges();

            UserProfile newProfile = new UserProfile()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Mobile = request.Mobile,
                RegistryNum = request.RegistryNum,
                UserID = newUser.UserID,
                ImgUrl = string.Empty
            };

            TaskCloudContext.UserProfile.AddObject(newProfile);
            TaskCloudContext.SaveChanges();




        }
        public void UpdateUser(AddUserRequest request)
        {
            Users currentUser = TaskCloudContext.Users.Where(i => i.UserID == request.OpUserID).FirstOrDefault();
            UserProfile currentProfile = TaskCloudContext.UserProfile.Where(i => i.UserID == request.OpUserID).FirstOrDefault();
            UserSignImg currentSign = TaskCloudContext.UserSignImg.Where(i => i.UserID == request.OpUserID).FirstOrDefault();

            if (currentSign == null)
                currentSign = new UserSignImg() { UserID = currentUser.UserID };

            currentProfile.Email = request.Email;
            currentProfile.FirstName = request.FirstName;
            currentProfile.LastName = request.LastName;
            currentProfile.Mobile = request.Mobile;
            currentUser.Logo = request.Logo;
            if (request.Password != null && request.Password != "")
                currentUser.Password = request.Password;

            if (request.SignImg != null)
            {
                currentSign.SignImg = request.SignImg;
                TaskCloudContext.UserSignImg.ApplyChanges(currentSign);
            }


            TaskCloudContext.UserProfile.ApplyCurrentValues(currentProfile);
            TaskCloudContext.Users.ApplyCurrentValues(currentUser);
            TaskCloudContext.SaveChanges();
        }

        public void ResetPasswordPost(AddUserRequest request)
        {
            Users newUser = TaskCloudContext.Users.Where(i => i.UserID == request.OpUserID && i.Password == request.Password).FirstOrDefault();
            if (newUser != null)
            {
                newUser.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(request.PasswordField, "SHA1");
                newUser.ISReset = false;
            }
            TaskCloudContext.Users.ApplyCurrentValues(newUser);
            TaskCloudContext.SaveChanges();
        }


    }
}