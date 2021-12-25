using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.DataContracts.Personel
{
    [DataContract]
    public class PersonnelRequest
    {
        [DataMember]
        public int PersonnelID{ get; set; }

        [DataMember]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        [Display(Name = "Ad")]
        public string FirstName{ get; set; }

        [DataMember]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        [Display(Name = "Soyad")]
        public string LastName{ get; set; }

        [DataMember]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        [Display(Name = "Sicil Numarası")]
        public string ProfessionNumber{ get; set; }

        [DataMember]
        [Display(Name = "Çalıştığı Birim")]
        public int? DepartmentID{ get; set; }

        [DataMember]
        [Display(Name = "Ünvanı")]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        public int TitleID { get; set; }

        [DataMember]
        [Display(Name = "Adres")]
        public string Address{ get; set; }

        [DataMember]
        [Display(Name = "Telefon")]
        public string Phone{ get; set; }

        [DataMember]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        [Display(Name = "Mobil")]
        public string Mobile{ get; set; }

        [DataMember]
        [Display(Name = "E-posta")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Hatalı E-Mail Formatı")]
        public string Email{ get; set; }



        [DataMember]
        public int PersonnelID2 { get; set; }

        [DataMember]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        [Display(Name = "Ad")]
        public string FirstName2 { get; set; }

        [DataMember]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        [Display(Name = "Soyad")]
        public string LastName2 { get; set; }

        [DataMember]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        [Display(Name = "Sicil Numarası")]
        public string ProfessionNumber2 { get; set; }

        [DataMember]
        [Display(Name = "Çalıştığı Birim")]
        public int? DepartmentID2 { get; set; }

        [DataMember]
        [Display(Name = "Adres")]
        public string Address2 { get; set; }

        [DataMember]
        [Display(Name = "Telefon")]
        public string Phone2 { get; set; }

        [DataMember]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        [Display(Name = "Mobil")]
        public string Mobile2 { get; set; }

        [DataMember]
        [Display(Name = "E-posta")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Hatalı E-Mail Formatı")]
        public string Email2 { get; set; }

        [DataMember]
        [Display(Name = "Ünvanı")]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        public int TitleID2 { get; set; }

    }
}
