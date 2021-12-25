using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Contracts.ServiceContracts;

namespace WSD.TaskCloud.WcfServices.Implementation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CacheService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CacheService.svc or CacheService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    internal class CacheService : ServiceBase, ICacheService
    {
        public List<Department> GetDepartments()
        {
            return GetCacheItem<Department>();
        }

        public List<PriorityType> GetPriorityTypes()
        {
            return GetCacheItem<PriorityType>();
        }

        public List<PrivacyType> GetPrivacyTypes()
        {
            return GetCacheItem<PrivacyType>();
        }

        public List<Profession> GetProfessions()
        {
            return GetCacheItem<Profession>();
        }

        public List<ResultType> GetResultTypes()
        {
            return GetCacheItem<ResultType>();
        }

        public List<StateType> GetStateTypes()
        {
            return GetCacheItem<StateType>();
        }

        public List<TaskType> GetTaskTypes()
        {
            return GetCacheItem<TaskType>();
        }

        public List<Role> GetRoles()
        {
            return GetCacheItem<Role>();
        }

        public List<Title> GetTitles()
        {
            return GetCacheItem<Title>();
        }

        public List<Reference> GetReferences()
        {
            return GetCacheItem<Reference>();
        }

        public List<TaskBy> GetTaskBys()
        {
            return GetCacheItem<TaskBy>();
        }

        

    }
}
