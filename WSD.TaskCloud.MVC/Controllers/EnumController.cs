using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WSD.TaskCloud.MVC.Controllers
{
    public class EnumController: BaseController
    {
        public static string GetEnumDescription(Type enumType, string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(key))
            {
                FieldInfo fi;
                DescriptionAttribute da;
                foreach (var enumValue in Enum.GetValues(enumType))
                {
                    if (Convert.ToInt32(enumValue) == Convert.ToInt32(key))
                    {
                        fi = enumType.GetField((enumValue.ToString()));
                        da = (DescriptionAttribute)Attribute.GetCustomAttribute(fi,
                        typeof(DescriptionAttribute));
                        if (da != null)
                        {
                            result = da.Description;
                        }
                    }
                }
            }

            return result;
        }
    }
}