using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.DataContracts.TaskBox
{
  


    [DataContract]
    public class MyTaskFilter
    {
        [DataMember]
        public int UserID { get; set; }

        [DataMember]
        public int UserRoleID { get; set; }

        [DataMember]
        public DateTime Optime { get; set; }


        [DataMember]
        [Display(Name = "Talep Tipi")]
        public int TaskTypeID { get; set; }


        [DataMember]
        [Display(Name = "Sonuç")]
        public int TaskResult { get; set; }

        [DataMember]
        public int TaskPriority { get; set; }

        [DataMember]
        public int TaskPrivacy { get; set; }

        [DataMember]
        [Display(Name ="Konu")]
        public string Subject { get; set; }

        [DataMember]
        [Display(Name = "Talep")]
        public string Description { get; set; }

    }
}
