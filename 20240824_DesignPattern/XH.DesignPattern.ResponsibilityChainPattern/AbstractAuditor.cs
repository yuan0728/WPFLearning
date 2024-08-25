using System;
using System.Collections.Generic;
using System.Text;

namespace XH.DesignPattern.ResponsibilityChainPattern
{
    public abstract class AbstractAuditor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // 因为必须有此方法 所以必须是抽象方法abstract修饰 
        public abstract void Audit(ApplyContext context);

        /// <summary>
        /// 下一个审批者
        /// </summary>
        protected AbstractAuditor _NextAuditor;

        /// <summary>
        /// 用作设置下一个审批者
        /// </summary>
        /// <param name="nextAuditor">下一个审批者</param>
        public void SetNextAuditor(AbstractAuditor nextAuditor)
        {
            _NextAuditor = nextAuditor;
        }

    }
}
