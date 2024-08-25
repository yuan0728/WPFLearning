using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.DesignPattern.ObserverPattern;

namespace XH.DesignPattern.ObserverPattern.Observer
{
    public class Neighbor : IObserver
    {
        public void Action()
        {
            Awake();
        }
        public void Awake()
        {
            Console.WriteLine("{0} Awake", GetType().Name);
        }
    }
}
