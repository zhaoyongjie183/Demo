using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerWebapi.Model
{
    /// <summary>
    /// 测试实体
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        [DefaultValue(false)]
        public bool IsComplete { get; set; }
    }
}
