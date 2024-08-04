using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.MvvmLightLesson.Base
{
    public class MessageBase
    {
        public string Value { get; set; }
        public Action<bool> Action { get; set; }
    }
}
