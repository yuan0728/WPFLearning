using System;
using System.Collections.Generic;
using System.Text;

namespace XH.DesignPattern.ResponsibilityChainPattern.Builder
{
    /// <summary>
    /// 建造者；可能需要创建很多对象，然后要组装；
    /// </summary>
    public interface IBuilder
    {

        public AbstractAuditor CreateCharge();

        public AbstractAuditor CreateManager();

        //建造者：最终要建造一个审批的开始节点； 
        public AbstractAuditor Build();
    }
}
