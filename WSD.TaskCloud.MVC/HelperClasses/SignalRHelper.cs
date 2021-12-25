using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.MVC.Hubs;

namespace WSD.TaskCloud.MVC.HelperClasses
{
    public class SignalRHelper
    {
        public static void SendMessage(string userID)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<Chat>();
            hubContext.Clients.Client(Chat.myList.Where(i => i.userID == userID).FirstOrDefault().connectionID).Send("msg");
        }

        public static void Taskadd(string userID,string Count)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<Chat>();
            hubContext.Clients.Client(Chat.myList.Where(i => i.userID == userID).FirstOrDefault().connectionID).Taskadd(Count);
        }


    }
}