using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.DataContracts.Task
{

    [DataContract]
    public class TaskRequestFilter
    {
        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public int UserRoleID { get; set; }

        [DataMember]
        public DateTime Optime { get; set; }


        [DataMember]
        public byte TaskTypeID { get; set; }

  

    }
}
