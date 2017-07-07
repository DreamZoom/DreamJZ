using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Dream.Jobs.Models
{
    public class JobWorkareas : EntityBase
    {
        public int JobID { get; set; }
        [ForeignKey("JobID")]
        public virtual Job Job { get; set; }

        public int AreaID { get; set; }
        [ForeignKey("AreaID")]
        public virtual Workarea Area { get; set; }
    }
}
