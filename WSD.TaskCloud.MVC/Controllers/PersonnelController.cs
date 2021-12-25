using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSD.TaskCloud.Contracts.DataContracts.Personel;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.MVC.HelperClasses;
using WSD.TaskCloud.MVC.Models;

namespace WSD.TaskCloud.MVC.Controllers
{
    public class PersonnelController:BaseController
    {

        public ActionResult Personnels()
        {
            return View();

        }

        public ActionResult Personnels_Read([DataSourceRequest] DataSourceRequest request)
        {
            List<Personnel> tts = TaskServiceProxy.GetPersonnelsByDepartmentID(CurrentUser.Role.DepartmentID);

            return Json(tts.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult PersonnelAddNew(PersonnelRequest model)
        {
            if (model != null)
            {
                TaskServiceProxy.SaveNewPersonnel(model);

                return Content(string.Format("<script>ShowMessage('{0}','{1}');RefreshGrid();</script>", "Personel kaydedildi", (byte)ClientContracts.EnumMessageType.Info));
            }
            else
            {
                return Content(string.Format("<script>ShowMessage('{0}','{1}');</script>", "Girilen bilgilerde hata var", (byte)ClientContracts.EnumMessageType.Warning));


            }

            return Content(string.Empty);
        }



        public ActionResult PersonelUpdatePopup(string ProfessionNumber)
        {

            Personnel currentPer = TaskServiceProxy.GetPersonnelBySicilNo(ProfessionNumber);
            PersonnelRequest request = new PersonnelRequest()
            {
                Address2 = currentPer.Address,
                DepartmentID2 = currentPer.DepartmentID,
                TitleID2 = currentPer.TitleID,
                Email2 = currentPer.Email,
                FirstName2 = currentPer.FirstName,
                LastName2 = currentPer.LastName,
                Mobile2 = currentPer.Mobile,
                Phone2 = currentPer.Phone,
                ProfessionNumber2 = currentPer.ProfessionNumber,
                PersonnelID2 = currentPer.PersonnelID
            };
            return PartialView(request);
        }
        [HttpPost]
        public ActionResult PersonelUpdate(PersonnelRequest Model)
        {
            Personnel upModel = new Personnel();
            try
            {
                upModel.Address = Model.Address2;
                upModel.FirstName = Model.FirstName2;
                upModel.LastName = Model.LastName2;
                upModel.PersonnelID = Model.PersonnelID2;
                upModel.DepartmentID = Model.DepartmentID2.Value;
                upModel.TitleID = Model.TitleID2;
                upModel.Email = Model.Email2;
                upModel.Mobile = Model.Mobile2;
                upModel.Phone = Model.Phone2;
                upModel.ProfessionNumber = Model.ProfessionNumber2;
                TaskServiceProxy.UpdatePersonel(upModel);
                return Content(string.Format("<script>$('#contentWND').data('kendoWindow').close();ShowMessage('{0}','{1}');RefreshGrid();</script>", "Personel Güncellendi", (byte)ClientContracts.EnumMessageType.Info));
            }
            catch
            {
                return Content(string.Format("<script>ShowMessage('{0}','{1}');RefreshGrid();</script>", "Hata oluştu", (byte)ClientContracts.EnumMessageType.Info));
            }
        }


    }
}