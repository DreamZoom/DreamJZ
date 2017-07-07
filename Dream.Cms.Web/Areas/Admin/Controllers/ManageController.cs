using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Dream.Cms.Web.Areas.Admin.Controllers
{
    public class ManageController : MainController
    {
        private string BytesToHexString(byte[] input)
        {
            StringBuilder hexString = new StringBuilder(64);

            for (int i = 0; i < input.Length; i++)
            {
                hexString.Append(String.Format("{0:X2}", input[i]));
            }
            return hexString.ToString();
        }

        public static byte[] HexStringToBytes(string hex)
        {
            if (hex.Length == 0)
            {
                return new byte[] { 0 };
            }

            if (hex.Length % 2 == 1)
            {
                hex = "0" + hex;
            }

            byte[] result = new byte[hex.Length / 2];

            for (int i = 0; i < hex.Length / 2; i++)
            {
                result[i] = byte.Parse(hex.Substring(2 * i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }

            return result;
        }


        public void Log(string log)
        {
            string path = Server.MapPath("/log.txt");
            System.IO.File.AppendAllLines(path, new List<string>() { log });
        }

        public void Log2(string log)
        {
            string ip = string.Empty;
            if (Request.ServerVariables["HTTP_VIA"] != null) // using proxy 
            {
                ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString(); // Return real client IP. 
            }
            else// not using proxy or can't get the Client IP 
            {
                ip = Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP. 
            }

            Log(DateTime.Now+ "----------------------------------------------");
            Log(log);
            Log("登录ip:"+ip);
            Log(DateTime.Now + "----------------------------------------------");
        }

        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        public override ActionResult Login()
        {
            Session["private_key"] = rsa.ToXmlString(true);

            RSAParameters parameter = rsa.ExportParameters(true);
            ViewBag.strPublicKeyExponent = BytesToHexString(parameter.Exponent);
            ViewBag.strPublicKeyModulus = BytesToHexString(parameter.Modulus);
            return base.Login();
        }
        public override ActionResult Login(string userName, string password, string back_url = null)
        {
            RSAParameters parameter = rsa.ExportParameters(true);
            ViewBag.strPublicKeyExponent = BytesToHexString(parameter.Exponent);
            ViewBag.strPublicKeyModulus = BytesToHexString(parameter.Modulus);
            try
            {
                Log2(string.Format("{0} 正在登录", userName));
                rsa.FromXmlString((string)Session["private_key"]);
                byte[] result = rsa.Decrypt(HexStringToBytes(password), false);
                System.Text.ASCIIEncoding enc = new ASCIIEncoding();
                password = enc.GetString(result);
                return base.Login(userName, password, back_url);
            }
            catch (Exception err)
            {
                ModelState.AddModelError("", err.Message);
                return View();
            }
            
        }

    }
}
