namespace XH.DesignPattern.AdapterPattern
{
    /// <summary>
    /// 适配器设计模式
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            // SqlServer
            IHelper helper = new SqlServerHelper();
            helper.Add<Program>();
            helper.Delete<Program>();
            helper.Update<Program>();
            helper.Query<Program>();

            // MySql
            helper = new MySqlHelper();
            helper.Add<Program>();
            helper.Delete<Program>();
            helper.Update<Program>();
            helper.Query<Program>();

            // Oracle
            helper = new OracleHelper();
            helper.Add<Program>();
            helper.Delete<Program>();
            helper.Update<Program>();
            helper.Query<Program>();

            // 为了性能优化 改为了缓存
            // Redis
            // 需要使用Redis 但是不能直接使用 需要适配器
            //helper = new RedisHelper();
            //helper.Add<Program>();
            //helper.Delete<Program>();
            //helper.Update<Program>();
            //helper.Query<Program>();

            // 适配器代码
            // 同过接口+继承实现了 Redis的适配
            // 类适配器：
            //  1.只能为一种类型进行服务
            //  2.侵入性：拥有了一些本来不该他拥有的东西
            helper = new RedisClassAdapter();
            helper.Add<Program>();
            helper.Delete<Program>();
            helper.Update<Program>();
            helper.Query<Program>();

            // 对象适配器：
            //  1.没有侵入性：安全性比较高
            //  2.可以通过构造函数为多个类型服务 
            helper = new RedisObjectAdapter();
            helper.Add<Program>();
            helper.Delete<Program>();
            helper.Update<Program>();
            helper.Query<Program>();
            
            // 只要是适配器 都需要一个全新的适配器类：把我们需要匹配的类或者接口  统一做一个包装
            // 使用情况：当需要接入进来新的东西的时候，就要通过适配器来适配

        }
    }
}
