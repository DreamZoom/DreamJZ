using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Data.Entity.Migrations;

namespace Dream
{
    /// <summary>
    /// 实体业务基类，包括增删改查等操作
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class EntityServiceBase<TEntity>
        where TEntity : EntityBase
    {
        /// <summary>
        /// 实体Context
        /// </summary>
        protected DbContext DbContext { get; set; }

        public EntityServiceBase()
        {
            
            //if (EntityDbContext.EntityTypes == null) EntityDbContext.EntityTypes = new List<Type>();
            //var entityType = EntityDbContext.EntityTypes.FirstOrDefault(m=>(m==typeof(TEntity)));
            //if (entityType == null) EntityDbContext.EntityTypes.Add(typeof(TEntity));
            DbContext = new EntityDbContext();
            //DbContext.Set<TEntity>().AddOrUpdate();
            
        }

        public virtual DbContext GetDbContext()
        {
            return EntityContextProvider.CreateInstance();
        }

        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Create(TEntity entity)
        {
            DbContext.Entry<TEntity>(entity).State = EntityState.Added;
            return DbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Update(TEntity entity)
        {
            var orginEntity = DbContext.Set<TEntity>().Find(entity.ID);
            DbContext.Entry<TEntity>(orginEntity).State = EntityState.Detached;
            DbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            return DbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Delete(TEntity entity)
        {
            DbContext.Entry<TEntity>(entity).State = EntityState.Deleted;
            return DbContext.SaveChanges() > 0;
        }
        public virtual bool Delete(int Id)
        {
            var model = Get(Id);
            Delete(model);
            return DbContext.SaveChanges() > 0;
        }
        public virtual bool DeleteList(int[] IdList)
        {
            var list = GetList().Where(m => IdList.Contains(m.ID));

            DbContext.Set<TEntity>().RemoveRange(list);
            return DbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public virtual TEntity Get(params object[] keyValues)
        {
            return DbContext.Set<TEntity>().Find(keyValues);
        }

        /// <summary>
        /// 获得实体集
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetList()
        {
            return DbContext.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetList(RequestContext context)
        {
            return GetList();
        }


        public virtual TEntity FindById(int Id)
        {
            return DbContext.Set<TEntity>().Where(m => m.ID == Id).FirstOrDefault();
        }
       
    }
}
