using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WSD.TaskCloud.Contracts.DataContracts;

namespace WSD.TaskCloud.MVC.Hubs
{
    public class Chat : Hub
    {

        public static List<SignalRUser> myList = new List<SignalRUser>();
        public object HubHelper { get; private set; }

        public void SendMessage(string message)
        {
            var userName = Context.User.Identity.Name;
            Clients.All.send(userName+":"+message);
        }
        public void Send(string message)
        {
            var userName = Context.User.Identity.Name;
            Clients.All.send(userName + ":" + message);
        }

        public void Taskadd(string count)
        {
            var userName = Context.User.Identity.Name;
            Clients.All.taskadd(count);
        }
        public void Register(string userID,string Username)
        {
            SignalRUser mod = new SignalRUser();
            mod.connectionID= Context.ConnectionId;
            mod.userID= Context.User.Identity.Name;
            mod.userName= Context.User.Identity.Name;
            if(myList.Where(i=>i.userName==mod.userName).Count()>0)
            {
                myList.Remove(myList.Where(i => i.userName == mod.userName).FirstOrDefault());
               
            }
            myList.Add(mod);
        }

        public void SendToUser(string username,string message)
        {
            SignalRUser mod= myList.Where(i => i.userName == username).FirstOrDefault();
            Clients.Client(mod.userID).send(username, "message", Context.ConnectionId);
        }

        public void Send_PrivateMessage(String msgFrom, String msg, String touserid)
        {
            var id = Context.ConnectionId;
            Clients.Caller.receiveMessage(msgFrom, msg, touserid);
            Clients.Client(touserid).receiveMessage(msgFrom, msg, id);
        }
    }
}