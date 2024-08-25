using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.DesignPattern.ObserverPattern;

namespace XH.DesignPattern.ObserverPattern.Observer
{
    public class Father : IObserver
    {
        public void Action()
        {
            Roar();
        }
        public void Roar()
        {
            Console.WriteLine("{0} Roar", GetType().Name);
        }
    }
}
