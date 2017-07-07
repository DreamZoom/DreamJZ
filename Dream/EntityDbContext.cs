using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Dream
{
    
    public class EntityDbContext : DbContext
    {
        public EntityDbContext()
            : base("ConnectionString")
        {
            
        }

        public  IEnumerable<EntityBase> EntityTypes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var catalog = new DirectoryCatalog(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "//bin");
            var container = new CompositionContainer(catalog);
            EntityTypes = container.GetExportedValues<EntityBase>();

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EntityDbContext, Configuration<EntityDbContext>>()); 
            //modelBuilder.Configurations.AddFromAssembly()
            base.OnModelCreating(modelBuilder);

            // modelBuilder.RegisterEntityType();
            if (EntityTypes == null)
            {
                return;
            }
            foreach (var entityType in EntityTypes)
            {
                if (entityType.GetType().Name == typeof(EntityBase).Name) continue;
                modelBuilder.RegisterEntityType(entityType.GetType());
            }

            
        }
        
    }
}
