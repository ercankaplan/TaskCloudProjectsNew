using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Contracts.DataContracts.Personel;
using WSD.TaskCloud.Contracts.DataContracts.Referans;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Data;

namespace WSD.TaskCloud.WcfServices.Business
{
    internal class BsReference:BusinessBase
    {
        public List<Reference> GetReferenceAll()
        {
            List<Reference> result = TaskCloudContext.Reference.ToList();

            return result;
        }

        public Reference GetReferenceByID(int refID)
        {
            return TaskCloudContext.Reference.Where(x => x.ReferenceID == refID).SingleOrDefault();
        }

        public void UpdateReferences(List<Reference> references)
        {
            foreach (var item in references)
            {

                TaskCloudContext.Reference.ApplyChanges(item);
                TaskCloudContext.SaveChanges();
            }
        }

        public void SaveNewReference(ReferenceRequest request)
        {

            Reference currentReference = TaskCloudContext.Reference.Where(o => o.FirstName.Equals(request.FirstName) && o.LastName.Equals(request.LastName) && o.TitleID == request.TitleID).SingleOrDefault();

            if (currentReference != null)
                throw new ApplicationException("Referans kaydı mevcut");

            Reference newReference = new Reference()
            {
                Comment = request.Comment,
                FirstName = request.FirstName,
                IsActive = true,
                LastName = request.LastName,
                Optime = DateTime.Now,
                OpUserID = request.OpUserID,
                TitleID = request.TitleID
            };

            TaskCloudContext.Reference.AddObject(newReference);
            TaskCloudContext.SaveChanges();
        }

        public List<Personnel> GetPersonnelsByDepartmentID(int DepartmentID)
        {
            //Todo : alt deparmanlarda gelmeli
            return TaskCloudContext.Personnel.ToList();//.Where(x => x.DepartmentID == DepartmentID).ToList();//şimdilik tümü gelsin.
        }

        public List<TaskTemplate> GetUserTemplate(int UserID, int typeID)
        {

            List<TaskTemplate> result = TaskCloudContext.TaskTemplate.Where(x => x.UserID == UserID && x.TaskTypeID == typeID).ToList();

            return result;

        }
    }
}