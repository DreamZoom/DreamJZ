using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Dream
{
    public class EntityContextProvider
    {
        /// <summary>
        /// 静态的DbContext
        /// </summary>
        public static Type ContextType { get; set; }

        /// <summary>
        /// 获取指定类型的DbContext
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <returns></returns>
        public static void RegisterFactory<TContext>()
            where TContext : DbContext
        {
            ContextType = typeof(TContext);
        }


        public static DbContext CreateInstance()
        {
            if (ContextType == null)
            {

                return new EntityDbContext();
            }
            return Activator.CreateInstance(ContextType) as DbContext;
        }
    }
}
