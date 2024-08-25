using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.DesignPattern.ObserverPattern;

namespace XH.DesignPattern.ObserverPattern.Observer
{
    public class Mouse : IObserver
    {

        //public Mouse(int i) { }

        public void Action()
        {
            Run();
        }
        public void Run()
        {
            Console.WriteLine("{0} Run", GetType().Name);
        }
    }
}
