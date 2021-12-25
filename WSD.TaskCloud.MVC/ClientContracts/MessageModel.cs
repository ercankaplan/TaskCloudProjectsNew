using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSD.TaskCloud.MVC.ClientContracts
{
    public class MessageModel
    {
        public string MessageText;

        public EnumMessageType TypeOfMessage;

    }

    public enum EnumMessageType
    {
        Error = 1,
        Warning  = 2,
        Info  = 3

    }
}