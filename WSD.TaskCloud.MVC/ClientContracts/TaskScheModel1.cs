using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WSD.TaskCloud.MVC.ClientContracts
{

   
    public class TaskScheModel1 : ISchedulerEvent
    {
        
        public string Title { get; set; }
       
        public string Description { get; set; }
       
        public bool IsAllDay { get; set; }
       
        public DateTime Start { get; set; }
       
        public DateTime End { get; set; }
       
        public string StartTimezone { get; set; }
       
        public string EndTimezone { get; set; }
       
        public string RecurrenceRule { get; set; }
      
        public string RecurrenceException { get; set; }

       
        public System.Guid TaskID { get; set; }

       
        public Nullable<System.Guid> UpperTaskID { get; set; }

       
        public string Subject { get; set; }

       
        public string Summary { get; set; }

        
        public Nullable<System.DateTime> StartDate { get; set; }

        
        public Nullable<System.DateTime> Deadline { get; set; }

       
        public Nullable<System.DateTime> FinishDate { get; set; }

      
        public byte TypeID { get; set; }

      
        public byte StateID { get; set; }

       
        public byte PrivacyID { get; set; }

       
        public byte PriorityID { get; set; }

      
        public Nullable<byte> ResultID { get; set; }

       
        public int UserRoleID { get; set; }

      
        public int UserID { get; set; }

        
        public System.DateTime Optime { get; set; }
    }


}