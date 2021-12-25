using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSD.TaskCloud.Contracts.DataContracts.Referans;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.MVC.HelperClasses;
using WSD.TaskCloud.MVC.Models;

namespace WSD.TaskCloud.MVC.Controllers
{
    public class ReferenceController:BaseController
    {

        public ActionResult References()
        {
            return View();

        }

        public ActionResult ReferenceAddNew()
        {

            return PartialView();

        }

        [HttpPost]
        public ActionResult ReferenceAddNew(ReferenceRequest model)
        {

            model.OpUserID = CurrentUser.UserID;
            TaskServiceProxy.SaveNewReference(model);

            return Content(string.Format("<script>ShowMessage('{0}','{1}');RefreshGrid();</script>", "Reference kaydedildi", (byte)ClientContracts.EnumMessageType.Info));

        }

        public ActionResult ReferenceUpdatePopup(int? refID)
        {

            if (!refID.HasValue)
                return Content("Referans seçilemedi");

            Reference currentRef = TaskServiceProxy.GetReferenceByID(refID.Value);

            Session["currentRef"] = currentRef;
            ReferenceRequest request = new ReferenceRequest()
            {
                Comment = currentRef.Comment,
                FirstName = currentRef.FirstName,
                IsActive = currentRef.IsActive,
                TitleID2 = currentRef.TitleID,
                LastName = currentRef.LastName,
            };
            // ViewData["UpdateTitleID"] = currentRef.TitleID;
            return PartialView(request);
        }
        [HttpPost]
        public ActionResult ReferenceUpdate(ReferenceRequest model)
        {

            try
            {
                Reference currentRef = Session["currentRef"] as Reference;

                if (currentRef == null)
                    return Content(string.Format("<script>ShowMessage('{0}','{1}');</script>", "Session Hatası", (byte)ClientContracts.EnumMessageType.Error));

                currentRef.Comment = model.Comment;
                currentRef.FirstName = model.FirstName;
                currentRef.IsActive = model.IsActive;
                currentRef.TitleID = model.TitleID2;
                currentRef.LastName = model.LastName;
                currentRef.OpUserID = CurrentUser.UserID;
                TaskServiceProxy.UpdateReference(currentRef);
                return Content("Success");
            }
            catch
            {
                return Content("Failure");
            }
        }



        public ActionResult References_Read([DataSourceRequest] DataSourceRequest request)
        {
            List<Reference> tts = TaskServiceProxy.GetReferenceAll();

            return Json(tts.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        /*
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult References_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<Reference> model)
        {





            if (model != null && ModelState.IsValid)
            {


                TaskServiceProxy.UpdateReferences(model);
               

            }
            else
                return Content("Girilen değerlerde hata var");

            // List<StateType> tts = GeneralDefinitionsServiceProxy.GetStateTypes();
            return Json(model.ToDataSourceResult(request, ModelState));
        }
          */

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult References_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<Reference> model)
        {



            if (model != null && ModelState.IsValid)
            {
                model.ForEach(x => x.MarkAsModified());
                TaskServiceProxy.UpdateReferences(model);

            }

            return Json(model.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult References_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]List<Reference> model)
        {


            if (model != null && ModelState.IsValid)
            {

                model.ForEach(x => x.MarkAsDeleted());
                TaskServiceProxy.UpdateReferences(model);

            }

            return Json(model.ToDataSourceResult(request, ModelState));
        }

    }
}