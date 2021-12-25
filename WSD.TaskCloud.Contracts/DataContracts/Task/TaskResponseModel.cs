using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.DataContracts.Task
{
    [DataContract]
    public class TaskResponseModel
    {


        [DataMember]
        public Guid TaskRequestID { get; set; }


        [DataMember]
        [Display(Name = "Cevap")]
        public string ResponseDescription { get; set; }

        [DataMember]
        [Display(Name = "Konu", Order = 8)]
        public string Subject { get; set; }

        [DataMember]
        [Display(Name = "Cevap Ekleri")]
        public List<AttachedFile> ResponseAttachedFiles { get; set; }

        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public int UserRoleID { get; set; }

        [DataMember]
        public string CurrentUserName { get; set; }

      
    }
}
