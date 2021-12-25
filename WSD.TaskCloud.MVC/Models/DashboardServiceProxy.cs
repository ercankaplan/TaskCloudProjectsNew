using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Contracts.DataContracts.Dashboard;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Contracts.ServiceContracts;
using WSD.TaskCloud.MVC.HelperClasses;

namespace WSD.TaskCloud.MVC.Models
{
   
     public static class DashboardServiceProxy
    {
        public static List<Task> GetTaskList(DashboardTaskFilter request)
        {

            List<Task> result = null;

            new ProxyHelper<IDashboardService>().Use(svcProxy =>
            {
                result = svcProxy.GetTaskList(request);


            }, WcfEndpoints.IDashboardService);


            return result;

        }
    }
}