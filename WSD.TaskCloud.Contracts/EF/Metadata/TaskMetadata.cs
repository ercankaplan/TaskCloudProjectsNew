using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.EF
{


    [MetadataType(typeof(TaskMetadata))]
    public partial class Task
    {

        [Display(Name ="Tarih")]
        public string OptimeText
        {
            get
            {

                string val = string.Empty;

                DateTime haftaBasi = DateTime.Today;
                DateTime gecenHafta_Basi = DateTime.Today;
                DateTime ikiHaftaOnce_Basi = DateTime.Today;
                DateTime UcHaftaOnce_Basi = DateTime.Today;
                DateTime GecenAy_Basi = DateTime.Today;

                for (int i = 0; i < 7; i++)
                {
                    if (DateTime.Today.AddDays(-1 * i).DayOfWeek == DayOfWeek.Monday)
                        haftaBasi = DateTime.Today.AddDays(i);
                }

                gecenHafta_Basi = haftaBasi.AddDays(-7);
                ikiHaftaOnce_Basi = gecenHafta_Basi.AddDays(-7);
                UcHaftaOnce_Basi = ikiHaftaOnce_Basi.AddDays(-7);
                GecenAy_Basi = new DateTime(DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);

                if (this.Optime.ToShortDateString() == DateTime.Today.ToShortDateString())
                {
                    return "Bugün";
                }
                else if (this.Optime.ToShortDateString() == DateTime.Today.AddDays(-1).ToShortDateString())
                {
                    return "Dün";
                }
                else if (this.Optime >= haftaBasi)
                {
                    return this.Optime.DayOfWeek.ToString();
                }
                else if (this.Optime < haftaBasi && this.Optime >= gecenHafta_Basi)
                {
                    return "Geçen Hafta";
                }
                else if (this.Optime < gecenHafta_Basi && this.Optime >= ikiHaftaOnce_Basi)
                {
                    return "İki Hafta Önce";
                }
                else if (this.Optime < ikiHaftaOnce_Basi && this.Optime >= UcHaftaOnce_Basi)
                {
                    return "Üç Hafta Önce";
                }
                else if (this.Optime < UcHaftaOnce_Basi && this.Optime >= GecenAy_Basi)
                {
                    return "Geçen Ay";
                }
                else if (this.Optime < GecenAy_Basi)
                {
                    return "Daha Eski";
                }
                else
                    return val;

            }





        }

        [Display(Name = "Atanan")]
        public int AtananSayisi { get { return this.TaskRequest.Count(); } }

        [Display(Name = "Dosya Ekleri")]
        [DataMember]
        public List<Attachment> Attachments { get; set; }

        [Display(Name = "Personel Bilgisi")]
        [DataMember]
        public Personnel PersonelData { get; set; }

        [DataMember]
        public string UserSign { get; set; }

        [DataMember]
        public Task LegacyTask { get; set; }
    }
    public class TaskMetadata
    {

        [Display(Name = "Konu", Order = 1)]
        public object Subject;

        [Display(Name = "Özet", Order = 2)]
        public object Summary;

        [Display(Name = "Görev Tanımı", Order = 3)]
        public object Description;

        [Display(Name = "Başlangıç Tarihi", Order = 4)]
        public object StartDate;

        [Display(Name = "Son Tarih", Order = 5)]
        public object Deadline;

        [Display(Name = "Bitiş Tarihi", Order = 6)]
        public object FinishDate;

        [Display(Name = "Tür", Order = 7)]
        public object TypeID;

        [Display(Name = "Durum", Order = 8)]
        public object StateID;

        [Display(Name = "Sonuç", Order = 9)]
        public object ResultID;

        [Display(Name = "Öncelik", Order = 10)]
        public object PriorityID;

        [Display(Name = "Gizlilik", Order = 11)]
        public object PrivacyID;


    }
}
