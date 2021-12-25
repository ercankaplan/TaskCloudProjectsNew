using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.MVC.ClientContracts;
using WSD.TaskCloud.MVC.HelperClasses;
using WSD.TaskCloud.MVC.Models;

namespace WSD.TaskCloud.MVC.Controllers
{

    [Authorize]
    public class HomeController : BaseController
    {

        public ActionResult Dashboard()
        {
           
            return View();
            
        }
        
        public ActionResult TaskBox()
        {

            return View();

        }
        public ActionResult GetErrorView(object exception)
        {
            return PartialView("ErrorApp", exception);
        }

        public ActionResult MessagePopup(string msg,int typ)
        {
            MessageModel model = new MessageModel()
            {
                MessageText = msg,
                TypeOfMessage = (EnumMessageType)typ

            };
            return PartialView(model);

        }
    }
}
