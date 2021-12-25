using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.EF
{
    [MetadataType(typeof(TaskSourceMetadata))]
    public partial class TaskSource
    {
        [DataMember]
        public string ProfessionNumber {get;set;}
    }

    public class TaskSourceMetadata
    {
        [Display(Name = "Kurum", Order = 1)]
        public object Organization;

        [Display(Name = "Ünvan", Order = 2)]
        public object Title;

        [Display(Name = "Adı", Order = 3)]
        public object FirstName;

        [Display(Name = "Soyadı", Order = 4)]
        public object LastName;

        [Display(Name = "SicilNo", Order = 5)]
        public object ProfessionNumber;

        [Display(Name = "Görünür", Order = 5)]
        public object Visible;

    }
}
