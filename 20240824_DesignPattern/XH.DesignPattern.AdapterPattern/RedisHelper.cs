using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.DesignPattern.AdapterPattern
{
    public class RedisHelper
    {
        /// <summary>
        /// 第三方提供的sdk
        /// </summary>
        public RedisHelper()
        {
            Console.WriteLine("构造RedisHelper");
        }
        public void AddRedis<T>()
        {
            Console.WriteLine($"This is {this.GetType().Name} AddRedis");
        }

        public void DeleteRedis<T>()
        {
            Console.WriteLine($"This is {this.GetType().Name} DeleteRedis");
        }

        public void QueryRedis<T>()
        {
            Console.WriteLine($"This is {this.GetType().Name} QueryRedis");
        }

        public void UpdateRedis<T>()
        {
            Console.WriteLine($"This is {this.GetType().Name} UpdateRedis");
        }
    }
}
