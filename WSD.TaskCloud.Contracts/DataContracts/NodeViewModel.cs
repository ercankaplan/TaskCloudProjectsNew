using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WSD.TaskCloud.Contracts.EF;

namespace WSD.TaskCloud.Contracts.DataContracts
{
    [DataContract]
    public class NodeViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Role { get; set; }

        [DataMember]
        public string Name { get; set; }


        [DataMember]
        public string ImgUrl { get; set; }

        [DataMember]
        public bool IsUser { get; set; }

        [DataMember]
        public bool Expanded { get; set; }

        [DataMember]
        public List<UserProfile> UsersInDepartment { get; set; }
        public NodeViewModel()
        {
            this.Expanded = true;
            this.Children = new List<NodeViewModel>();
        }

        
        public bool HasChildren
        {
            get { return Children.Any(); }
        }

        [DataMember]
        public IList<NodeViewModel> Children { get; private set; }

        [DataMember]
        public bool IsChecked { get; set; }

        [DataMember]
        public byte[] Logo { get; set; }
    }

}
