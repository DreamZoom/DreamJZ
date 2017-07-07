using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dream.Shop
{
    public class goods_attribute : EntityBase
    {
        /// <summary>
        /// 属性名称 eg. 颜色，尺寸，尺码
        /// </summary>
        public string attr_name { get; set; }
    }
}
