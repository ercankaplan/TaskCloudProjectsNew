using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WSD.TaskCloud.Contracts.DataContracts.Dashboard;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Contracts.ServiceContracts;
using WSD.TaskCloud.WcfServices.Business;

namespace WSD.TaskCloud.WcfServices.Implementation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DashboardService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DashboardService.svc or DashboardService.svc.cs at the Solution Explorer and start debugging.
    internal class DashboardService :ServiceBase, IDashboardService
    {
       
        public List<Task> GetTaskList(DashboardTaskFilter filter)
        {
            try
            {

                return BsFactory<BsDashboard>.Instance(TaskCloudContext).GetTaskList(filter);

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

       
    }
}
