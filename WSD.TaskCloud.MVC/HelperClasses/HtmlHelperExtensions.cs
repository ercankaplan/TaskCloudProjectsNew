using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.MVC.Models;

namespace WSD.TaskCloud.MVC.HelperClasses
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString FirstCharToUpper(this HtmlHelper htmlHelper, string input)
        {
            if (string.IsNullOrEmpty(input.ToString()))
                return MvcHtmlString.Empty;
            return MvcHtmlString.Create(input.First().ToString().ToUpper() + input.Substring(1));
        }


        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static string GetSignImg(byte[] SignImg)
        {
           
            if (SignImg != null)
            {
                var base64 = Convert.ToBase64String(SignImg);
                var imgSrcSign = String.Format("data:image/gif;base64,{0}", base64);

                return imgSrcSign;
            }
            else
                return string.Empty;
        }

        public static string GetUserRoleName(Users oUser)
        {
        
               
            if (oUser == null || oUser.UserRoleData == null || oUser.UserRoleData.RoleData == null || string.IsNullOrEmpty(oUser.UserRoleData.RoleData.Name))
                return string.Empty;

            return oUser.UserRoleData.RoleData.Name.ToUpper();

            

        }

        public static MvcHtmlString StarredLabelFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
        {
            TagBuilder result = new TagBuilder("label");
            var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            string labelText = metaData.DisplayName ?? metaData.PropertyName;
            if (string.IsNullOrEmpty(labelText))
                return MvcHtmlString.Create(result.ToString(TagRenderMode.SelfClosing));

            result.InnerHtml = labelText;
            if (metaData.IsRequired)
            {
                TagBuilder starSpan = new TagBuilder("span");
                starSpan.Attributes.Add("style", "color: red;");
                starSpan.SetInnerText(" *");
                result.InnerHtml += starSpan;
            }

            return MvcHtmlString.Create(result.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString StarredLabelForNormal<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
        {
            TagBuilder result = new TagBuilder("label");
            var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            string labelText = metaData.DisplayName ?? metaData.PropertyName;
            if (string.IsNullOrEmpty(labelText))
                return MvcHtmlString.Create(result.ToString(TagRenderMode.SelfClosing));

            result.InnerHtml = labelText;
            if (metaData.IsRequired)
            {
                TagBuilder starSpan = new TagBuilder("span");
                result.InnerHtml += starSpan;
            }

            return MvcHtmlString.Create(result.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString GetTaskTypeName(this HtmlHelper htmlHelper, MvcHtmlString key)
        {
            if (string.IsNullOrEmpty(key.ToString()))
                return MvcHtmlString.Empty;
            byte bkey = Convert.ToByte(key.ToString());
            TaskType t = CacheHelper.GetCacheItem<TaskType>().Where(x => x.TaskTypeID == bkey).Single();

            if (t == null)
                return MvcHtmlString.Empty;

            return MvcHtmlString.Create(t.Name);
        }

        public static MvcHtmlString GetTaskDescription(this HtmlHelper htmlHelper, MvcHtmlString data)
        {

            return MvcHtmlString.Create(data.ToString());
        }
        public class UploadFile
        {
            public string FileName { get; set; }
            public string FileExtention { get; set; }
            public long Size { get; set; }
            public string FilePath { get; set; }
            public string ICon { get; set; }
        }

        public static void EncrFile(HttpPostedFileBase Lfile)
        {
            System.Drawing.Image sourceimage = System.Drawing.Image.FromStream(Lfile.InputStream);
            var img = HtmlHelperExtensions.ResizeImage(sourceimage, 40, 40);
            byte[] imgByte = HtmlHelperExtensions.imageToByteArray(img);
            string fileName = Lfile.FileName;

            byte[] imgByte2 = null;
            string outputFile2 = Path.Combine(HostingEnvironment.MapPath("~/UploadedFiles"), fileName);
            System.Drawing.Image sourceimage2 = System.Drawing.Image.FromStream(Lfile.InputStream);
            var img2 = HtmlHelperExtensions.ResizeImage(sourceimage, 40, 40);
            imgByte = HtmlHelperExtensions.imageToByteArray(img);
            var algorithm = GetAlgorithm("123");
            var encryptor = algorithm.CreateEncryptor();
            FileStream fs2 = new FileStream(outputFile2, FileMode.Create);
            using (var ms = new MemoryStream())
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                foreach (var data in imgByte)
                {
                    cs.WriteByte((byte)data);
                }
                cs.Close();
                fs2.Close();

            }
        }
        public static void DecryptFile(string sInputFilename,
         string sOutputFilename,
         string sKey)
        {
            FileStream fs = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            byte[] ImageData = new byte[fs.Length];
            string outputFile2 = sOutputFilename;
            var algorithm = GetAlgorithm("123");
            var encryptor = algorithm.CreateEncryptor();
            FileStream fs2 = new FileStream(outputFile2, FileMode.Create);
            var clearBytes = ImageData;
            using (var ms = new MemoryStream())
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                foreach (var data in ImageData)
                {
                    cs.WriteByte((byte)data);
                }
                cs.Close();
                fs2.Close();

            }
        }

        private static SymmetricAlgorithm GetAlgorithm(string password)
        {
            var algorithm = Rijndael.Create();
            var rdb = new Rfc2898DeriveBytes(password, new byte[] {
        0x53,0x6f,0x64,0x69,0x75,0x6d,0x20,             // salty goodness
        0x43,0x68,0x6c,0x6f,0x72,0x69,0x64,0x65
    });
            algorithm.Padding = PaddingMode.ISO10126;
            algorithm.Key = rdb.GetBytes(32);
            algorithm.IV = rdb.GetBytes(16);
            return algorithm;
        }

        /// <summary>
        /// Encrypts a string with a given password.
        /// </summary>
        /// <param name="clearText">The clear text.</param>
        /// <param name="password">The password.</param>
        public static string EncryptString(string clearText, string password)
        {
            var algorithm = GetAlgorithm(password);
            var encryptor = algorithm.CreateEncryptor();
            var clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (var ms = new MemoryStream())
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                cs.Write(clearBytes, 0, clearBytes.Length);
                cs.Close();
                return Convert.ToBase64String(ms.ToArray());
            }




        }

        /// <summary>
        /// Decrypts a string using a given password.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <param name="password">The password.</param>
        public static string DecryptString(string cipherText, string password)
        {
            var algorithm = GetAlgorithm(password);
            var decryptor = algorithm.CreateDecryptor();
            var cipherBytes = Convert.FromBase64String(cipherText);
            using (var ms = new MemoryStream())
            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
            {
                cs.Write(cipherBytes, 0, cipherBytes.Length);
                cs.Close();
                return Encoding.Unicode.GetString(ms.ToArray());
            }
        }
    }


}