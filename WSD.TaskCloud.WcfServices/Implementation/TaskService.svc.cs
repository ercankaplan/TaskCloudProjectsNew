using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WSD.TaskCloud.Contracts.DataContracts.Personel;
using WSD.TaskCloud.Contracts.DataContracts.Referans;
using WSD.TaskCloud.Contracts.DataContracts.Task;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Contracts.ServiceContracts;
using WSD.TaskCloud.WcfServices.Business;

namespace WSD.TaskCloud.WcfServices.Implementation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TaskService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TaskService.svc or TaskService.svc.cs at the Solution Explorer and start debugging.
    internal class TaskService : ServiceBase, ITaskService
    {
        public List<Reference> GetReferenceAll()
        {
            try
            {

                return BsFactory<BsReference>.Instance(TaskCloudContext).GetReferenceAll();

            }
            catch (ApplicationException ax)
            {
                throw ax;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Reference GetReferenceByID(int refID)
        {
            try
            {

                return BsFactory<BsReference>.Instance(TaskCloudContext).GetReferenceByID(refID);

            }
            catch (ApplicationException ax)
            {
                throw ax;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void UpdateReferences(List<Reference> references)
        {


            try
            {
                BeginTransaction();

                BsFactory<BsReference>.Instance(TaskCloudContext).UpdateReferences(references);

                CommitTransaction();
            }
            catch (ApplicationException ax)
            {
                RollbackTransaction();
                throw ax;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }
        }

        public void SaveNewReference(ReferenceRequest request)
        {
            try
            {
                BeginTransaction();

                BsFactory<BsReference>.Instance(TaskCloudContext).SaveNewReference(request);

                CommitTransaction();
            }
            catch (ApplicationException ax)
            {
                RollbackTransaction();
                throw ax;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }
        }


      

        public void SaveNewPersonnel(PersonnelRequest request)
        {
            try
            {
                BeginTransaction();

                BsFactory<BsPersonnel>.Instance(TaskCloudContext).SaveNewPersonnel(request);

                CommitTransaction();
            }
            catch (ApplicationException ax)
            {
                RollbackTransaction();
                throw ax;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }
        }

        public List<Personnel> GetPersonnelsByDepartmentID(int DepartmentID)
        {

            try
            {

                return BsFactory<BsReference>.Instance(TaskCloudContext).GetPersonnelsByDepartmentID(DepartmentID);

            }
            catch (ApplicationException ax)
            {
                throw ax;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Personnel GetPersonnelBySicilNo(string sicilNo)
        {

            try
            {

                return BsFactory<BsPersonnel>.Instance(TaskCloudContext).GetPersonnelBySicilNo(sicilNo);

            }
            catch (ApplicationException ax)
            {
                throw ax;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TaskTemplate> GetUserTemplate(int UserID, int typeID)
        {
            try
            {

                return BsFactory<BsReference>.Instance(TaskCloudContext).GetUserTemplate(UserID, typeID);

            }
            catch (ApplicationException ax)
            {
                throw ax;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Department> GetDepartmentUserByRoleID(int nUserRoleID)
        {
            try
            {

                return BsFactory<BsAccount>.Instance(TaskCloudContext).GetDepartmentUserByRoleID(nUserRoleID);

            }
            catch (ApplicationException ax)
            {
                throw ax;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Department> GetDepartmentUsersByUpperDepartmentID(int nUpperDepartmentID, int nDepartmentID)
        {
            try
            {

                return BsFactory<BsAccount>.Instance(TaskCloudContext).GetDepartmentUsersByUpperDepartmentID(nUpperDepartmentID,nDepartmentID);

            }
            catch (ApplicationException ax)
            {
                throw ax;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SaveNewTask(TaskRequestModel request)
        {
            try
            {
                BeginTransaction();

                BsFactory<BsTask>.Instance(TaskCloudContext).SaveNewTask(request);

                CommitTransaction();
            }
            catch (ApplicationException ax)
            {
                RollbackTransaction();
                throw ax;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }
        }

        public void SaveTaskRespose(TaskResponseModel request)
        {
            try
            {
                BeginTransaction();

                BsFactory<BsTask>.Instance(TaskCloudContext).SaveTaskRespose(request);

                CommitTransaction();
            }
            catch (ApplicationException ax)
            {
                RollbackTransaction();
                throw ax;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }

        }

        public void SaveForwardTask(TaskForwardModel request)
        {
            try
            {
                BeginTransaction();

                BsFactory<BsTask>.Instance(TaskCloudContext).SaveForwardTask(request);

                CommitTransaction();
            }
            catch (ApplicationException ax)
            {
                RollbackTransaction();
                throw ax;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }

        }

       

        public void UpdatePersonel(Personnel model)
        {


            try
            {
                BeginTransaction();

                BsFactory<BsPersonnel>.Instance(TaskCloudContext).UpdatePersonel(model);

                CommitTransaction();
            }
            catch (ApplicationException ax)
            {
                RollbackTransaction();
                throw ax;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }
        }

        public List<Task> SearchTask(string desc)
        {


            try
            {
                BeginTransaction();

                List<Task> result =BsFactory<BsTask>.Instance(TaskCloudContext).SearchTask(desc);

                CommitTransaction();
                return result;
            }
            catch (ApplicationException ax)
            {
                RollbackTransaction();
                throw ax;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }
        }

       
    }
}
