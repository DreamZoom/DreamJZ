using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.IO;

namespace Dream.Extensions
{
    public static class ControllterExtensions
    {
        private static string _templateFileName = null;
        public static string TemplateFile
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_templateFileName))
                {
                    _templateFileName = Guid.NewGuid().ToString();
                }
                return _templateFileName;
            }
        }
        public static ActionResult Template(this Controller controller,string template)
        {
            string path = controller.Server.MapPath("~/Views/Shared");

            string filename = string.Format("{0}/{1}.aspx", path, TemplateFile);

            template = string.Format("{0} \n\t{1}", "<%@ Page Language=\"C#\"  Inherits=\"System.Web.Mvc.ViewPage\" %>", template);
            File.WriteAllText(filename, template);

            return new ViewResult() { ViewName = _templateFileName  };
        }


        public static ActionResult Success(this Controller controller,string message)
        {
            return new ViewResult() { ViewName = "_Result", ViewData = new ViewDataDictionary(new ResultMessage() { IsSuccess =true, Message = message }) };
        }

        public static ActionResult Error(this Controller controller, string message)
        {
            return new ViewResult() { ViewName = "_Result", ViewData = new ViewDataDictionary(new ResultMessage() { IsSuccess = false, Message = message }) };
        }
    }
}
