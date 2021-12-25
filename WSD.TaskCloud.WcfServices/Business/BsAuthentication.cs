using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Data;

namespace WSD.TaskCloud.WcfServices.Business
{
    internal class BsAuthentication:BusinessBase
    {
        public bool AuthenticateUser(string userName, string password)
        {

            Users oUser= TaskCloudContext.Users.Where(x => x.UserName == userName && x.Password == password).SingleOrDefault();

            if (oUser == null)
                throw new ApplicationException("Geçersiz kullanıcı girişi");

            if(oUser.IsLockedOut == true)
                throw new ApplicationException("Hesabınız blokeli");

            if (oUser.IsActive == false)
                throw new ApplicationException("Hesabınız Aktif değil");

            oUser.LastLoginDate = DateTime.Now;

            TaskCloudContext.Users.ApplyChanges(oUser);

            TaskCloudContext.SaveChanges();

            return true;

        }


       
    }
}