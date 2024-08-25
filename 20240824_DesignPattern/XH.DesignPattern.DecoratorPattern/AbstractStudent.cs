using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.DesignPattern.DecoratorPattern
{

    /// <summary>
    /// 抽象的学员
    /// </summary>
    public abstract class AbstractStudent// : Object
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public abstract void Study();
    }
}
