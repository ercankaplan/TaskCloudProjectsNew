using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.DataContracts.Referans
{
    [DataContract]
    public class ReferenceRequest
    {
        [DataMember]
        [Display(Name = "Ünvanı")]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        public int TitleID2 { get; set; }


        [DataMember]
        [Display(Name = "Ünvanı")]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        public int TitleID { get; set; }

        [DataMember]
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        public string FirstName { get; set; }

        [DataMember]
        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        public string LastName { get; set; }

        [DataMember]
        [Display(Name = "Açıklama")]
        public string Comment { get; set; }

        [DataMember]
        [Display(Name = "Aktif Mi")]
        public bool IsActive { get; set; }

        [DataMember]
        public int OpUserID { get; set; }


    }




}
