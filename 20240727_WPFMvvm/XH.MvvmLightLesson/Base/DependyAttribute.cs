using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.MvvmLightLesson.Base
{
    // 只能够用在Property上 属性上
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public class DependyAttribute:Attribute
    {
        public DependyAttribute()
        {
            
        }
        public string Token { get; set; }
        public DependyAttribute(string token = "")
        {
            Token = token;
        }
    }
}
