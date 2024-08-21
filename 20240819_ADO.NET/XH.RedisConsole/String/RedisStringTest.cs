using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.RedisConsole.String
{
    /// <summary>
    /// 
    /// </summary>
    public class RedisStringTest : TestBase
    {
        /// <summary>
        /// 字符串追加
        /// </summary>
        public void ShowGetString()
        {
            rds.NodeServerManager("1").FlushAll();
            {
                var key = "TestAppend_null";
                rds.Set(key, String);
                rds.Append(key, Null); //追加
                string result = rds.Get(key);
                Console.WriteLine("==============================");
                Console.WriteLine(result);
            }
            {
                string key = "TestAppend_string";
                rds.Set(key, String);
                rds.Append(key, String);
                string result1 = rds.Get(key);

                Console.WriteLine("==============================");
                Console.WriteLine(result1);

                MemoryStream ms = new MemoryStream();
                rds.Get(key, ms);  //获取到字符串保存到内存流中去
                string result2 = Encoding.UTF8.GetString(ms.ToArray());
                Console.WriteLine("==============================");
                Console.WriteLine(result2);
                ms.Close();
            }

            {
                string key = "TestAppend_bytes";
                rds.Set(key, Bytes);
                rds.Append(key, Bytes);
                var result = Convert.ToBase64String(rds.Get<byte[]>(key));
                Console.WriteLine("==============================");
                Console.WriteLine(result);
            }
        }

        /// <summary>
        /// 下标取值
        /// </summary>
        public void ShowGetRange()
        {
            {
                string key = "TestGetRange_null";
                rds.Set(key, Null);

                Console.WriteLine("==============================");
                Console.WriteLine(rds.GetRange(key, 10, 20));  //超出索引下标取值，不报错，返回空字符串
            }

            {
                string key = "TestGetRange_string";
                rds.Set(key, "abcdefg");

                Console.WriteLine("==============================");
                Console.WriteLine(rds.GetRange(key, 2, 4));  //索引下标取值

                Console.WriteLine("==============================");
                Console.WriteLine(rds.GetRange(key, 0, -1)); //索引下标取值，结束索引为-1 即为取值到最后一个字符串
            }

            {
                string key = "TestGetRange_bytes";
                rds.Set(key, Bytes);

                Console.WriteLine("==============================");
                Console.WriteLine(rds.GetRange<byte[]>(key, 2, 4));

                Console.WriteLine("==============================");
                Console.WriteLine(rds.GetRange<byte[]>(key, 0, -1));
            }

        }

        /// <summary>
        ///  将给定 key 的值设为 value ，并返回 key 的旧值(old value)
        /// </summary>
        public void ShowGetSet()
        {
            {
                string key = "TestGetSet_null";
                rds.Set(key, Null);

                Console.WriteLine("==============================");
                //GetSet： 将给定 key 的值设为 value ，并返回 key 的旧值(old value)
                Console.WriteLine(rds.GetSet(key, Null));

            }
            {


                FlushAll();
                string key = "TestGetSet_string";
                rds.Set(key, String);

                Console.WriteLine("==============================");
                Console.WriteLine(rds.GetSet(key, "newvalue"));
                Console.WriteLine("==============================");
                Console.WriteLine(rds.Get(key));
            }

            {
                string key = "TestGetSet_bytes";
                rds.Set(key, Bytes);
                Console.WriteLine("==============================");
                Console.WriteLine(rds.GetSet<byte[]>(key, "newvalue"));

                Console.WriteLine("==============================");
                Console.WriteLine(rds.Get(key));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowIncrBy()
        {
            {
                string key = "TestIncrBy_null";
                Console.WriteLine("==============================");
                Console.WriteLine(rds.IncrBy(key, 1));

                Console.WriteLine("==============================");
                Console.WriteLine(rds.IncrBy(key, 1));

                Console.WriteLine("==============================");
                Console.WriteLine(rds.IncrBy(key, 11));

                Console.WriteLine("==============================");
                Console.WriteLine(rds.IncrBy(key, -1));

                Console.WriteLine("==============================");
                Console.WriteLine(rds.IncrBy(key, -1));

                Console.WriteLine("==============================");
                Console.WriteLine(rds.IncrBy(key, -11));

                //Console.WriteLine("==============================");
                //Console.WriteLine(rds.IncrByFloat(key, 10.5m));
            }
        }

        /// <summary>
        /// 通过多个key 获取多个值
        /// </summary>
        public void ShowMGet()
        {
            rds.Set("TestMGet_null1", Null);
            rds.Set("TestMGet_string1", String);
            rds.Set("TestMGet_bytes1", Bytes);
            rds.Set("TestMGet_class1", Class);
            rds.Set("TestMGet_null2", Null);
            rds.Set("TestMGet_string2", String);
            rds.Set("TestMGet_bytes2", Bytes);
            rds.Set("TestMGet_class2", Class);
            rds.Set("TestMGet_null3", Null);
            rds.Set("TestMGet_string3", String);
            rds.Set("TestMGet_bytes3", Bytes);
            rds.Set("TestMGet_class3", Class);

            Console.WriteLine("==============================");
            Console.WriteLine(rds.MGet("TestMGet_null1", "TestMGet_string1", "TestMGet_bytes1", "TestMGet_class1").Length);


            Console.WriteLine("==============================");
            Console.WriteLine(rds.MGet("TestMGet_null1", "TestMGet_string1", "TestMGet_bytes1", "TestMGet_class1")[0]);
        }

        /// <summary>
        /// 同时写入多组key-value的值
        /// </summary>
        public void ShowMSet()
        {
            rds.MSet("TestMSet_null1", Null, "TestMSet_string1", String, "TestMSet_bytes1", Bytes, "TestMSet_class1", Class);
            Console.WriteLine(rds.MGet("TestMSet_null1", "TestMSet_string1", "TestMSet_bytes1", "TestMSet_class1"));
        }



        public void ShowString()
        {

            rds.NodeServerManager("1").FlushAll();

            string key = "keyString";
            UserInfo user = new UserInfo()
            {
                Id = 123,
                Name = "其乐无穷",
                Age = 25
            };
            rds.Set(key, user);



            //如果要修改用户数据的属性值呢？
            //1.查询出来
            //2.修改
            //3.保存进去

            UserInfo user1 = rds.Get<UserInfo>(key);
            user1.Name = "XiaoHai";
            rds.Set(key, user1);

            //操作的时候，必须要做原子性操作
            //多线程并发的时候，是可能出现并发问题的；

        }

        public void ShowList()
        {
            rds.NodeServerManager("1").FlushAll();

            string key = "keyString";
            UserInfo user = new UserInfo()
            {
                Id = 123,
                Name = "其乐无穷",
                Age = 25
            };
            rds.Set(key, user);
        }
    }

}
