using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dream.Attributes
{
    public class ShowModeAttribute : Attribute
    {
        public ShowMode ListMode { get; set; }

        public ShowMode DisplayMode { get; set; }

        public ShowMode EditMode { get; set; }

        public ShowMode CreateMode { get; set; }
    }
}
