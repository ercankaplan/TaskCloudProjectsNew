using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WSD.TaskCloud.MVC.ClientContracts
{

    public class GeneralDefinition
    {

        
        private string typeName;

        public GeneralDefinition() { }

        public GeneralDefinition(string tName) {
            this.typeName = tName;
        }

       
        public string TypeName
        {
            get
            {
                return typeName;
            }

            set
            {
                typeName = value;
            }
        }
    }
}