using Dream.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Webdiyer.WebControls.Mvc;

namespace Dream.Extensions
{
    public static class HtmlExtensions
    {
        public static List<ModelProperty> Metadata(this HtmlHelper helper)
        {
            var type = helper.ViewData.ModelMetadata.ModelType;
            if (type.IsGenericType)
            {
                Type[] genericArgTypes = type.GetGenericArguments();
                type = genericArgTypes.FirstOrDefault();
            }
            var metadata = ModelMetadataProviders.Current.GetMetadataForType(null, type);

            var propertys = ModelHelper.GetModelProperty(metadata);

            return propertys;
        }


        public static TAttribute Attribute<TAttribute>(this HtmlHelper helper)
             where TAttribute : class
        {
            return ModelHelper.getAttr<TAttribute>(helper.ViewData.ModelMetadata.ContainerType, helper.ViewData.ModelMetadata.PropertyName);
        }


        public static MvcHtmlString MvcPager<T>(this HtmlHelper helper,IEnumerable<T> list)
        {
            var pagelist = list as IPagedList;
            return helper.Pager(pagelist, new PagerOptions() { AutoHide = false, NumericPagerItemCount = 5});
        }


        public static MvcHtmlString ShowText(this HtmlHelper helper,string htmlString)
        {
            if (string.IsNullOrWhiteSpace(htmlString)) htmlString = string.Empty;
            string reg = @"[<].*?[>]";
            htmlString = Regex.Replace(htmlString, reg, "");
            return new MvcHtmlString(htmlString);
        }

    }



   public class ModelHelper
    {
        public static bool IsAttr<TAttr>(Type ContainerType, string PropertyName)
            where TAttr : class
        {
            var Attr = AttributeHelper.GetCustomAttribute<TAttr>(ContainerType, PropertyName);
            return Attr != null;
        }

        public static TAttr getAttr<TAttr>(Type ContainerType, string PropertyName)
            where TAttr : class
        {
            var Attr = AttributeHelper.GetCustomAttribute<TAttr>(ContainerType, PropertyName);
            return Attr;
        }
        public static List<ModelProperty> GetModelProperty(ModelMetadata metadata)
        {
            List<ModelProperty> list = new List<ModelProperty>();
            foreach (var property in metadata.Properties)
            {
                if (property.IsComplexType) continue;//去除复杂类型

                var sortAttr = getAttr<SortAttribute>(property.ContainerType, property.PropertyName);
                var DatabaseGeneratedAttribute = getAttr<DatabaseGeneratedAttribute>(property.ContainerType, property.PropertyName);
                var showMode = getAttr<ShowModeAttribute>(property.ContainerType, property.PropertyName);
                list.Add(new ModelProperty()
                {
                    PropertyName = property.PropertyName,
                    DisplayName = property.DisplayName ?? property.PropertyName,
                    DisplayMode = showMode != null ? showMode.DisplayMode : ShowMode.Show,
                    EditMode = showMode != null ? showMode.EditMode : ShowMode.Show,
                    ListMode = showMode != null ? showMode.ListMode : ShowMode.Show,
                    CreateMode = showMode != null ? showMode.CreateMode : ShowMode.Show,
                    Sort = sortAttr != null ? sortAttr.Sort : 0,
                    IsIdentity = DatabaseGeneratedAttribute != null && DatabaseGeneratedAttribute.DatabaseGeneratedOption == DatabaseGeneratedOption.Identity,
                    IsKey = IsAttr<KeyAttribute>(property.ContainerType, property.PropertyName),
                    IsForeignKey = IsAttr<ForeignKeyAttribute>(property.ContainerType, property.PropertyName)
                });
            }
            return list.OrderBy(m => m.Sort).ToList();
        }
    }
}
