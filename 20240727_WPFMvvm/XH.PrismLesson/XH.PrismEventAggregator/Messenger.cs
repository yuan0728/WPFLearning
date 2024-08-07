using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.PrismEventAggregator
{
    public class Messenger
    {
        private Messenger() { }
        public static IEventAggregator Defualt { get; set; }
    }
}
