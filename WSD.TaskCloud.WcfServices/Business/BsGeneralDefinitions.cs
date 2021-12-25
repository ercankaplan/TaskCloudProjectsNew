using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Data;

namespace WSD.TaskCloud.WcfServices.Business
{
    internal class BsGeneralDefinitions : BusinessBase
    {

        public List<Department> GetDepartments()
        {

            return TaskCloudContext.Department.ToList();

        }

        public List<TaskType> GetTaskTypes()
        {
            return TaskCloudContext.TaskType.ToList();
        }
        public void UpdateTaskTypes(List<TaskType> taskTypes)
        {
            foreach (var item in taskTypes)
            {
      
                TaskCloudContext.TaskType.ApplyChanges(item);
                TaskCloudContext.SaveChanges();
            }
          
            

        }

        public List<StateType> GetStateTypes()
        {
            return TaskCloudContext.StateType.ToList();
        }

        public void UpdateStateTypes(List<StateType> stateTypes)
        {
            foreach (var item in stateTypes)
            {
                TaskCloudContext.StateType.ApplyChanges(item);
                TaskCloudContext.SaveChanges();
            }
            
        }



        public List<PrivacyType> GetPrivacyTypes()
        {
            return TaskCloudContext.PrivacyType.ToList();
        }

        public void UpdatePrivacyTypes(List<PrivacyType> privacyTypes)
        {
            foreach (var item in privacyTypes)
            {
                TaskCloudContext.PrivacyType.ApplyChanges(item);
                TaskCloudContext.SaveChanges();
            }

        }

        public List<PriorityType> GetPriortyTypes()
        {
            return TaskCloudContext.PriorityType.ToList();
        }


        public void UpdatePriorityTypes(List<PriorityType> priorityTypes)
        {
            foreach (var item in priorityTypes)
            {
                TaskCloudContext.PriorityType.ApplyChanges(item);
                TaskCloudContext.SaveChanges();
            }

        }

        public List<ResultType> GetResultTypes()
        {
            return TaskCloudContext.ResultType.ToList();
        }

        public void UpdateResultTypes(List<ResultType> resultTypes)
        {
            foreach (var item in resultTypes)
            {
                TaskCloudContext.ResultType.ApplyChanges(item);
                TaskCloudContext.SaveChanges();
            }

        }


        public List<Role> GetRoles()
        {
            return TaskCloudContext.Role.ToList();
        }

        public void UpdateRoles(List<Role> roles)
        {
            foreach (var item in roles)
            {
                TaskCloudContext.Role.ApplyChanges(item);
                TaskCloudContext.SaveChanges();
            }
        }

        public List<Title> GetTitles()
        {
            return TaskCloudContext.Title.ToList();
        }

        public void UpdateTitles(List<Title> roles)
        {
            foreach (var item in roles)
            {
                TaskCloudContext.Title.ApplyChanges(item);
                TaskCloudContext.SaveChanges();
            }
        }
    }
}