using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.DesignPattern.ObserverPattern;

namespace XH.DesignPattern.ObserverPattern.Observer
{
    public class Mother : IObserver
    {
        public void Action()
        {
            Whisper();
        }
        public void Whisper()
        {
            Console.WriteLine("{0} Whisper", GetType().Name);
        }
    }
}
