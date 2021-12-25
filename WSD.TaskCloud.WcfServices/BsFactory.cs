using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Data;
using WSD.TaskCloud.WcfServices.Business;

namespace WSD.TaskCloud.WcfServices
{
    internal static class BsFactory<T> where T : BusinessBase, new()
    {
        public static T Instance(TaskCloudEntities ctx)
        {
            T instance = new T();
            instance.TaskCloudContext = ctx;
            return instance;
        }
    }
}