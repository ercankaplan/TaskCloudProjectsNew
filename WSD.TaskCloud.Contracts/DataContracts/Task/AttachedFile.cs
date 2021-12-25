using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.DataContracts.Task
{
    [DataContract]
    public class AttachedFile
    {
        [DataMember]
        public Guid TaskID { get; set; }

        [DataMember]
        public int? ReferenceID { get; set; }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public string Extend { get; set; }

        [DataMember]
        public byte[] Data { get; set; }


        [DataMember]
        public string TempFileName { get; set; }

        [DataMember]
        public string ContentType { get; set; }

        /// <summary>
        /// size of contentlength in bytes
        /// </summary>
        [DataMember]
        public long Size { get; set; }

        [DataMember]
        public bool Visible { get; set; }
    }
}
