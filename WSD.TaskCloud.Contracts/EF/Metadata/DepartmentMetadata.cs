using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.EF
{
    public partial class Department
    {
        [DataMember]
        public List<Users> UsersInDepartment { get; set; }

        [DataMember]
        public bool IsRoot {get;set;}
    }
}
