using Dream.Jobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream.Jobs.Services
{
    public class JobService : EntityServiceBase<Job>
    {
        public override bool Create(Job entity)
        {
            var result = base.Create(entity);
            string[] ids = entity.WorkareaIDs.Split(',');
            var wls = this.GetDbContext().Set<Workarea>().Where(m => ids.Contains(m.ID.ToString())).ToList();
            JobWorkareasService JobWorkareasService = new JobWorkareasService();
            foreach (var w in wls)
            {
                JobWorkareasService.Create(new JobWorkareas() { JobID = entity.ID , AreaID = w.ID});
            }
            return result;
        }

        public override bool Update(Job entity)
        {
            JobWorkareasService JobWorkareasService = new JobWorkareasService();
            var job = this.GetDbContext().Set<Job>().Find(entity.ID);
            string[] ids = entity.WorkareaIDs.Split(',');

            var wls = this.GetDbContext().Set<Workarea>().Where(m => ids.Contains(m.ID.ToString())).ToList();

            var els = job.Workareas.ToList();
            foreach (var w in wls)
            {
                if (!els.Exists(m => m.AreaID == w.ID))
                {
                    JobWorkareasService.Create(new JobWorkareas() { JobID = entity.ID, AreaID = w.ID });
                }
            }

            foreach (var e in els)
            {
                if (!wls.Exists(m => m.ID == e.AreaID))
                {
                    JobWorkareasService.Delete(e.ID);                   
                }
            }
            return base.Update(entity);
        }
    }
}
