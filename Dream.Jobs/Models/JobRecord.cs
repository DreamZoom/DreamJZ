using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Dream.Attributes;

namespace Dream.Jobs.Models
{
    public class JobRecord : EntityBase
    {
        [Display(Name = "职位")]
        [ShowMode(ListMode = ShowMode.Hidden)]
        public int JobID { get; set; }
        [ForeignKey("JobID")]
        public virtual Job Job { get; set; }

        [Display(Name = "职位标题")]
        public string JobTitle { get; set; }
        [Display(Name = "职位描述")]
        [ShowMode(ListMode = ShowMode.Hidden)]
        public string JobDesc { get; set; }
        [Display(Name = "用户名")]
        public string UserName { get; set; }
        [Display(Name = "用户编号")]
        [ShowMode(ListMode = ShowMode.Hidden)]
        public int UserID { get; set; }

        [Display(Name = "联系电话")]
         public string Tell { get; set; }

        [Display(Name = "是否取消")]
        public bool IsCancel { get; set; }
    }
}
