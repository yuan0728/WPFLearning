using System;
using System.Collections.Generic;
using System.Text;

namespace XH.DesignPattern.ResponsibilityChainPattern
{
    public class PM : AbstractAuditor
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
            if (context.Hour <= 8)
            {
                context.AuditResult = true;
                context.AuditRemark = "PM审批通过";
            }
            else
            {
                // Pm自动转交给主管、  不在这里固定写，让别人来指定； 下一个审批者是谁呢？ 我不去指定；
                // 让别人指定下一个审批者；给一个方法，让别人来指定下一个审批者；  万一以后组织架构发生改变了， 这个锅谁背？  谁指定的下一个审批者，谁背锅； 
                //AbstractAuditor charge = new Charge()   //请假者自己去找主管审批
                //{
                //    Id = 234,
                //    Name = "诺"
                //};
                //charge.Audit(context); 
                _NextAuditor.Audit(context);   //把新一个要审批的行为转移走了；
            }
        }
    }
}
