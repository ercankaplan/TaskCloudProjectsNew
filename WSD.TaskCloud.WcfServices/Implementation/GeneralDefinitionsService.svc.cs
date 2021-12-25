using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Contracts.ServiceContracts;
using WSD.TaskCloud.WcfServices.Business;

namespace WSD.TaskCloud.WcfServices.Implementation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GeneralDefinitionsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GeneralDefinitionsService.svc or GeneralDefinitionsService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    internal class GeneralDefinitionsService : ServiceBase, IGeneralDefinitionsService
    {
       
        public List<Department> GetDepartments()
        {
            try
            {

                return BsFactory<BsGeneralDefinitions>.Instance(TaskCloudContext).GetDepartments();

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

        public List<PriorityType> GetPriortyTypes()
        {
            try
            {

                return BsFactory<BsGeneralDefinitions>.Instance(TaskCloudContext).GetPriortyTypes();

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

        public void UpdatePriorityTypes(List<PriorityType> priorityTypes)
        {
            try
            {
                BeginTransaction();

                BsFactory<BsGeneralDefinitions>.Instance(TaskCloudContext).UpdatePriorityTypes(priorityTypes);

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

       

        public List<PrivacyType> GetPrivacyTypes()
        {
            try
            {

                return BsFactory<BsGeneralDefinitions>.Instance(TaskCloudContext).GetPrivacyTypes();

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

        public void UpdatePrivacyTypes(List<PrivacyType> privacyTypes)
        {
            try
            {
                BeginTransaction();

                BsFactory<BsGeneralDefinitions>.Instance(TaskCloudContext).UpdatePrivacyTypes(privacyTypes);

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

       

        public List<ResultType> GetResultTypes()
        {
            try
            {

                return BsFactory<BsGeneralDefinitions>.Instance(TaskCloudContext).GetResultTypes();

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

        public void UpdateResultTypes(List<ResultType> resultTypes)
        {
            try
            {
                BeginTransaction();

                BsFactory<BsGeneralDefinitions>.Instance(TaskCloudContext).UpdateResultTypes(resultTypes);

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

        

        public List<StateType> GetStateTypes()
        {
            try
            {

                return BsFactory<BsGeneralDefinitions>.Instance(TaskCloudContext).GetStateTypes();

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

        public void UpdateStateTypes(List<StateType> stateTypes)
        {
            try
            {
                BeginTransaction();

                BsFactory<BsGeneralDefinitions>.Instance(TaskCloudContext).UpdateStateTypes(stateTypes);

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

        public List<TaskType> GetTaskTypes()
        {
            try
            {

                return BsFactory<BsGeneralDefinitions>.Instance(TaskCloudContext).GetTaskTypes();

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

       

        public void UpdateTaskTypes(List<TaskType> taskTypes)
        {
            try
            {
                BeginTransaction();

                 BsFactory<BsGeneralDefinitions>.Instance(TaskCloudContext).UpdateTaskTypes(taskTypes);

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

        public List<Role> GetRoles()
        {
            try
            {

                return BsFactory<BsGeneralDefinitions>.Instance(TaskCloudContext).GetRoles();

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

        public void UpdateRoles(List<Role> roles)
        {
            try
            {
                BeginTransaction();

                BsFactory<BsGeneralDefinitions>.Instance(TaskCloudContext).UpdateRoles(roles);

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

        public List<Title> GetTitles()
        {
            try
            {

                return BsFactory<BsGeneralDefinitions>.Instance(TaskCloudContext).GetTitles();

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

        public void UpdateTitles(List<Title> titles)
        {
            try
            {
                BeginTransaction();

                BsFactory<BsGeneralDefinitions>.Instance(TaskCloudContext).UpdateTitles(titles);

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
    }
}
