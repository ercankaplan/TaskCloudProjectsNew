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
    public class PersonnelReferenceRequest
    {
        [DataMember]
        [Display(Name = "Referans Kişi")]
        [Required(ErrorMessage = "Doldurulması Gerekli Alan")]
        public string AddReferenceID { get; set; }

        [DataMember]
        public int RefID { get; set; }


        [DataMember]
        [Display(Name = "Ünvan")]
        public int TitleID { get; set; }

        [DataMember]
        [Display(Name = "Ad")]
        public string FullName { get; set; }

        [DataMember]
        [Display(Name = "Dosya Adı")]
        [Required(ErrorMessage = "Dosya Eklenmelidir!")]
        public AttachedFile AttachedReferenceFile { get; set; }

        [DataMember]
        [Display(Name = "Dosya Adı")]
        public string AttachedFileName { get; set; }


        [DataMember]
        [Display(Name = "Görünsün")]
        public bool IsVisible { get; set; }

    }
}
