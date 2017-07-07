using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webdiyer.WebControls.Mvc;

namespace System.Web.Mvc
{
    public static class QueryableExtendsions
    {
        public static IPagedList<T> ToPageList<T>(this IQueryable<T> source,int pageIndex,int pageSize)
        {
            return source.ToPagedList(pageIndex, pageSize);
        }
    }
}
