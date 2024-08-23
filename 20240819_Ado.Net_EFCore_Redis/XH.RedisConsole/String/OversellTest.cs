using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.RedisConsole.String
{
    /// <summary>
    /// 超卖：订单数超过商品 
    /// 秒杀：10件商品，大用户量的来参与秒杀，同时来抢这个商品；  肯定是多个线程同时来操作
    /// 如果商品保存在数据库中：
    /// 程序设计：a.获取商品数量   b.判断是否还有库存   c.如果有库存---提示秒杀成功--减库存  d.库存再设置上去    注意：防止超卖---10商品参与秒杀，如果下了20个订单~~ 
    /// </summary>
    public class OversellTest : RedisBase
    {
        private static object Object_locker = new object();
        public void Show()
        {
            int count = 10; //初始化有10件商品

            //应为是秒杀，并发很高~~ 多线程~~ 
            //如果秒杀成功---必然要减库存~~
            List<Task> tasklist = new List<Task>();
            for (int i = 0; i < 5000; i++)
            {
                tasklist.Add(Task.Run(() =>
                {
                    int k = i;
                    //判断仓库数据量和减库存必须是原子性操作；原子的：不能拆分； 
                    lock (Object_locker)
                    {
                        if (count > 0) //获取库存，判断是否还有库存
                        {
                            //Thread.Sleep(new Random().Next(10, 30)); //随机休息  
                            count = count - 1;  //减库存
                            Console.WriteLine($"用户{k}参与秒杀，秒杀成功了。。。");
                        }
                        else
                        {
                            Console.WriteLine($"秒杀结束了...count值：{count}");
                        }
                    }
                }));
            }
            Task.WaitAll(tasklist.ToArray());
            Console.WriteLine($"所有秒杀结束后，库存应该为0 ，这里的Count：{count}");
        }



        private static bool IsGoOn = true;//秒杀活动是否结束
        public void ShowRedis()
        {
            FlushAll();
            rds.Set("Stock", 10);  //初始化商品的库存量

            for (int i = 0; i < 5000; i++)
            {
                int k = i;
                Task.Run(() =>//每个线程就是一个用户请求
                {
                    if (IsGoOn)
                    {
                        //
                        long index = rds.IncrBy("Stock", -1); //自减1并且返回  ---这个是原则性操作，不会出现中间值； 不会有超卖问题

                        if (index >= 0)
                        {
                            Console.WriteLine($"{k.ToString("000")}秒杀成功，秒杀商品索引为{index}");
                        }
                        else
                        {
                            if (IsGoOn)
                            {
                                IsGoOn = false;
                            }
                            Console.WriteLine($"{k.ToString("000")}秒杀失败，秒杀商品索引为{index}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{k.ToString("000")}秒杀停止......");
                    }
                });
            }
            Console.Read();
        }
    }

}
