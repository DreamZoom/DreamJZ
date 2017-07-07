using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream.Jobs.Models
{
    public class Workarea : EntityBase
    {
        /// <summary>
        /// 区域编号
        /// </summary>
        /// 
        [Display(Name = "区域编号")]
        public string AreaNo { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        /// 
        [Display(Name = "区域名称")]
        public string AreaName { get; set; }


        public virtual ICollection<JobWorkareas> Jobs { get; set; }
    }
}
