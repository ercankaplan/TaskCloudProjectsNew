using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Contracts.ServiceContracts;

namespace WSD.TaskCloud.MVC.HelperClasses
{
    public static class CacheHelper
    {
        private static Dictionary<string, object> localCache;
        static CacheHelper()
        {
            localCache = new Dictionary<string, object>();

            new ProxyHelper<ICacheService>().Use(svcProxy =>
            {
               
                localCache.Add("PriorityType", svcProxy.GetPriorityTypes());
                localCache.Add("PrivacyType", svcProxy.GetPrivacyTypes());
                localCache.Add("ResultType", svcProxy.GetResultTypes());
                localCache.Add("StateType", svcProxy.GetStateTypes());
                localCache.Add("TaskType", svcProxy.GetTaskTypes());

                localCache.Add("Department", svcProxy.GetDepartments());
                localCache.Add("Role", svcProxy.GetRoles());
                localCache.Add("Title", svcProxy.GetTitles());

                localCache.Add("Reference", svcProxy.GetReferences());
                localCache.Add("TaskBy", svcProxy.GetTaskBys());

               


            }, WcfEndpoints.ICacheService);


        }

        public static List<T> GetCacheItem<T>()
        {
            return (List<T>) localCache[typeof(T).Name];
        }


    }
}