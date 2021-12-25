using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.DataContracts.Task
{
    [DataContract]
    public class TaskScheModel: ISchedulerEvent
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public bool IsAllDay { get; set; }
        [DataMember]
        public DateTime Start { get; set; }
        [DataMember]
        public DateTime End { get; set; }
        [DataMember]
        public string StartTimezone { get; set; }
        [DataMember]
        public string EndTimezone { get; set; }
        [DataMember]
        public string RecurrenceRule { get; set; }
        [DataMember]
        public string RecurrenceException { get; set; }
        
        [DataMember]
        public System.Guid TaskID { get; set; }

        [DataMember]
        public Nullable<System.Guid> UpperTaskID { get; set; }

        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public string Summary { get; set; }

        [DataMember]
        public Nullable<System.DateTime> StartDate { get; set; }

        [DataMember]
        public Nullable<System.DateTime> Deadline { get; set; }

        [DataMember]
        public Nullable<System.DateTime> FinishDate { get; set; }

        [DataMember]
        public byte TypeID { get; set; }

        [DataMember]
        public byte StateID { get; set; }

        [DataMember]
        public byte PrivacyID { get; set; }

        [DataMember]
        public byte PriorityID { get; set; }

        [DataMember]
        public Nullable<byte> ResultID { get; set; }

        [DataMember]
        public int UserRoleID { get; set; }

        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public System.DateTime Optime { get; set; }
    }


}
