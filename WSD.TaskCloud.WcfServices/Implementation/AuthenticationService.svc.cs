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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthenticationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthenticationService.svc or AuthenticationService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    internal class AuthenticationService : ServiceBase, IAuthenticationService
    {

        public bool AuthenticateUser(string userName, string password)
        {
            try
            {
                return BsFactory<BsAuthentication>.Instance(TaskCloudContext).AuthenticateUser(userName, password);
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
