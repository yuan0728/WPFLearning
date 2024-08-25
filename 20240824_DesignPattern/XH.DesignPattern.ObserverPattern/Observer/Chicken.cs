using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.DesignPattern.ObserverPattern.Observer
{
    public class Chicken : IObserver
    {
        public void Action()
        {
            Woo();
        }
        public void Woo()
        {
            Console.WriteLine("{0} Woo", GetType().Name);
        }
    }
}
