using CSRedis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.WPFClient.Utility
{
    public class RedisBase
    {
        ////测试 redis-cluster 不能设置 defaultDatabase

        protected CSRedisClient rds = new CSRedisClient("127.0.0.1,defaultDatabase=0,poolsize=3,tryit=0");


        public RedisBase()
        {
            //rds.NodesServerManager.FlushAll();
        }

        /// <summary>
        /// 配置操作哪个节点
        /// </summary>
        /// <param name="nodeIndex"></param>
        public void ConfigNode(string nodeIndex)
        {

        }

        /// <summary>
        /// 删除所有节点信息
        /// </summary>
        public void FlushAll()
        {
            rds.NodesServerManager.FlushAll();
        }

        /// <summary>
        /// 优先获取redis中的数据，如果没有想要获取的数据的数据，就执行委托
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">redis的key</param>
        /// <param name="func">包装查询数据库的逻辑</param>
        /// <returns></returns>
        protected T GetCacheData<T>(string key,Func<T> func) where T : class
        {
            T t = rds.Get<T>(key);
            if (t == null) // redis里面没有数据
            {
                t = func.Invoke();
                rds.Set(key, t);
            }
            return t;
        }
    }

}
