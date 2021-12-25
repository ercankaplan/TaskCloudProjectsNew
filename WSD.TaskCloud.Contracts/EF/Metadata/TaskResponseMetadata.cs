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
    public partial class TaskResponse
    {
        [DataMember]
        public string ResponseFrom { get; set; }

        [Display(Name = "Dosya Ekleri")]
        [DataMember]
        public List<Attachment> Attachments { get; set; }

        public string SummaryPlain
        {
            get
            {

                if (string.IsNullOrEmpty(this.Description))
                    return string.Empty;

                Regex StripHTMLExpression = new Regex("<\\S[^><]*>", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled);

                string desc = this.Description;
                string plainDesc = StripHTMLExpression.Replace(desc, string.Empty);

                if (plainDesc.Length > 100)
                    return plainDesc.Substring(0, 100);
                else
                    return plainDesc;

            }
            
        }
    }
}
