using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dream.Attributes
{
    public class SwitchAttribute : UIHintAttribute
    {
        public string Yes { get; set; }

        public string No { get; set; }

        public SwitchAttribute()
            : base("Switch")
        {

        }
    }
}
