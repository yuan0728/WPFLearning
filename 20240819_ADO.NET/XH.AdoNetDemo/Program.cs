using Microsoft.Data.SqlClient;

namespace XH.AdoNetDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ado.net操作数据库
            try
            {
                // 1、准备数据的连接字符串
                // 账号：sa 密码：abc123
                //string connectionString = @"Data Source=LITTLESEAPAD;Initial Catalog=XiaoHaiStudy;Persist Security Info=True;
                //            User ID=sa;Password=abc123;Trust Server Certificate=True";
                string connectionString = @"Data Source=LITTLESEAPAD;Initial Catalog=XiaoHaiStudy;Persist Security Info=True;
                            User ID=sa;Password=***********;Trust Server Certificate=True";
                // 2、准备数据库操作的命令 -- SQL语句
                string sql = @"select id,name,course,score from scoreinfo";
                // 3、准备数据库的连接对象
                // NuGet安装程序集：Microsoft.Data.SqlClient
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // 4、打开数据库连接
                    connection.Open();

                    // 5、准备命令执行对象
                    //SqlCommand sqlCommand = new SqlCommand(sql, connection);
                    SqlCommand sqlCommand = connection.CreateCommand();

                    // 6、赋值要执行的Sql命令
                    sqlCommand.CommandText = sql;

                    // 执行一个读取器 读取数据 -- 查询的结果
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();

                    if (dataReader.Read())
                    {
                        Console.WriteLine(dataReader["id"].ToString().Trim());
                        Console.WriteLine(dataReader["name"].ToString().Trim());
                        Console.WriteLine(dataReader["course"].ToString().Trim());
                        Console.WriteLine(dataReader["score"].ToString().Trim());
                    }

                    // 返回执行结果后 受影响的行数--（一般是执行增删改的命令）
                     int iResult = sqlCommand.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
