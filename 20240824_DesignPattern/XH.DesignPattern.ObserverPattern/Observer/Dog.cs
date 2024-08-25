using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.DesignPattern.ObserverPattern;

namespace XH.DesignPattern.ObserverPattern.Observer
{
    public class Dog : IObserver
    {
        public void Action()
        {
            Wang();
        }
        public void Wang()
        {
            Console.WriteLine("{0} Wang", GetType().Name);
        }
    }
}
