using System;
using System.Collections.Generic;
using System.Text;

namespace XH.DesignPattern.ResponsibilityChainPattern.Builder
{
    public class AuditorWorkFlowsBuild : IBuilder
    {
        public AbstractAuditor Build()
        {
            AbstractAuditor pm = new PM();
            AbstractAuditor charge = CreateCharge();
            AbstractAuditor manager = CreateManager();
            pm.SetNextAuditor(charge);
            charge.SetNextAuditor(manager);
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
