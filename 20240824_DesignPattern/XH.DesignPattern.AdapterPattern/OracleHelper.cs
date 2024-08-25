using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.DesignPattern.AdapterPattern
{
    public class OracleHelper : IHelper
    {
        public void Add<T>()
        {
            Console.WriteLine($"This is {this.GetType().Name} Add");
        }

        public void Delete<T>()
        {
            Console.WriteLine($"This is {this.GetType().Name} Delete");
        }

        public void Query<T>()
        {
            Console.WriteLine($"This is {this.GetType().Name} Query");
        }

        public void Update<T>()
        {
            Console.WriteLine($"This is {this.GetType().Name} Update");
        }
    }
}
