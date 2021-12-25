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
    public class TaskForwardModel
    {


        [DataMember]
        public Guid UpperTaskID { get; set; }


        [DataMember]
        public Guid TaskRequestID { get; set; }

        [DataMember]
        public int TaskTypeID { get; set; }
        

        [DataMember]
        [Display(Name = "Cevap")]
        public string TaskDescription { get; set; }

        [DataMember]
        [Display(Name = "Konu", Order = 8)]
        public string Subject { get; set; }

        [DataMember]
        [Display(Name = "Ekler")]
        public List<AttachedFile> ForwardAttachedFiles { get; set; }

        [DataMember]
        [Display(Name = "Atanan Kullanıcılar")]
        public List<int> AtananKullanicilar { get; set; }

        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public int UserRoleID { get; set; }

        [DataMember]
        public string CurrentUserName { get; set; }


    }
}
