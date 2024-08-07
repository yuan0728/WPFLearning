using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.PrismEventAggregator
{

    // 无参数触发
    public class EventMessage : PubSubEvent { }

    // 参数触发
    public class EventMessageArgs : PubSubEvent<object> { }

    // 类型参数触发
    public class EventMessageArgsList<T> : PubSubEvent<T> { }

    public class EventAction
    {
        public Action<bool> ResultAction { get; set; }
    }
}
