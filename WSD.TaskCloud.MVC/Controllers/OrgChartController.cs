using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSD.TaskCloud.Contracts.DataContracts;
using WSD.TaskCloud.Contracts.DataContracts.OrgChart;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.MVC.ClientContracts;
using WSD.TaskCloud.MVC.HelperClasses;
using WSD.TaskCloud.MVC.Mapper;
using WSD.TaskCloud.MVC.Models;

namespace WSD.TaskCloud.MVC.Controllers
{
    public class OrgChartController : BaseController
    {
        // GET: OrganizationStructure
        public ActionResult Index()
        {


            return View();

        }

        public ActionResult Departments()
        {

            List<NodeViewModel> nodes = new List<NodeViewModel>();

            List<Department> deps = GeneralDefinitionsServiceProxy.GetDepartments();

            if (deps.Count > 0)
            {

                Department root = deps.Where(x => x.UpperDepartmentID == 0).SingleOrDefault();
                nodes.Add(new NodeViewModel() { Id = root.DepartmentID, Name = root.Name });
                Handy.BindHierarchicalItem(deps, nodes[0]);

            }

            ViewBag.TreeSource = nodes;
            return PartialView();
        }

        public ActionResult Roles()
        {

            return PartialView();
        }

        public ActionResult Roles_Read([DataSourceRequest] DataSourceRequest request)
        {
            List<Role> tts = GeneralDefinitionsServiceProxy.GetRoles();
            return Json(tts.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Roles_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<Role> model)
        {


            if (model != null && ModelState.IsValid)
            {


                GeneralDefinitionsServiceProxy.UpdateRoles(model);

            }

            List<Role> tts = GeneralDefinitionsServiceProxy.GetRoles();
            return Json(tts.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Roles_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<Role> model)
        {



            if (model != null && ModelState.IsValid)
            {
                model.ForEach(x => x.MarkAsModified());
                GeneralDefinitionsServiceProxy.UpdateRoles(model);

            }

            return Json(model.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Roles_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<Role> model)
        {


            if (model != null && ModelState.IsValid)
            {

                model.ForEach(x => x.MarkAsDeleted());
                GeneralDefinitionsServiceProxy.UpdateRoles(model);

            }

            return Json(model.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Users()
        {
           

            return PartialView();

        }

        public ActionResult Users_Read([DataSourceRequest] DataSourceRequest request)
        {
            List<Users> result = AccountServiceProxy.GetUsersAll();
            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        public ActionResult UsersPopup()
        {


            return PartialView();

        }

        public ActionResult UsersPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            List<Users> result = AccountServiceProxy.GetUsersAll();
            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        public ActionResult AddUser()
        {
            AddUserRequest model = new AddUserRequest();
            return View(model);

        }

        [HttpPost]
        public ActionResult AddUserPost(AddUserRequest model, HttpPostedFileBase LogoImg)
        {
            model.OpUserID = CurrentUser.UserID;
            model.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.PasswordField, "SHA1");
            byte[] imgByte = null;
            if (LogoImg != null)
            {
                System.Drawing.Image sourceimage = System.Drawing.Image.FromStream(LogoImg.InputStream);
                var img = HtmlHelperExtensions.ResizeImage(sourceimage, 40, 40);
                imgByte = HtmlHelperExtensions.imageToByteArray(img);
                model.Logo = imgByte;
            }
            AccountServiceProxy.SaveUser(model);
            return Content(string.Format("<script>ShowMessage({0},{1})</script>","Kullanıcı eklendi.",(byte)EnumMessageType.Info));

        }

        public JsonResult _GetDepartments()
        {
            List<Department> selectList = CacheHelper.GetCacheItem<Department>();
            return Json(selectList, JsonRequestBehavior.AllowGet);

        }

        public JsonResult _GetRoles()
        {
            List<Role> selectList = CacheHelper.GetCacheItem<Role>();
            return Json(selectList, JsonRequestBehavior.AllowGet);

        }


        public ActionResult MyProfile()
        {

            var seko = CurrentUser.User.Profile;
            AddUserRequest model = TCMapper.ConvertToVM<AddUserRequest>(seko);
            model.Logo = CurrentUser.User.Logo;
            model.SignImg = CurrentUser.User.SignImg;
            model.OpUserID = CurrentUser.User.UserID;

            return View(model);
        }













    }


}