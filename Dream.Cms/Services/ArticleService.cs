using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dream.Cms
{
    public class ArticleService : EntityServiceBase<Article>
    {

        public override bool Create(Article entity)
        {
            CheckOrUpdateCategory(entity);
            return base.Create(entity);
        }

        public override bool Update(Article entity)
        {
            CheckOrUpdateCategory(entity);
            return base.Update(entity);
        }


        private void CheckOrUpdateCategory(Article entity)
        {
            var cate =DbContext.Set<Category>().FirstOrDefault(m => m.CategoryName == entity.Category);
            if (cate == null)
            {
                DbContext.Set<Category>().Add(new Category() { CategoryName = entity.Category, CreateTime=DateTime.Now, Sort=99 });
            }
        }
       
    }
}
