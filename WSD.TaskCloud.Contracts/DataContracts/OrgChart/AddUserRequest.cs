using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.DataContracts.OrgChart
{
   


    [DataContract]
    public class AddUserRequest
    {

        [DataMember]
        [Display(Name = "Çalıştığı Birim")]
        public int DepartmentID { get; set; }

        [DataMember]
        [Display(Name = "Pozisyon")]
        public int RoleID { get; set; }

        [DataMember]
        [Display(Name = "SicilNo")]
        public string RegistryNum { get; set; }


        [DataMember]
        [Display(Name = "Ad")]
        [Required(ErrorMessage ="Girilmesi Zorumlu Alan!")]
        public string FirstName { get; set; }


        [DataMember]
        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Girilmesi Zorumlu Alan!")]
        public string LastName { get; set; }

        [DataMember]
        [Display(Name = "Mobil")]
        [Required(ErrorMessage = "Girilmesi Zorumlu Alan!")]
        public string Mobile { get; set; }

        [DataMember]
        [Display(Name = "E-Posta")]
        [Required(ErrorMessage = "Girilmesi Zorumlu Alan!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Hatalı E-Mail Formatı")]
        public string Email { get; set; }

        [DataMember]
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Girilmesi Zorumlu Alan!")]
        public string UserName { get; set; }

        [DataMember]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Min 3 Max 20 Karakter Olabilir!!")]
        public string Password { get; set; }

        [DataMember]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Min 3 Max 30 Karakter Olabilir!!")]
        [Required(ErrorMessage = "Girilmesi Zorumlu Alan!")]
        [Display(Name = "Şifre")]
        public string PasswordField { get; set; }


        [DataMember]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Min 3 Max 30 Karakter Olabilir!!")]
        [Required(ErrorMessage = "Girilmesi Zorumlu Alan!")]
        [Display(Name = "Şifre Tekrar")]
        public string PasswordField2 { get; set; }

        [DataMember]
        public int OpUserID { get; set; }

        [DataMember]
        [Display(Name = "İmaj")]
        public byte[] Logo { get; set; }

        [DataMember]
        [Display(Name = "Kullanıcı Adı")]
        public string UsernameField { get; set; }

        [DataMember]
        [Display(Name = "İmza")]
        public byte[] SignImg { get; set; }
    }
}
