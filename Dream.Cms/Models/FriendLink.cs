using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dream.Cms
{
    public class FriendLink : EntityBase
    {
        [Display(Name = "链接地址")]
        public string LinkUrl { get; set; }

        [Display(Name = "链接标题")]
        public string LinkTitle { get; set; }
    }
}
