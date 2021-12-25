using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WSD.TaskCloud.Contracts.EF;

namespace WSD.TaskCloud.Contracts.DataContracts.Task
{
    [DataContract]
    public class TaskRequestModel
    {

        [DataMember]
        [Display(Name = "Ana Talep Tipi")]
        public byte BaseTaskTypeID { get; set; }

        [DataMember]
        [Display(Name = "Talep Tipi")]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        public byte TaskTypeID { get; set; }

   

        [DataMember]
        [Display(Name = "Referans Dosyası")]
        public AttachedFile ReferenceFile { get; set; }

        [DataMember]
        [Display(Name = "Öncelik")]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        public byte PriorityID { get; set; }

        [DataMember]
        [Display(Name = "Gizlilik")]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        public byte PrivacyID { get; set; }

        [DataMember]
        [Display(Name = "SicilNo")]
        public int SicilNo { get; set; }

        [DataMember]
        public Personnel IlgiliPersonel { get; set; }

        [DataMember]
        [Display(Name = "Talep")]
        public string TaskDescription { get; set; }

        [DataMember]
        [Display(Name = "Atanan Kullanıcılar")]
        public List<int> AtananKullanicilar { get; set; }

        [DataMember]
        [Display(Name = "Görevi Takip Edecekler")]
        public List<int> GorevinSahipleri { get; set; }

        [DataMember]
        public int OpUser { get; set; }

        [DataMember]
        [Display(Name = "Görev Ekleri")]
        public List<AttachedFile> TaskAttachedFiles { get; set; }

        [DataMember]
        [Display(Name = "Son Tarih", Order = 8)]
        public DateTime Deadline { get; set; }

        [DataMember]
        [Display(Name = "Başlangıç Tarih")]
        public DateTime StartDate { get; set; }

        [DataMember]
        public int UserRoleID { get; set; }

        [DataMember]
        public string CurrentUserName { get; set; }

        [DataMember]
        [Display(Name = "Konu", Order = 8)]
        public string Subject { get; set; }


        [DataMember]
        [Display(Name = "Template olarak kaydet")]
        public bool SaveAsTemplate { get; set; }

        [DataMember]
        [Display(Name = "Başlangıç Tarih-Saati")]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        public DateTime? MeetingStartDate { get; set; }

        [DataMember]
        [Display(Name = "Bitiş Tarih-Saati")]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        public DateTime? MeetingFinishDate { get; set; }

        [DataMember]
        [Display(Name = "Talep Kaynağı")]
        [Required(ErrorMessage = "\"{0}\" alanı zorunludur.")]
        public TaskSource TaskSourceData { get; set; }

        [DataMember]
        [Display(Name = "Aktarım Şekli")]
        public int ByID  { get; set; }

        [DataMember]
        public List<string> Pages { get; set; }
    }

}
