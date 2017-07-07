using Dream.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dream.Config
{
    public class SiteConfig
    {
        /// <summary>
        /// 站点名称
        /// </summary>
        [Display(Name = "站点名称")]
        public string SiteName { get; set; }

        /// <summary>
        /// 站点描述
        /// </summary>
        [Display(Name = "站点描述")]
        [RichText]
        public string SiteDiscription { get; set; }

        /// <summary>
        /// 站点关键字
        /// </summary>
        /// 
        [Display(Name = "站点关键字",Description="逗号分隔")]
        public string SiteKeywords { get; set; }

        /// <summary>
        /// 版权信息
        /// </summary>
        /// 
        [Display(Name = "版权信息")]
        [DataType(DataType.MultilineText)]
        public string CopyRight { get; set; }
    }
}
