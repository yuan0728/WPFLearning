using System;
using System.Collections.Generic;
using System.Text;

namespace XH.DesignPattern.ResponsibilityChainPattern
{
    public class Manager : AbstractAuditor
    {
        //public int Id { get; set; }
        //public string Name { get; set; }

        public override void Audit(ApplyContext context)
        {
            if (context.Hour <= 32)
            {
                context.AuditResult = true;
                context.AuditRemark = "经理审批通过";
            }
            else
            {
                _NextAuditor.Audit(context);
            }
        }
    }
}
