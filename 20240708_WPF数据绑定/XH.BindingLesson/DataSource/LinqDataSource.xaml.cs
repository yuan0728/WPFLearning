using Microsoft.Data.Sqlite;
using SQLitePCL;
using System.Data;
using System.Windows;

namespace XH.BindingLesson.DataSource
{
    /// <summary>
    /// LinqDataSource.xaml 的交互逻辑
    /// </summary>
    public partial class LinqDataSource : Window
    {
        public LinqDataSource()
        {
            InitializeComponent();

            // 初始化 SQLitePCL 库
            Batteries.Init();
            string connectionString = $"Data Source=test.db;";
            string conStr = "Data Source=test.db";
            using (SqliteConnection connection = new SqliteConnection(conStr))
            {
                connection.Open();
                string query = "SELECT * FROM sys_user";
                SqliteCommand command = new SqliteCommand(query, connection);

                SqliteDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                // 转换为匿名对象
                var result = from q in dt.AsEnumerable() 
                             where q.Field<string>("name").ToString() == "张三" 
                             select new 
                             { 
                                Id = int.Parse(q["_id"].ToString()),
                                Age = q.Field<string>("age").ToString(),
                                Name = q.Field<string>("name").ToString()
                             };

                this.lv.ItemsSource = result;
                this.dg.ItemsSource = result;
            }

        }
    }
}
