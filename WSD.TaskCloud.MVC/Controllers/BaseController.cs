using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using WSD.TaskCloud.MVC.ClientContracts;
using WSD.TaskCloud.MVC.HelperClasses;

namespace WSD.TaskCloud.MVC.Controllers
{
    public class BaseController:Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            string errorMessage = "Hata!";

            System.Diagnostics.EventLog.WriteEntry("WSDLight", filterContext.Exception.ToString(), System.Diagnostics.EventLogEntryType.Error);

            if (filterContext.Exception.GetType() == typeof(ApplicationException))
            {
                errorMessage = filterContext.Exception.Message;
            }
            else if (filterContext.Exception.GetType() == typeof(FaultException<Common.MyExceptionDetail>))
            {
                FaultException<Common.MyExceptionDetail> fyEx = (FaultException<Common.MyExceptionDetail>)filterContext.Exception;

                if (fyEx.Detail.ExceptionType == EnumExceptionType.APPLICATION_ERROR)
                    errorMessage = fyEx.Detail.Message;
                else
                    errorMessage = "Uygulamada genel bir hata var";

            }
            else if (filterContext.Exception.GetType() == typeof(FaultException<Common.MyExceptionDetail>))
            {
                FaultException<Common.MyExceptionDetail> fyEx = (FaultException<Common.MyExceptionDetail>)filterContext.Exception;

                if (fyEx.Detail.ExceptionType == EnumExceptionType.APPLICATION_ERROR)
                    errorMessage = fyEx.Detail.Message;
                else
                    errorMessage = "Uygulamada genel bir hata var";

            }
            else if (filterContext.Exception.GetType() == typeof(CommunicationException))
            {
                errorMessage = "Sunucu bağlantı hatası.";
            }
            else
            {
                errorMessage = "Uygulamada genel bir hata var";
            }


            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                JsonResult js = new JsonResult()
                {
                    ContentType = "application/json",
                    Data = errorMessage
                };
                filterContext.Result = js;
            }
            else
            {
                filterContext.Exception = new ApplicationException(errorMessage);
                
            }


            base.OnException(filterContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            if (!Request.IsAuthenticated || CurrentUser.User == null)
            {
                //Session Expire return url
                //filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, 
                //filterContext.ActionDescriptor.ActionName
                if(filterContext.ActionDescriptor.ActionName!= "LogOn" && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName== "Account")
                {
                    filterContext.Result = RedirectToAction("LogOn", "Account");
                }
                else
                {
                    filterContext.Result= Content("<script language='javascript' type='text/javascript'>window.location.href = \"/Account/Logon\";</script>");
                }
                return;
            }
            ViewBag.CurrentUser = CurrentUser.User;
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">Mesaj metni</param>
        /// <param name="msgtype">mesaj türü</param>
        /// <param name="jsFunction">javascript function name  => myGridRefresh()</param>
        /// <returns></returns>
        //public ContentResult CustomContent(string message, EnumMessageType msgtype = EnumMessageType.Info, string jsFunction = "")
        //{
        //    string sMsg = string.Empty;

        //    if (!string.IsNullOrEmpty(message))
        //        sMsg += string.Format("ShowMessage('{0}','{1}');", message, (byte)msgtype);

        //    if (!string.IsNullOrEmpty(jsFunction))
        //        sMsg += jsFunction + ";";

        //    if (!string.IsNullOrEmpty(sMsg))
        //        return Content(string.Format("<script>{0}</script>", sMsg));

        //    return Content(string.Empty);

        //}

        
       
    }
}