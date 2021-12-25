using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WSD.TaskCloud.Contracts.EF;

namespace WSD.TaskCloud.Contracts.ServiceContracts
{
    [ServiceContract(Namespace = Namespaces.ServiceContractNS)]
    public interface IAuthenticationService
    {
        [OperationContract]
        [FaultContract(typeof(ExceptionDetail))]
        bool AuthenticateUser(string userName, string password);

     
    }
}
