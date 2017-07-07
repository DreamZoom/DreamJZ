using Dream.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Dream.Attributes
{
    public class TreeSelectAttribute : UIHintAttribute
    {public string ControllerName { get; set; }

        public string Title { get; set; }

        public string Key { get; set; }

        public string KeyTitle { get; set; }

        public string Name { get; set; }

        public string NameTitle { get; set; }

        public string Columns { get; set; }

        public string ColumnNames { get; set; }

        public int SelectMode { get; set; }

        public string ParentFiled { get; set; }
        public Type ModelType { get; set; }
        public TreeSelectAttribute()
            : base("Select")
        {

            Key = "ID";
            KeyTitle = "编号";
            SelectMode = 1;
            Title = "请选择";
            ParentFiled = "ParentID";
        }
    }
}
