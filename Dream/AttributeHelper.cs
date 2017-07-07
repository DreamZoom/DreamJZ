using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dream
{
    public class AttributeHelper
    {
        public static TAttribute GetCustomAttribute<TAttribute>(Type modelType, string propertyName)
            where TAttribute : class
        {
            var property = modelType.GetProperty(propertyName);

            if (property == null) return null;
            return property.GetCustomAttributes(typeof(TAttribute), false).FirstOrDefault() as TAttribute;
        }
    }
}
