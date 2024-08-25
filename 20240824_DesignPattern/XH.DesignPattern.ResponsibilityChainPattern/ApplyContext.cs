using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.DesignPattern.ResponsibilityChainPattern
{
    /// <summary>
    /// 请假申请--
    /// Context上下文：保存参数-中间变量-中间结果-最终结果
    /// </summary>
    public class ApplyContext
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 请假时长
        /// </summary>
        public int Hour { get; set; }
        public string Description { get; set; }
        public bool AuditResult { get; set; }
        public string AuditRemark { get; set; }
    }
}
