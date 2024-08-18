using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.AutofacIoc
{
    public class Man : IPerson
    {
        public Man()
        {
            
        }
        public Man(string arg)
        {
            
        }
        public int Vlaue { get; set; } = 100;

        public void Dispose()
        {
            Console.WriteLine("正在Man类中执行释放资源");
        }

        public void SayHello()
        {
            Console.WriteLine("Man Say Hello");
        }
    }
}
