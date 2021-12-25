using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.EF
{

    [MetadataType(typeof(UsersMetadata))]
    public partial class Users
    {
        [DataMember]
        public List<string> PermissionCodes { get; set; }

        [DataMember]
        public UserProfile Profile { get; set; }

        [DataMember]
        public UserRole UserRoleData { get; set; }
        public string Image64 { get { return Logo != null ? Convert.ToBase64String(Logo) : null; } }

        [DataMember]
        public byte[] SignImg { get; set; }
    }

    public partial class UserRole
    {
        

        [DataMember]
        public Role RoleData { get; set; }
    }

    public class UsersMetadata
    {
    }
}
