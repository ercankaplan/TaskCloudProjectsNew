using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.MVC.ClientContracts;
using WSD.TaskCloud.MVC.Models;

namespace WSD.TaskCloud.MVC.Controllers
{
    public class GeneralDefinitionsController : BaseController
    {
        // GET: Predefine
        public ActionResult Index()
        {


            return View();
        }

        public JsonResult GetGeneralTypes([DataSourceRequest] DataSourceRequest request)
        {

            List<GeneralDefinition> genDef = new List<GeneralDefinition>();
            genDef.Add(new GeneralDefinition(typeof(TaskType).Name));
            genDef.Add(new GeneralDefinition(typeof(StateType).Name));
            genDef.Add(new GeneralDefinition(typeof(PrivacyType).Name));
            genDef.Add(new GeneralDefinition(typeof(PriorityType).Name));
            genDef.Add(new GeneralDefinition(typeof(ResultType).Name));
            genDef.Add(new GeneralDefinition(typeof(Title).Name));



            return Json(genDef.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTypeList(string tName)
        {
            string viewName = tName + "s";
            return PartialView(viewName);
        }


        public ActionResult TaskTypes()
        {
          
            return View();
        }

        public ActionResult TaskTypes_Read([DataSourceRequest] DataSourceRequest request)
        {
            List<TaskType> tts = GeneralDefinitionsServiceProxy.GetTaskTypes();
            return Json(tts.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TaskTypes_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<TaskType> model)
        {
           

            if (model != null && ModelState.IsValid)
            {


                GeneralDefinitionsServiceProxy.UpdateTaskTypes(model);

            }

            
            return Json(model.ToDataSourceResult(request, ModelState));
        }
      
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TaskTypes_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<TaskType> model)
        {

           

            if (model != null && ModelState.IsValid)
            {
                model.ForEach(x => x.MarkAsModified());
                GeneralDefinitionsServiceProxy.UpdateTaskTypes(model);

            }

            return Json(model.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult TaskTypes_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<TaskType> model)
        {


            if (model != null && ModelState.IsValid)
            {

                model.ForEach(x => x.MarkAsDeleted());
                GeneralDefinitionsServiceProxy.UpdateTaskTypes(model);

            }

            return Json(model.ToDataSourceResult(request, ModelState));
        }

        

        public ActionResult StateTypes()
        {
            return View();
        }

        public ActionResult StateTypes_Read([DataSourceRequest] DataSourceRequest request)
        {
            List<StateType> tts = GeneralDefinitionsServiceProxy.GetStateTypes();
          
            return Json(tts.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StateTypes_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<StateType> model)
        {

            
            
                 
            
            if (model != null && ModelState.IsValid)
            {


                GeneralDefinitionsServiceProxy.UpdateStateTypes(model);

            }

            // List<StateType> tts = GeneralDefinitionsServiceProxy.GetStateTypes();
            return Json(model.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StateTypes_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<StateType> model)
        {



            if (model != null && ModelState.IsValid)
            {
                model.ForEach(x => x.MarkAsModified());
                GeneralDefinitionsServiceProxy.UpdateStateTypes(model);

            }

           

            return Json(model.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StateTypes_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<StateType> model)
        {


            if (model != null && ModelState.IsValid)
            {

                model.ForEach(x => x.MarkAsDeleted());
                GeneralDefinitionsServiceProxy.UpdateStateTypes(model);

            }

            return Json(model.ToDataSourceResult(request, ModelState));
        }






        public ActionResult PrivacyTypes()
        {
            return View();
        }

        public ActionResult PrivacyTypes_Read([DataSourceRequest] DataSourceRequest request)
        {
            List<PrivacyType> tts = GeneralDefinitionsServiceProxy.GetPrivacyTypes();

            return Json(tts.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PrivacyTypes_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<PrivacyType> model)
        {





            if (model != null && ModelState.IsValid)
            {


                GeneralDefinitionsServiceProxy.UpdatePrivacyTypes(model);

            }

            // List<StateType> tts = GeneralDefinitionsServiceProxy.GetStateTypes();
            return Json(model.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PrivacyTypes_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<PrivacyType> model)
        {



            if (model != null && ModelState.IsValid)
            {
                model.ForEach(x => x.MarkAsModified());
                GeneralDefinitionsServiceProxy.UpdatePrivacyTypes(model);

            }



            return Json(model.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PrivacyTypes_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<PrivacyType> model)
        {


            if (model != null && ModelState.IsValid)
            {

                model.ForEach(x => x.MarkAsDeleted());
                GeneralDefinitionsServiceProxy.UpdatePrivacyTypes(model);

            }

            return Json(model.ToDataSourceResult(request, ModelState));
        }


        public ActionResult PriorityTypes()
        {
            return View();
        }

        public ActionResult PriorityTypes_Read([DataSourceRequest] DataSourceRequest request)
        {
            List<PriorityType> tts = GeneralDefinitionsServiceProxy.GetPriortyTypes();

            return Json(tts.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PriorityTypes_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<PriorityType> model)
        {





            if (model != null && ModelState.IsValid)
            {


                GeneralDefinitionsServiceProxy.UpdatePriorityTypes(model);

            }

            // List<StateType> tts = GeneralDefinitionsServiceProxy.GetStateTypes();
            return Json(model.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PriorityTypes_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<PriorityType> model)
        {



            if (model != null && ModelState.IsValid)
            {
                model.ForEach(x => x.MarkAsModified());
                GeneralDefinitionsServiceProxy.UpdatePriorityTypes(model);

            }



            return Json(model.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PriorityTypes_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<PriorityType> model)
        {


            if (model != null && ModelState.IsValid)
            {

                model.ForEach(x => x.MarkAsDeleted());
                GeneralDefinitionsServiceProxy.UpdatePriorityTypes(model);

            }

            return Json(model.ToDataSourceResult(request, ModelState));
        }


        public ActionResult ResultTypes()
        {
            return View();
        }


        public ActionResult  ResultTypes_Read([DataSourceRequest] DataSourceRequest request)
        {
            List< ResultType> tts = GeneralDefinitionsServiceProxy.GetResultTypes();

            return Json(tts.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ResultTypes_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<ResultType> model)
        {





            if (model != null && ModelState.IsValid)
            {


                GeneralDefinitionsServiceProxy.UpdateResultTypes(model);

            }

            // List<StateType> tts = GeneralDefinitionsServiceProxy.GetStateTypes();
            return Json(model.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ResultTypes_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<ResultType> model)
        {



            if (model != null && ModelState.IsValid)
            {
                model.ForEach(x => x.MarkAsModified());
                GeneralDefinitionsServiceProxy.UpdateResultTypes(model);

            }



            return Json(model.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ResultTypes_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<ResultType> model)
        {


            if (model != null && ModelState.IsValid)
            {

                model.ForEach(x => x.MarkAsDeleted());
                GeneralDefinitionsServiceProxy.UpdateResultTypes(model);

            }

            return Json(model.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Titles()
        {
            return View();
        }


        public ActionResult Titles_Read([DataSourceRequest] DataSourceRequest request)
        {
            List<Title> tts = GeneralDefinitionsServiceProxy.GetTitles();

            return Json(tts.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Titles_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<Title> model)
        {





            if (model != null && ModelState.IsValid)
            {


                GeneralDefinitionsServiceProxy.UpdateTitles(model);

            }

            // List<StateType> tts = GeneralDefinitionsServiceProxy.GetStateTypes();
            return Json(model.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Titles_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<Title> model)
        {



            if (model != null && ModelState.IsValid)
            {
                model.ForEach(x => x.MarkAsModified());
                GeneralDefinitionsServiceProxy.UpdateTitles(model);

            }



            return Json(model.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Titles_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<Title> model)
        {


            if (model != null && ModelState.IsValid)
            {

                model.ForEach(x => x.MarkAsDeleted());
                GeneralDefinitionsServiceProxy.UpdateTitles(model);

            }

            return Json(model.ToDataSourceResult(request, ModelState));
        }




    }
}