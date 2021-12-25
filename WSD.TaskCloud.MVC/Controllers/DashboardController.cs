using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSD.TaskCloud.Contracts.DataContracts;
using WSD.TaskCloud.Contracts.DataContracts.TaskBox;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.MVC.HelperClasses;
using WSD.TaskCloud.MVC.Models;

namespace WSD.TaskCloud.MVC.Controllers
{
    public class DashboardController : BaseController
    {
        public ActionResult Index()
        {
            List<TaskBoxMenuItem> list = TaskBoxServiceProxy.GetTaskStatusByUser(CurrentUser.UserID, CurrentUser.UserRoleID, EnumTaskGroup.Sent).OrderByDescending(x => x.TotalCount).ToList();

            List<string> colorCodes = new List<string>();
            colorCodes.Add("#83A8C3");//gray
            colorCodes.Add("#8BBA30");//green
            colorCodes.Add("#EBB741");//yellow
            colorCodes.Add("#385E82");//darkblue
            colorCodes.Add("#455962");//darkgray
            colorCodes.Add("#F0514A");//red
            colorCodes.Add("#3EC7F3");//blue
            colorCodes.Add("#56D9C9");//green2
            colorCodes.Add("#56D9C9");//green2
            colorCodes.Add("#EF3A5B");//red2


            int nOrder = 0;
            list.ForEach(x => { x.ColorCode = colorCodes[nOrder]; x.Order = nOrder++;  });

            @ViewData["DashboardMenuItems"] = list;
            ViewBag.DivCount = list.Count;


            Session[SessionKeys.MyTask] = DashboardServiceProxy.GetTaskList(new Contracts.DataContracts.Dashboard.DashboardTaskFilter()
            {
                UserID = CurrentUser.UserID,
                UserRoleID = CurrentUser.UserRoleID,
                TaskTypeID = list[0].TaskTypeID,
                Optime = DateTime.Today.AddYears(-1)

            });

            return View();
        }

        public ActionResult Task_Read([DataSourceRequest] DataSourceRequest request)
        {
            List<Task> referanslar = Session[SessionKeys.MyTask] as List<Task>;

            if (referanslar == null)
            {
                referanslar = new List<Task>();
                Session[SessionKeys.MyTask] = referanslar;
            }

            return Json(referanslar.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }
    }
}