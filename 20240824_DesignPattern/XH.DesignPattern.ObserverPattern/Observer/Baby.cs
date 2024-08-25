using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.DesignPattern.ObserverPattern;

namespace XH.DesignPattern.ObserverPattern.Observer
{
    public class Baby : IObserver
    {
        public void Action()
        {
            Cry();
        }

        public void Cry()
        {
            Console.WriteLine("{0} Cry", GetType().Name);
        }
    }
}
