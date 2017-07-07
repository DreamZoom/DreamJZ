using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Dream.Attributes
{
    public class RichTextAttribute : UIHintAttribute
    {
        public RichTextAttribute()
            : base("RichEditor")
        {

        }
    }
}
