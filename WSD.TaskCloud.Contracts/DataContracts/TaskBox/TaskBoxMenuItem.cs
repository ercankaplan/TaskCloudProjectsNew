using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.DataContracts.TaskBox
{
    [DataContract]
    public class TaskBoxMenuItem
    {
        public TaskBoxMenuItem()
        {
            SubTaskBoxMenuItem = new List<TaskBoxMenuItem>();
        }

        [DataMember]
        public List<TaskBoxMenuItem> SubTaskBoxMenuItem { get; set; }

        [DataMember]
        public byte TaskTypeID { get; set; }

        [DataMember]
        public byte? UpperTaskTypeID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int UnreadCount { get; set; }

        [DataMember]
        public int TotalCount { get; set; }

        [DataMember]
        public int Order { get; set; }

        [DataMember]
        public string Icon { get; set; }

        [DataMember]
        public string ColorCode { get; set; }
    }
}
