using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dream.Attributes
{
    public class ImageAttribute : UIHintAttribute
    {
        public ImageAttribute()
            : base("Image")
        {

        }
    }
}
