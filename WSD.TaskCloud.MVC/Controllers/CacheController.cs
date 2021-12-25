using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.MVC.HelperClasses;

namespace WSD.TaskCloud.MVC.Controllers
{
    public class CacheController :BaseController
    {

        public ContentResult GetTaskTypeText(string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(key))
            {
                int nKey = Convert.ToInt32(key);
                result = CacheHelper.GetCacheItem<TaskType>().Where(x => x.TaskTypeID == nKey).Single().Name;
            }
            return Content(result);
        }

        public ContentResult GetTaskStateText(string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(key))
            {
                int nKey = Convert.ToInt32(key);
                result = CacheHelper.GetCacheItem<StateType>().Where(x => x.StateTypeID == nKey).Single().Name;
            }
            return Content(result);
        }

        public ContentResult GetTaskResultText(string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(key))
            {
                int nKey = Convert.ToInt32(key);
                result = CacheHelper.GetCacheItem<ResultType>().Where(x => x.ResultTypeID == nKey).Single().Name;
            }
            return Content(result);
        }

        public ContentResult GetTitle(string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(key))
            {
                int nKey = Convert.ToInt32(key);
                if(nKey > 0)
                result = CacheHelper.GetCacheItem<Title>().Where(x=> x.TitleID == nKey).Single().Name;
            }
            return Content(result);
        }

        public ContentResult GetDepartment(string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(key))
            {
                int nKey = Convert.ToInt32(key);
                if (nKey > 0)
                    result = CacheHelper.GetCacheItem<Department>().Where(x => x.DepartmentID == nKey).Single().Name;
            }
            return Content(result);
        }

        public ContentResult GetPriority(string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(key))
            {
                int nKey = Convert.ToInt32(key);
                if (nKey > 0)
                    result = CacheHelper.GetCacheItem<PriorityType>().Where(x => x.PriorityTypeID == nKey).Single().Name;
            }
            return Content(result);
        }

        public ContentResult GetPrivacy(string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(key))
            {
                int nKey = Convert.ToInt32(key);
                if (nKey > 0)
                    result = CacheHelper.GetCacheItem<PrivacyType>().Where(x => x.PrivacyTypeID == nKey).Single().Name;
            }
            return Content(result);
        }

        public ContentResult GetBoolean(string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(key))
            {
                bool nKey = Convert.ToBoolean(key);
                if (nKey == true)
                    result = "Evet";
                else
                    result = "Hayır";

            }
            return Content(result);
        }

        public ContentResult GetReferenceTitleByID(string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(key))
            {
                int nKey = Convert.ToInt32(key);
                if (nKey > 0)
                    result = (from r in CacheHelper.GetCacheItem<Reference>()
                              join t in CacheHelper.GetCacheItem<Title>() on r.TitleID equals t.TitleID
                              where r.ReferenceID == nKey
                              select t).Single().Name;
            }
            return Content(result);

        }



     

    }
}