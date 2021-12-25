using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WSD.TaskCloud.MVC.Controllers
{
    public class ConversationController : BaseController
    {
        // GET: Conversation
        public ActionResult Index()
        {
            return View();
        }
    }
}