using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream.Jobs.Models
{
    public class JobTag : EntityBase
    {
        [Display(Name = "标签名称")]
        public string TagName { get; set; }
    }
}
