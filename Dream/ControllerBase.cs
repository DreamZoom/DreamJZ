using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Dream
{
    public class ControllerBase : Controller
    {

        public ActionResult Success(string message,string backUrl="")
        {
            ViewData["Message"] = message;
            ViewData["BackUrl"] = string.IsNullOrWhiteSpace(backUrl) ? Request.UrlReferrer.ToString() : backUrl;
            ViewData["Result"] = "Success";
            return View("_Result");
        }

        public ActionResult Error(string message, string backUrl = "")
        {
            ViewData["Message"] = message;
            ViewData["BackUrl"] = string.IsNullOrWhiteSpace(backUrl) ? Request.UrlReferrer.ToString() : backUrl;
            ViewData["Result"] = "Error";
            return View("_Result");
        }


        public ActionResult JsonP(object jsonObject)
        {
            string json =JsonConvert.SerializeObject(jsonObject, new JsonSerializerSettings() { 
                ReferenceLoopHandling= ReferenceLoopHandling.Ignore ,
     
            });
            string callback = Request.Params["callback"];
            if (string.IsNullOrWhiteSpace(callback))
            {
                return Content(json);
            }
            return Content(string.Format("{0}({1})",callback,json));
        }
    }
}
