using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dream.Attributes
{
    public class SortAttribute : Attribute
    {
        public int Sort { get; set; }

        public SortAttribute(int sort)
        {
            this.Sort = sort;
        }
    }
}
