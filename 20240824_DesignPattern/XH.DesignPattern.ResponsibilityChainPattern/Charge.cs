using System;
using System.Collections.Generic;
using System.Text;

namespace XH.DesignPattern.ResponsibilityChainPattern
{
    public class Charge : AbstractAuditor
    {
        //public AbstractAuditor _NextAuditor;

        ///// <summary>
        ///// 用作设置下一个审批者
        ///// </summary>
        ///// <param name="nextAuditor"></param>
        //public void SetNextAuditor(AbstractAuditor nextAuditor)
        //{
        //    _NextAuditor = nextAuditor;
        //}



        //public int Id { get; set; }
        //public string Name { get; set; }

        public override void Audit(ApplyContext context)
        {
            if (context.Hour <= 16)
            {
                context.AuditResult = true;
                context.AuditRemark = "主管审批通过";
            }
            else
            {
                //AbstractAuditor manager = new Manager()
                //{
                //    Id = 345,
                //    Name = "麦子熟了"
                //};
                //manager.Audit(context);

                _NextAuditor.Audit(context);
            }
        }
    }
}
