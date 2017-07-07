using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dream
{
    public class ModelProperty
    {
        /// <summary>
        /// 是否为递增列
        /// </summary>
        public bool IsIdentity { get; set; }

        /// <summary>
        /// 是否为主键
        /// </summary>
        public bool IsKey { get; set; }

        /// <summary>
        /// 是否为外键
        /// </summary>
        public bool IsForeignKey { get; set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 属性排序
        /// </summary>
        public int Sort { get; set; }


        public ShowMode ListMode { get; set; }

        public ShowMode DisplayMode { get; set; }

        public ShowMode EditMode { get; set; }

        public ShowMode CreateMode { get; set; }
    }

    public enum ShowMode
    {
        Show,
        Hidden,
        Remove
    }
}
