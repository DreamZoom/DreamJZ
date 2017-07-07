using Dream.SSO.Models;
using Dream.SSO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace Dream.SSO
{
    public class PassportController : Controller
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

            Log(DateTime.Now + "----------------------------------------------");
            Log(log);
            Log("登录ip:" + ip);
            Log(DateTime.Now + "----------------------------------------------");
        }

        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

        public ActionResult SignIn()
        {
            var user = SSOProviders.Current.GetUser();

            if (user == null)
            {
                string returnUrl = Request.QueryString["ReturnUrl"];
                return RedirectToAction("Login", new { returnUrl = returnUrl });
            }
            else
            {
                return Logined(user);
            }
        }

        public ActionResult Login()
        {
            Session["user_private_key"] = rsa.ToXmlString(true);

            RSAParameters parameter = rsa.ExportParameters(true);
            ViewBag.strPublicKeyExponent = BytesToHexString(parameter.Exponent);
            ViewBag.strPublicKeyModulus = BytesToHexString(parameter.Modulus);
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            RSAParameters parameter = rsa.ExportParameters(true);
            ViewBag.strPublicKeyExponent = BytesToHexString(parameter.Exponent);
            ViewBag.strPublicKeyModulus = BytesToHexString(parameter.Modulus);

            rsa.FromXmlString((string)Session["user_private_key"]);
            byte[] result = rsa.Decrypt(HexStringToBytes(model.Password), false);
            System.Text.ASCIIEncoding enc = new ASCIIEncoding();
            string  password = enc.GetString(result);



            UserService userService = new UserService();
            TokenService tokenService = new TokenService();
            var user = userService.GetUserByName(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "用户名不存在。");
            }
            else
            {
                byte[] result2 = Encoding.Default.GetBytes(user.Password);    //tbPass为输入密码的文本框  
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] output = md5.ComputeHash(result2);
                string enc_password = BitConverter.ToString(output).Replace("-", "").ToLower();  //tbMd5pass为输出加密文本的

                if (enc_password == password && user.EndTime >= DateTime.Now)
                {
                    return Logined(user);
                }
                else if (user.EndTime < DateTime.Now)
                {
                    ModelState.AddModelError("", "您的会员已到期，请联系客服。");
                }
                else
                {
                    ModelState.AddModelError("", "密码不正确，如需找回密码，请联系客服。");
                }
            }
            return View(model);
        }


        public ActionResult Logined(User user)
        {
            string returnUrl = Request.QueryString["ReturnUrl"];

            Token token = new Token()
            {
                CreateTime = DateTime.Now,
                IsValid = true,
                RemoteIp = Utility.RemoteIp,
                UserName = user.UserName,
                TokenID = Guid.NewGuid().ToString(),
                ValidTime = DateTime.Now
            };

            TokenService tokenService = new TokenService();

            if (tokenService.Create(token))
            {
                SSOProviders.Current.LogIn(user);
                if (!string.IsNullOrWhiteSpace(returnUrl))
                {
                    string splitStr = returnUrl.Contains("?") ? "&" : "?";
                    string returnFormat = "{0}{1}token={2}";
                    return Redirect(string.Format(returnFormat, returnUrl, splitStr, token.TokenID));
                }
                else
                {
                    return Redirect("/");
                }
            }
            else
            {
                ModelState.AddModelError("", "token授权失败");
            }
            return View();
        }
    }
}
