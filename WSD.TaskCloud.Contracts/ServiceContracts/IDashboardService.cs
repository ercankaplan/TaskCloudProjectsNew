using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using WSD.TaskCloud.Contracts.DataContracts.Dashboard;
using WSD.TaskCloud.Contracts.EF;

namespace WSD.TaskCloud.Contracts.ServiceContracts
{
  
     [ServiceContract(Namespace = Namespaces.ServiceContractNS)]
    public interface IDashboardService
    {

        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        List<Task> GetTaskList(DashboardTaskFilter filter);
    }
}
