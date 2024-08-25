using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.DesignPattern.AdapterPattern
{
    /// <summary>
    /// Redis 适配器
    /// </summary>
    public class RedisClassAdapter : RedisHelper, IHelper
    {
        public void Add<T>()
        {
            base.AddRedis<T>();
        }

        public void Delete<T>()
        {
            base.DeleteRedis<T>();
        }

        public void Query<T>()
        {
            base.QueryRedis<T>();
        }

        public void Update<T>()
        {
            base.UpdateRedis<T>();
        }
    }
}
