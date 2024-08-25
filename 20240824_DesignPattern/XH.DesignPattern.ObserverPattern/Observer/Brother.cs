using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.DesignPattern.ObserverPattern;

namespace XH.DesignPattern.ObserverPattern.Observer
{
    public class Brother : IObserver
    {
        public void Action()
        {
            Turn();
        }
        public void Turn()
        {
            Console.WriteLine("{0} Turn", GetType().Name);
        }
    }
}
