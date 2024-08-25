using System;
using System.Collections.Generic;
using System.Text;

namespace XH.DesignPattern.ResponsibilityChainPattern.Builder
{
    public class AuditorWorkFlowsNewBuild : IBuilder
    {
        public AbstractAuditor Build()
        {
            AbstractAuditor pm = new PM();
            AbstractAuditor manager = CreateManager();
            pm.SetNextAuditor(manager);
            return pm;
        }

        public AbstractAuditor CreateCharge()
        {
            return new Charge();
        }

        public AbstractAuditor CreateManager()
        {
            return new Manager();
        }
    }
}
