using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.EF
{
    public partial class TaskType
    {
        public TaskType()
        {
            SubTypes = new List<TaskType>();
        }

        [DataMember]
        public List<TaskType> SubTypes  { get; set; }

        [DataMember]
        public int UnreadCount { get; set; }

        [DataMember]
        public int TotalCount { get; set; }


      
    }

    public class TaskTypeMetadata
    {
    }
}
