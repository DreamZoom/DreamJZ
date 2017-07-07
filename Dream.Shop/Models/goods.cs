using Dream.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Dream.Shop
{
    /// <summary>
    /// 商品
    /// </summary>
    public class goods : EntityBase
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        /// 
        [Display(Name = "商品编号")]
        [ShowMode(CreateMode = ShowMode.Remove,ListMode=ShowMode.Remove)]
        public string good_no { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [Display(Name = "商品名称")]
        public string good_name { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        [Display(Name = "商品价格")]
        public int good_price { get; set; }

        /// <summary>
        /// 商品销售库存
        /// </summary>
        [Display(Name = "商品销售库存")]
        public int good_store { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        [Display(Name = "商品图片")]
        [Image]
        public string good_image { get; set; }

        /// <summary>
        /// 商品图片，展示
        /// </summary>
        [Display(Name = "商品图片")][ImageList]
        public string good_image_list { get; set; }

        /// <summary>
        /// 图文详情
        /// </summary>
        [Display(Name = "图文详情")]
        [RichText]
        public string good_details { get; set; }

        /// <summary>
        /// 包装清单
        /// </summary>
        [Display(Name = "包装清单")]
        public string good_packing_list { get; set; }

        /// <summary>
        /// 商品规格
        /// </summary>
        [Display(Name = "商品规格")]
        [NotMapped]
        [UIHint("SkuEditor")]
        public string good_sku_temp { get; set; }

        /// <summary>
        /// 商品状态
        /// </summary>
        [Display(Name = "商品状态")][UIHint("Enum")]
        public EGoodState good_state { get; set; }
    }
}
