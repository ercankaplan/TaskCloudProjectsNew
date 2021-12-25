using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.DataContracts.Task
{
    public class TreeSchema
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int level { get; set; }
        [DataMember]
        public string Role { get; set; }

        [DataMember]
        public string text { get; set; }

        [DataMember]
        public string uid { get; set; }

        [DataMember]
        public List<TreeSchema> child { get; set; }

    }
}
