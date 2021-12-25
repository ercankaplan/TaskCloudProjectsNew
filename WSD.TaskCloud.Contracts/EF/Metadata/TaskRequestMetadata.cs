using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.EF
{

    public partial class TaskRequest
    {
        [DataMember]
        public string TaskFrom { get; set; }

        [DataMember]
        public string TaskTo { get; set; }

        private string summary;
        [DataMember]
        public string Summary { get {

                if (this.Task == null)
                    return string.Empty;

                if (string.IsNullOrEmpty(this.Task.Description))
                    return string.Empty;

                Regex StripHTMLExpression = new Regex("<\\S[^><]*>", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled);

                string desc = this.Task.Description;
                string plainDesc = StripHTMLExpression.Replace(desc, string.Empty);

                if (plainDesc.Length > 100)
                    return plainDesc.Substring(0, 100);
                else
                    return plainDesc;

            }
            set
            {
                summary = value;
            }
        }


        private string subject;
        [DataMember]
        public string Subject
        {
            get
            {

                if (this.Task == null)
                    return string.Empty;

                if (string.IsNullOrEmpty(this.Task.Subject))
                    return string.Empty;

                if (this.Task.Subject.ToString().Length > 100)
                    return this.Task.Subject.ToString().Substring(0, 100);
                else
                    return this.Task.Subject.ToString();

            }
            set
            {
                summary = value;
            }


        }

        private string taskNo;
        [DataMember]
        public string TaskNo
        {
            get
            {

                if (this.Task == null)
                    return string.Empty;

                if (string.IsNullOrEmpty(this.Task.TaskNo))
                    return string.Empty;

               
                    return this.Task.TaskNo.ToString();

            }
            set
            {
                taskNo = value;
            }
        }

        private string opTimeText;
        [Display(Name = "&nbsp;")]
        [DataMember]
        public string Tarih
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
            set { opTimeText = value; }
        }

       
        public string OptimeText2
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
                    return this.Optime.ToString("HH:mm");
                }
                else if (this.Optime.ToShortDateString() == DateTime.Today.AddDays(-1).ToShortDateString())
                {
                    return this.Optime.DayOfWeek.ToString().Substring(0,3) + this.Optime.ToString("HH:mm");
                }
                else if (this.Optime >= haftaBasi)
                {
                    return this.Optime.DayOfWeek.ToString().Substring(0, 3) + this.Optime.ToString("HH:mm");
                }
                else if (this.Optime < haftaBasi && this.Optime >= gecenHafta_Basi)
                {
                    return this.Optime.DayOfWeek.ToString().Substring(0, 3) + this.Optime.ToString("HH:mm");
                }
                else if (this.Optime < gecenHafta_Basi && this.Optime >= ikiHaftaOnce_Basi)
                {
                    return this.Optime.ToString("dd.MM.yyyy");
                }
                else if (this.Optime < ikiHaftaOnce_Basi && this.Optime >= UcHaftaOnce_Basi)
                {
                    return this.Optime.ToString("dd.MM.yyyy");
                }
                else if (this.Optime < UcHaftaOnce_Basi && this.Optime >= GecenAy_Basi)
                {
                    return this.Optime.ToString("dd.MM.yyyy");
                }
                else if (this.Optime < GecenAy_Basi)
                {
                    return this.Optime.ToString("dd.MM.yyyy");
                }
                else
                    return val;

            }
        }
    }
}
