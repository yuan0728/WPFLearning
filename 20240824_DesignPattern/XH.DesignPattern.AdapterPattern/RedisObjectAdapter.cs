using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.DesignPattern.AdapterPattern
{
    /// <summary>
    /// Redis 对象适配器
    /// </summary>
    public class RedisObjectAdapter : IHelper
    {
        private readonly RedisHelper redisHelper = new RedisHelper();

        //public RedisObjectAdapter(RedisHelper _redisHelper)
        //{
        //    redisHelper = _redisHelper;
        //}

        public void Add<T>()
        {
            redisHelper.AddRedis<T>();
        }

        public void Delete<T>()
        {
            redisHelper.DeleteRedis<T>();
        }

        public void Query<T>()
        {
            redisHelper.QueryRedis<T>();
        }

        public void Update<T>()
        {
            redisHelper.UpdateRedis<T>();
        }
    }
}
