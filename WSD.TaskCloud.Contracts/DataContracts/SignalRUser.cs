using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.DataContracts
{
    public class SignalRUser
    {
        public string userID { get; set; }
        public string userName { get; set; }
        public string connectionID { get; set; }
    }
}
