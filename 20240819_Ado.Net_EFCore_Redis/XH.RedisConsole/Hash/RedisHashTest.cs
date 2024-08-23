using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.RedisConsole.Hash
{
    public class RedisHashTest
    {

        /// <summary>
        /// 新增和判断是否存在
        /// </summary>
        public static void HashShow()
        {
            RedisHashService rds = new RedisHashService();
            {
                rds.FlushAll();
                {
                    // 同时将多个 field-value (域-值)对设置到哈希表 key 中
                    rds.HMSet("TestHDel", "string1", "name", "bytes1", "25", "class1", new UserInfo() { Name = "XiaoHai", Id = 123 });

                    //删除一个或多个哈希表字段
                    rds.HDel("TestHDel", "string1", "bytes1", "class1");

                    // 查看哈希表 key 中，指定的字段是否存在
                    bool exists = rds.HExists("TestHExists", "null1");
                    Console.WriteLine(exists);

                    //将哈希表 key 中的字段 field 的值设为 value
                    rds.HSet("TestHExists", "null1", 1);

                    //查看哈希表 key 中，指定的字段是否存在
                    exists = rds.HExists("TestHExists", "null1");
                    Console.WriteLine(exists);

                    //删除一个或多个哈希表字段
                    rds.HDel("TestHExists", "null1");

                    //查看哈希表 key 中，指定的字段是否存在
                    exists = rds.HExists("TestHExists", "null1");

                }

                {
                    string result1 = rds.HGet("TestHGet", "null1");
                }
            }
        }


        public static void HashSaveObject()
        {
            RedisHashService rds = new RedisHashService();
            {
                rds.FlushAll();

                string hashKey1 = "userhashkey1";
                rds.HMSet(hashKey1, "Name", "Eleven", "Password", "123465", "Age", "37", "Addredd", "湖北武汉");

                //string hashKey2 = "userhashkey2";
                //rds.HMSet(hashKey2, "Name", "Richard", "Password", "123465", "Age", "37", "Addredd", "湖北武汉","sex","1");

                //如果我需要修改下数据呢？
                rds.HSet(hashKey1, "Password", "456789");  //一条命令来完成对象的修改
                //一条命令---原子性操作 
            }
        }


        /// <summary>
        /// 在使用Redis的时候，尽可能的去完成原子性操作，对于一个业务处理，尽量不要去搞多个操作；
        /// Redis 不怕频繁---就是在web2.0时代，承担高并发的问题，
        /// 
        /// 保存：api中，保存一个到数据库中去，同时保存一个在redis中，redis  ---缓存（过期时间，例如3分钟时间有效期），获取数据，先尝试在缓存（Redis）中去获取，如果没有，再查询数据库；
        /// 
        /// 预告下：明天晚上，继续完成关于Redis这块的案例，还有就是时序数据库；
        /// 
        /// 
        /// </summary>

        public static void ShowString()
        {
            RedisHashService rds = new RedisHashService();
            rds.FlushAll();

            string key = "keyString";
            UserInfo user = new UserInfo()
            {
                Id = 123,
                Name = "其乐无穷",
                Age = 25
            };

            //rds.HMSet(key, "Id", 123, "Name", "其乐无穷", "Age", 25);
            
            // 反射
            foreach (var prop in user.GetType().GetProperties())
            {
                rds.HMSet(key, prop.Name, prop.GetValue(user));
            }

            //string key1 = "key1";
            //for (int i = 0; i < 10; i++)
            //{
            //    rds.HMSet(key1, $"{i}_key", $"{i}_Value");
            //}



            //如果要修改用户数据的属性值呢？
            //可以直接去修改某一个字段的值 
            rds.HSet(key, "Name", "更加其乐无穷");   //这里只是依据命令的操作，原子性命令，不可再分；  不会有多线程并发安全问题； 
            //hash---一个key  对应 一个对象( 对象的属性是完全灵活的，可以有任意的个数)；   一个标识对应 跟数据库中的一条记录一样；

        }
    }

}
