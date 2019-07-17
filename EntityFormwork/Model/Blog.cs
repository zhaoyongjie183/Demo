using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFormwork.Model
{
    public class Blog
    {
        [Key]
        [Description("主键ID")]
        public int BlogId { get; set; }
        [Required]
        [MaxLength(20)]
        [Description("URL地址")]
        public string Url { get; set; }

        [MaxLength(50)]
        public string BlogTitle { get; set; }

        [MaxLength(50)]
        public string BlogName { get; set; }
    }
}
