using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FRManager.Models
{
    public class DyanamicDataModel
    {
        [Required]
        [Key]
        public int mac { set; get; }

   

        [Required]
        public string user_name { set; get; }
        
        [Range(1, 100)]
        public int cpu_usage { set; get; }
        [Range(1, 100)]
        public int memory_usage { set; get; }
        [Range(1, 100)]
        public int disk_free_space { set; get; }

        public DateTime record_date { set; get; }

        [RegularExpression(@"^([0-9]|[1-9][0-9]|1([0-9][0-9])|2([0-4][0-9]|5[0-5]))\.([0-9]|[1-9][0-9]|1([0-9][0-9])|2([0-4][0-9]|5[0-5]))\.([0-9]|[1-9][0-9]|1([0-9][0-9])|2([0-4][0-9]|5[0-5]))\.([0-9]|[1-9][0-9]|1([0-9][0-9])|2([0-4][0-9]|5[0-5]))$")]
        [StringLength(15, MinimumLength = 7)]
        public string iq_address { set; get; }
       


    }
    //public class RunningAppsModel
    //{
        
    //    public string mac { set; get; }
    //}

    public class DynamicDBContext1 : DbContext
    {
        public DbSet<DyanamicDataModel> DynamicDatabase { get; set; }
    }
}