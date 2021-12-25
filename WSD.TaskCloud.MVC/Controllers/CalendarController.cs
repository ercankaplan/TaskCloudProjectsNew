using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSD.TaskCloud.Contracts.DataContracts.Task;
using WSD.TaskCloud.MVC.ClientContracts;

namespace WSD.TaskCloud.MVC.Controllers
{
    public class CalendarController : BaseController
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        public virtual JsonResult Read([DataSourceRequest] DataSourceRequest request)
        {
            List<TaskScheModel> model = new List<TaskScheModel>();
            return Json(model.ToDataSourceResult(request));
        }

        public virtual JsonResult Destroy([DataSourceRequest] DataSourceRequest request, TaskScheModel task)
        {
            List<TaskScheModel> model = new List<TaskScheModel>();
            return Json(model.ToDataSourceResult(request));
        }

        public virtual JsonResult Create([DataSourceRequest] DataSourceRequest request, TaskScheModel task)
        {
            List<TaskScheModel> model = new List<TaskScheModel>();
            return Json(model.ToDataSourceResult(request));
        }

        public virtual JsonResult Update([DataSourceRequest] DataSourceRequest request, TaskScheModel task)
        {
            List<TaskScheModel> model = new List<TaskScheModel>();
            return Json(model.ToDataSourceResult(request));
        }
    }
}