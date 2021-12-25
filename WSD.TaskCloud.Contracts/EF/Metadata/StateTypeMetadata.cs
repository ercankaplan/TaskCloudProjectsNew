using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.EF
{
    public partial class StateType
    {
        [DataMember]
        public string ColorSelector { get; set; }
    }
}
