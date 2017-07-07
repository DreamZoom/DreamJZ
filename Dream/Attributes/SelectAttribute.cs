using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dream.Attributes
{
    public class SelectAttribute : UIHintAttribute
    {
        public string ControllerName { get; set; }

        public string Title { get; set; }

        public string Key { get; set; }

        public string KeyTitle { get; set; }

        public string Name { get; set; }

        public string NameTitle { get; set; }

        public string Columns { get; set; }

        public string ColumnNames { get; set; }

        public int SelectMode { get; set; }
        public SelectAttribute()
            : base("Select")
        {
            Key = "ID";
            KeyTitle = "编号";
            SelectMode = 1;
            Title = "请选择";
        }
    }

    
}
