using Microsoft.Data.SqlClient;

namespace XH.AdoNetDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // ado.net操作数据库
                //AdoNetTest.Show();

                // ERCore 操作数据库
                ERCoreTest.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
