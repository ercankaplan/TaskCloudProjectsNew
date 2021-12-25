using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WSD.TaskCloud.Contracts.EF
{
    public partial class UserProfile
    {
        private string fullName;
        [DataMember]
       
        public string FullName
        {
            get
            {
                  return string.Format("{0} {1}", string.IsNullOrEmpty(this.FirstName) ? string.Empty : this.FirstName, string.IsNullOrEmpty(this.LastName) ? string.Empty : this.LastName);
            }

            set
            {
                fullName = value;
            }
        }
    }
}
