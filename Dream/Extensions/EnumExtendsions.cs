using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
namespace Dream.Extensions
{
    public static class EnumExtendsions
    {
        public static List<SelectListItem> EnumListBox(this HtmlHelper helper,Type enumType,object enumValue=null)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (!enumType.IsEnum) return list;

            foreach (string name in Enum.GetNames(enumType))
            {
                var value =Enum.Parse(enumType, name);
                list.Add(new SelectListItem() { Text = name, Value = value.ToString(), Selected = (value.Equals(enumValue)) });
            }

            return list;
        }
    }
}
