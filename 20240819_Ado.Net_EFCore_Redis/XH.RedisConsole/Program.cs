using CSRedis;
using XH.RedisConsole.Hash;
using XH.RedisConsole.String;

namespace XH.RedisConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //一、程序链接Redis---必然需要C#的驱动程序
            //1.Redis Stack-------只能连接单机
            //2.Redis Exchanges---只能连接单机---要收钱
            //3.Caching.CSRedis--------最近几年刚出的----免费，可以链接哨兵模式，可以连接集群分片  首选

            //nuget：Caching.CSRedis-
            //创建链接
            {   //准备链接
                string redisConnectionString = "localhost,defaultDatabase=3,poolsize=3,tryit=0";

                string key = "key";
                using (CSRedisClient cSRedisClient = new CSRedisClient(redisConnectionString))
                {
                    cSRedisClient.Set(key, "小海study~~");
                    string sResult = cSRedisClient.Get(key);
                };
            }

            //满足各种各样的业务需求： 不同的数据结构来支持
            //8种---常见的是5种   string  hash  set  zset  list

            //string: key value 保存，保存的是字符串，也可以保存对象---把对象序列化后保存到Redis


            //二、如何使用Redis---灵活的使用--充分的理解Redis支持的数据结构
            //1.字符串类型 
            {
                {
                    //RedisStringTest redisStringService = new RedisStringTest();
                    //redisStringService.FlushAll();         //删除当前节点所有数据 
                    //redisStringService.ShowGetString();    //字符串追加
                    //redisStringService.ShowGetRange();     //下标取值范围：下标取值
                    //redisStringService.ShowGetSet();       //将给定 key 的值设为 value ，并返回 key 的旧值(old value) 
                    //redisStringService.ShowIncrBy();       //自增长
                    //redisStringService.ShowMGet();         //通过多个key,获取数据数量
                    //redisStringService.ShowMSet();         //一次插入多组key的值  
                    //redisStringService.ShowList();           // 通过key 插入list集合
                }
                //String类型，只要是字符串，都可以保存；---基本上用的可能最多的就是String 
                //场景：充分的使用Redis中 数据中的自增和自减的api
                //秒杀： 某平台，提供了10台笔记本，参与秒杀；  看谁手速快~~
                //1. 来了大量的请求，来参与秒杀~~  把好技术关---不能超卖~~  生成了20个订单~~  
                //2. Redis中每个命令都是原子性操作，独立的命令；  Redis 单线程操作----新版本中，也有多线程；
                {
                    ////new OversellTest().Show(); 
                    //new OversellTest().ShowRedis();
                }
            }


            //三、考虑String类型的问题
            {
                //RedisStringTest redisStringService = new RedisStringTest();
                //redisStringService.ShowString();
            }


            //hash数据类型
            //本质： 还是key Value   vlue可以是一个或者是多个对象 
            {

                ////RedisHashTest.HashShow();

                //RedisHashTest.ShowString();
            }

            Console.ReadLine();
        }
    }

}
