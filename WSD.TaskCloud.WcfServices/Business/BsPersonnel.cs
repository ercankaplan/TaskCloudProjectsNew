using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Data;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Contracts.DataContracts.Personel;

namespace WSD.TaskCloud.WcfServices.Business
{
    internal class BsPersonnel : BusinessBase
    {

        public void SaveNewPersonnel(PersonnelRequest request)
        {

            Personnel currentPersonnel = TaskCloudContext.Personnel.Where(o => o.FirstName.Equals(request.FirstName) && o.LastName.Equals(request.LastName) && o.ProfessionNumber == request.ProfessionNumber).SingleOrDefault();

            if (currentPersonnel != null)
                throw new ApplicationException("Referans kaydı mevcut");

            Personnel newPersonnel = new Personnel()
            {

                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                ProfessionNumber = request.ProfessionNumber,
                DepartmentID = request.DepartmentID.HasValue ? request.DepartmentID.Value : 0,
                TitleID = request.TitleID,
                Phone = request.Phone,
                Mobile = request.Mobile,
                Email = request.Email
            };

            TaskCloudContext.Personnel.AddObject(newPersonnel);
            TaskCloudContext.SaveChanges();
        }

        public Personnel GetPersonnelBySicilNo(string sicilNo)
        {

            Personnel oPersonnel = TaskCloudContext.Personnel.Where(o => o.ProfessionNumber == sicilNo).SingleOrDefault();

            return oPersonnel;

        }

        public void SaveNewPersonnel(Personnel newPersonnel)
        {

            TaskCloudContext.Personnel.AddObject(newPersonnel);

        }
        public void UpdatePersonel(Personnel model)
        {
            Personnel selected = TaskCloudContext.Personnel.Where(i => i.PersonnelID == model.PersonnelID).FirstOrDefault();
            selected.Address = model.Address;
            selected.FirstName = model.FirstName;
            selected.LastName = model.LastName;
            selected.DepartmentID = model.DepartmentID;
            selected.TitleID = model.TitleID;
            selected.Email = model.Email;
            selected.Mobile = model.Mobile;
            selected.Phone = model.Phone;
            selected.ProfessionNumber = model.ProfessionNumber;
            TaskCloudContext.Personnel.ApplyChanges(selected);
            TaskCloudContext.SaveChanges();
        }

        public Personnel GetPersonnelByProfessionNum(string ProfessionNum)
        {
            Personnel result = TaskCloudContext.Personnel.Where(x => x.ProfessionNumber == ProfessionNum).SingleOrDefault();

            return result;

        }
    }
}