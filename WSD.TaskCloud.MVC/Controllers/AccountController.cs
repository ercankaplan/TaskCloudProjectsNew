using Common;
using System;
using System.IO;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Security;
using WSD.TaskCloud.Contracts.DataContracts.OrgChart;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Contracts.ServiceContracts;
using WSD.TaskCloud.MVC.ClientContracts;
using WSD.TaskCloud.MVC.HelperClasses;
using WSD.TaskCloud.MVC.Mapper;
using WSD.TaskCloud.MVC.Models;

namespace WSD.TaskCloud.MVC.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string ReturnUrl)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    if (!Membership.ValidateUser(model.UserName, FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, "SHA1")))
                    {
                        ModelState.AddModelError("", "Kullanıcı adı veya şifre hatası.");
                        return View(model);
                    }
                    else
                    {

                        Users currentUser = null;
                        AddUserRequest slcmodel = new AddUserRequest();
                        new ProxyHelper<IAccountService>().Use(svcProxy =>
                        {
                            currentUser = svcProxy.GetUser(model.UserName, FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, "SHA1"));

                            if (currentUser.ISReset != true)
                            {
                                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                                Session[SessionKeys.CurrentUser] = currentUser;
                                //Session[SessionKeys.YetkiliMenuler] = 
                            }
                            else
                            {

                                slcmodel.OpUserID = currentUser.UserID;
                                slcmodel.Password = currentUser.Password;
                                currentUser = null;
                            }

                        }, WcfEndpoints.IAccountService);


                        if (!string.IsNullOrEmpty(ReturnUrl))
                            return GoToSourcePage(ReturnUrl);

                        if (currentUser == null)
                        {
                            return View("ResetPassword", slcmodel);
                        }
                        return RedirectToAction("Index", "Dashboard");

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı giriş yaptınız.");
                    return View(model);
                }
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Sistem Hatası");
                return View(model);
            }
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            CurrentUser.LogOff();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult SessionExpired()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SessionExpiredPost()
        {
            return RedirectToAction("LogOn", "Account");
        }

        private ActionResult GoToSourcePage(string ReturnUrl)
        {
            if (!string.IsNullOrEmpty(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Update()
        {
            var seko = CurrentUser.User.Profile;
            AddUserRequest model = TCMapper.ConvertToVM<AddUserRequest>(seko);
            model.Logo = CurrentUser.User.Logo;
            model.OpUserID = CurrentUser.User.UserID;

            return PartialView(model);
        }

       

        [HttpPost]
        public ActionResult UpdatePost(AddUserRequest model, HttpPostedFileBase LogoImg, HttpPostedFileBase Imza)
        {
            byte[] logoImgByte = null;

            if (LogoImg != null)
            {
                System.Drawing.Image sourceimage = System.Drawing.Image.FromStream(LogoImg.InputStream);
                var img = HtmlHelperExtensions.ResizeImage(sourceimage, 40, 40);
                logoImgByte = HtmlHelperExtensions.imageToByteArray(img);
                model.Logo = logoImgByte;
                CurrentUser.User.Logo = logoImgByte;
                FileEncDec sekoti = new FileEncDec();
                //sekoti.EncryptFile(@Path.Combine(HostingEnvironment.MapPath("~/UploadedFiles"), "2.jpg"), Path.Combine(HostingEnvironment.MapPath("~/UploadedFiles"), "avatar80_3121.jpg"));
                //sekoti.DecryptFile(@Path.Combine(HostingEnvironment.MapPath("~/UploadedFiles"), "avatar80_3121.jpg"), Path.Combine(HostingEnvironment.MapPath("~/UploadedFiles"), "333.jpg"));
            }

            byte[] signImgByte = null;
            if (Imza != null)
            {
                System.Drawing.Image sourceimg = System.Drawing.Image.FromStream(Imza.InputStream);
                var img = HtmlHelperExtensions.ResizeImage(sourceimg,200, 120);
                signImgByte = HtmlHelperExtensions.imageToByteArray(img);
                model.SignImg = signImgByte;
                CurrentUser.User.SignImg = signImgByte;
            }
            


            if (model.Password != null && model.Password != "")
                model.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, "SHA1");

            AccountServiceProxy.UpdateUser(model);

            return RedirectToAction("Dashboard", "Home");
        }

        [HttpPost]
        public ActionResult AddNewPost(AddUserRequest model)
        {
            return PartialView();
        }

        public ActionResult Reset(string passUser, int opUserID)
        {
            AddUserRequest slcmodel = new AddUserRequest();
            slcmodel.Password = passUser;
            slcmodel.OpUserID = opUserID;
            return View(slcmodel);
        }

        [HttpPost]
        public ActionResult ResetPasswordPost(AddUserRequest model)
        {
            AccountServiceProxy.ResetPasswordPost(model);

            Users currentUser = null;
            new ProxyHelper<IAccountService>().Use(svcProxy =>
            {
                currentUser = svcProxy.GetUserByIDPassword(model.OpUserID, FormsAuthentication.HashPasswordForStoringInConfigFile(model.PasswordField, "SHA1"));
                FormsAuthentication.SetAuthCookie(model.UserName, true);
                Session[SessionKeys.CurrentUser] = currentUser;

            }, WcfEndpoints.IAccountService);

            return RedirectToAction("Dashboard", "Home");
        }
    }
}