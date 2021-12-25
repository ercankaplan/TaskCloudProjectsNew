using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WSD.TaskCloud.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }



        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteTable.Routes.MapHubs();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\WSD.TaskCloud.MVC");
            //try
            //{
            //    string PassPhrase = (string)registryKey.GetValue("PassPhrase");
            //}
            //catch
            //{
            //    Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WSD.TaskCloud.MVC");
            //    Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\WSD.TaskCloud.MVC", "PassPhrase", "1FCEC1A9-C417-4223-A20B-1DB16571F134");
            //}
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            string redirectUrl = this.Response.RedirectLocation;

            if (!string.IsNullOrEmpty(redirectUrl))
            {
                this.Response.RedirectLocation = Regex.Replace(redirectUrl, "ReturnUrl=(?'url'.*)", delegate (Match m)
                {
                    string url = HttpUtility.UrlDecode(m.Groups["url"].Value);

                    Uri u = new Uri(this.Request.Url, url);

                    return string.Format("ReturnUrl={0}", HttpUtility.UrlEncode(u.ToString()));

                }, RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
            }
        }
    }
}
