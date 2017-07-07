using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Xml.Serialization;

namespace Dream.Config
{
    /// <summary>
    /// 菜单配置文件
    /// </summary>
    public class MenuConfig
    {

        public MenuConfig()
        {
            Menus = new List<MenuNode>();
        }
        public List<MenuNode> Menus { get; set; }


        public MenuNode Find(string areaName, string controllerName, string actionName, NameValueCollection paramData)
        {
            foreach (var item in Menus)
            {
                var node = item.Find(areaName, controllerName, actionName, paramData);
                if (node != null)
                {
                    return node;
                }
            }
            return null;
        }
    }

    /// <summary>
    /// 菜单项
    /// </summary>
    public class MenuNode
    {

        public MenuNode()
        {
            Menus = new List<MenuNode>();
        }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// 菜单描述
        /// </summary>
        [XmlAttribute]
        public string Descript { get; set; }

        /// <summary>
        /// 菜单Icon Class
        /// </summary>
        [XmlAttribute]
        public string IconClass { get; set; }

        /// <summary>
        /// 控制器
        /// </summary>
        [XmlAttribute]
        public string ControllerName { get; set; }


        /// <summary>
        /// 动作
        /// </summary>
        [XmlAttribute]
        public string ActionName { get; set; }


        /// <summary>
        /// 区域
        /// </summary>
        [XmlAttribute]
        public string AreaName { get; set; }

        /// <summary>
        /// 参数 k=v&k1=v1
        /// </summary>
        [XmlAttribute]
        public string Params { get; set; }


        /// <summary>
        /// 唯一键值
        /// </summary>
        [XmlIgnore]
        public string Base64Key
        {
            get
            {
                byte[] bytes = Encoding.Default.GetBytes(string.Format("{0}{1}{2}{3}", this.AreaName, this.ControllerName, this.ActionName, this.Params));
                return Convert.ToBase64String(bytes);
            }
        }
       

        /// <summary>
        /// 显示模式
        /// </summary>
        [XmlAttribute]
        public int ShowMode { get; set; }


        /// <summary>
        /// 是否为分组
        /// </summary>
        [XmlAttribute]
        public bool Group { get; set; }

        /// <summary>
        /// 子菜单，group为真时有效
        /// </summary>
        public List<MenuNode> Menus { get; set; }


        /// <summary>
        /// 判断是否为当前活动页
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool IsCurrent(RequestContext context)
        {

            if (Group)
            {
                return this.Menus.Any(m => m.IsCurrent(context));
            }

            var controller = context.RouteData.Values["controller"].ToString();
            var action = context.RouteData.Values["action"].ToString();

            bool paramCompare = true;
            if (!string.IsNullOrWhiteSpace(this.Params))
            {
                var plist = this.Params.Split('&');
                foreach (var kv in plist)
                {
                    var k = kv.Split('=')[0];
                    var v = kv.Split('=')[1];
                    if (context.HttpContext.Request[k] != v)
                    {
                        paramCompare = false;
                        break;
                    }
                }
            }

            return this.ControllerName == controller && this.ActionName == action && paramCompare;
        }


        public MenuNode Find(string areaName, string controllerName, string actionName, NameValueCollection paramData)
        {
            if (Group)
            {
                foreach (var item in Menus)
                {
                    var node = item.Find(areaName, controllerName, actionName, paramData);
                    if (node != null)
                    {
                        return node;
                    }
                }
                return null;
            }


            if (this.ActionName == actionName
                && this.ControllerName == controllerName)
            {
                if (!string.IsNullOrWhiteSpace(this.AreaName) && this.AreaName != areaName)
                {
                    return null;
                }


                var plist = this.getParams();
                if (plist.Count == 0) return this;

                if (paramData == null) return null;
                foreach (var k in plist)
                {
                    if (k.Value != paramData[k.Key]) return null;
                }
                return this;
            }
            return null;
        }
        public RouteValueDictionary getParams()
        {
            RouteValueDictionary rv = new RouteValueDictionary();
            if (!string.IsNullOrWhiteSpace(this.Params))
            {
                var plist = this.Params.Split('&');
                foreach (var kv in plist)
                {
                    var k = kv.Split('=')[0];
                    var v = kv.Split('=')[1];
                    rv.Add(k, v);
                }
            }

            return rv;
        }


    }
}
