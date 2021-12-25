using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace WSD.TaskCloud.MVC.Mapper
{

    public static class QueryStringCrypto
    {
        private static RijndaelManaged rijndaelManaged;

        static QueryStringCrypto()
        {
            byte[] privateKey = Encoding.UTF8.GetBytes("@Bp4aM8NK342QcvA");
            byte[] iV = Encoding.UTF8.GetBytes("@HN1KS9yB5Xda8dN");
            rijndaelManaged = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128,
                Key = privateKey,
                IV = iV
            };
        }

        static string StringFromDictionary(RouteValueDictionary dictionary)
        {
            return string.Join("-", dictionary.Select(d => d.Key + "+" + d.Value));
        }

        static string StringFromDictionary(Dictionary<string, object> dictionary)
        {
            return string.Join("-", dictionary.Select(d => d.Key + "+" + d.Value));
        }

        static Dictionary<string, string> DictionaryFromBytes(byte[] bytes)
        {
            string decryptedString = Encoding.UTF8.GetString(bytes);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            string[] keyValuePair = decryptedString.Split('-');

            foreach (string key in keyValuePair)
            {
                string[] keyValue = key.Split('+');
                dictionary.Add(keyValue[0], keyValue[1]);
            }

            return dictionary;
        }

        static byte[] EncryptBytes(byte[] bytes)
        {
            return rijndaelManaged.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
        }

        static byte[] DecryptBytes(byte[] bytes)
        {
            return rijndaelManaged.CreateDecryptor().TransformFinalBlock(bytes, 0, bytes.Length);
        }

        static string ToBase64(byte[] bytes)
        {
            string strBase64;
            strBase64 = Convert.ToBase64String(bytes);
            return strBase64.Replace('+', '-').Replace('/', '_').Replace('=', ',');
        }

        static byte[] FromBase64(string encryptedText)
        {
            encryptedText = encryptedText.Replace('-', '+').Replace('_', '/').Replace(',', '=');
            return Convert.FromBase64String(encryptedText);
        }

        public static object EncryptRouteValues(object routes)
        {
            RouteValueDictionary routeDict = new RouteValueDictionary(routes);
            string areaName = null;
            string controllerName = null;
            if (routeDict.ContainsKey("area"))
            {
                areaName = routeDict.First(f => f.Key == "area").Value.ToString();
                routeDict.Remove("area");
            }
            if (routeDict.ContainsKey("controller"))
            {
                controllerName = routeDict.First(f => f.Key == "controller").Value.ToString();
                routeDict.Remove("controller");
            }
            byte[] queryString = Encoding.UTF8.GetBytes(StringFromDictionary(routeDict));
            byte[] encryptedBytes = EncryptBytes(queryString);
            if (string.IsNullOrEmpty(areaName))
            {
                if (!string.IsNullOrEmpty(controllerName))
                    return new { controller = controllerName, q = ToBase64(encryptedBytes) };
                return new { q = ToBase64(encryptedBytes) };
            }
            if (!string.IsNullOrEmpty(controllerName))
                return new { area = areaName, controller = controllerName, q = ToBase64(encryptedBytes) };
            return new { area = areaName, q = ToBase64(encryptedBytes) };
        }

        public static string Encrypt(object id)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("", id);
            byte[] queryString = Encoding.UTF8.GetBytes(StringFromDictionary(dictionary));
            byte[] encryptedBytes = EncryptBytes(queryString);
            return ToBase64(encryptedBytes);
        }

        public static Dictionary<string, string> Decrypt(string encryptedText)
        {
            byte[] encryptedBytes = FromBase64(encryptedText);
            byte[] decryptedBytes = DecryptBytes(encryptedBytes);
            return DictionaryFromBytes(decryptedBytes);
        }
    }
}