using Dream.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Dream.Extensions
{
    public static class SiteConfigExtensions
    {
        static SiteConfig siteConfig = null;
        public static SiteConfig SiteConfig(this HtmlHelper helper)
        {
            if (siteConfig == null)
            {
                siteConfig = ConfigProvider.Load<SiteConfig>();
            }
            return siteConfig;
        }
    }
}
