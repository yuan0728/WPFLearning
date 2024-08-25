using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.DesignPattern.ObserverPattern;

namespace XH.DesignPattern.ObserverPattern.Observer
{
    public class Stealer : IObserver
    {
        public void Action()
        {
            Hide();
        }
        public void Hide()
        {
            Console.WriteLine("{0} Hide", GetType().Name);
        }
    }
}
