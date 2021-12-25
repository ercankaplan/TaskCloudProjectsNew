using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.EF
{
    [MetadataType(typeof(PersonnelMetadata))]
    public partial class Personnel
    {
        [DataMember]
        [Display(Name = "Referanlar")]
        public List<Reference> References { get; set; }
    }

    public class PersonnelMetadata
    {

        [Display(Name = "SicilNo", Order = 1)]
        public object ProfessionNumber;

        [Display(Name = "Ad", Order = 2)]
        public object FirstName;

        [Display(Name = "Soyad", Order = 3)]
        public object LastName;

        [Display(Name = "Çalıştığı Birim", Order = 4)]
        public object DepartmentID;

        [Display(Name = "Ünvan", Order = 5)]
        public object TitleID;

    }
}
