using Dream.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream.Jobs.Models
{
    public class Job : EntityBase
    {

        public Job()
        {
            Workareas = new List<JobWorkareas>();
        }

        /// <summary>
        /// 职位名称
        /// </summary>
        [Display(Name = "职位图标")]
        [Image]
        [ShowMode(ListMode = ShowMode.Hidden)]
        public string JobLogo { get; set; }

        /// <summary>
        /// 职位名称
        /// </summary>
        [Display(Name = "职位名称")]
        public string JobName { get; set; }

        /// <summary>
        /// 工作区域
        /// </summary>
        /// 
        //[Display(Name = "工作区域")]
        //[Select(Title = "区域",  Name = "AreaName", NameTitle = "区域", ControllerName = "Workarea")]
        //public int WorkareaID { get; set; }

        //[ForeignKey("WorkareaID")]

        //public virtual Workarea Workarea { get; set; }

        [Display(Name = "工作区域")]
        [Select(Title = "区域", Name = "AreaName", NameTitle = "区域", ControllerName = "Workarea", SelectMode = 2)]
        public string WorkareaIDs { get; set; }
        [JsonIgnore]
        public virtual ICollection<JobWorkareas> Workareas { get; set; }
        public virtual string WorkareaNames()
        {
            return string.Join(",",this.Workareas.ToList().ConvertAll(m=>m.Area.AreaName));
        }


        /// <summary>
        /// 标签ID
        /// </summary>
        [Select(Title = "选择标签", Name = "TagName", NameTitle = "标签", ControllerName = "JobTag")]
        [Display(Name = "职位分类")]
        public int TagID { get; set; }

        [ForeignKey("TagID")]

        public virtual JobTag Tag { get; set; }


        [JsonIgnore]
        public virtual ICollection<JobRecord> JobRecords { get; set; }

        public bool IsOver()
        {
            if (EndTime < DateTime.Now)
            {
                return true;
            }

            if (JobRecords.Where(m => !m.IsCancel).Count() >= NeedPeopleCount)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 职位类型
        /// </summary>
        [UIHint("Enum")]
        [Display(Name = "职位类型")]
        public EnumJobType JobType { get; set; }



        /// <summary>
        /// 招聘公司
        /// </summary>
        [Display(Name = "招聘公司")]
        public string Company { get; set; }

        [Display(Name = "联系方式")]
        public string CompanyTell { get; set; }

        /// <summary>
        /// 健康证
        /// </summary>
        [Display(Name = "健康证")]
        [Switch(Yes = "是", No = "否")]
        public bool RequireHealth { get; set; }


        /// <summary>
        /// 性别要求
        /// </summary>
        [Display(Name = "性别要求")]
        [UIHint("Enum")]
        public EnumSex RequireSex { get; set; }


        /// <summary>
        /// 身高要求
        /// </summary>
        [Display(Name = "身高要求")]
        public string RequireHeight { get; set; }


        /// <summary>
        /// 年龄要求
        /// </summary>
        [Display(Name = "年龄要求")]
        public string RequireAge { get; set; }





        [Display(Name = "工资待遇")]
        public string Salary { get; set; }
        /// <summary>
        /// 待遇结算周期
        /// </summary>
        [UIHint("Enum")]
        [Display(Name = "待遇结算周期")]
        public EnumUnit Unit { get; set; }

        /// <summary>
        /// 招聘人数
        /// </summary>
        /// 
        [Display(Name = "招聘人数")]
        public int NeedPeopleCount { get; set; }

        /// <summary>
        /// 工作描述
        /// </summary>
        [Display(Name = "职位描述")]
        [ShowMode(ListMode = ShowMode.Hidden)]
        [RichText]
        public string JobDescription { get; set; }



        /// <summary>
        /// 工作描述
        /// </summary>
        [Display(Name = "职位要求")]
        [ShowMode(ListMode = ShowMode.Hidden)]
        [RichText]
        public string JobRequire { get; set; }

        [Display(Name = "备注")]
        [ShowMode(ListMode = ShowMode.Hidden)]
        [RichText]
        public string JobRemark { get; set; }


        /// <summary>
        /// 招聘结束时间
        /// </summary>
        [Display(Name = "招聘结束时间")]
        public DateTime EndTime { get; set; }

        [Display(Name = "工作时间")]
        public string WorkTime { get; set; }

        [Display(Name = "设为热门")]
        [Switch(Yes = "是", No = "否")]
        public bool IsHot { get; set; }

        [Display(Name = "设为推荐")]
        [Switch(Yes = "是", No = "否")]
        public bool IsRecommend { get; set; }

        [Display(Name = "设为置顶")]
        [Switch(Yes = "是", No = "否")]
        public bool IsTop { get; set; }
    }
}
