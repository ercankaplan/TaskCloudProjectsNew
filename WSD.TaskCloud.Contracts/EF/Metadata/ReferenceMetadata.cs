using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WSD.TaskCloud.Contracts.DataContracts.Task;

namespace WSD.TaskCloud.Contracts.EF
{
   

    public partial class Reference
    {
        
        [DataMember]
        [Display(Name ="AdSoyad")]
        public string FullName { get {

                return  this.FirstName +" "+ LastName;

            }
            set { }
        }


        [DataMember]
        [Display(Name = "Dosya")]
        public AttachedFile AttachedReferenceFile { get; set; }

        [Display(Name = "Dosya Ekleri")]
        [DataMember]
        public List<Attachment> Attachments { get; set; }

        [DataMember]
        public bool IsVisible { get; set; }
    }
}
