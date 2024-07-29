using Microsoft.Data.Sqlite;
using SQLitePCL;
using System.Data;
using System.Windows;

namespace XH.BindingLesson.DataSource
{
    /// <summary>
    /// ADODataSourceWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ADODataSourceWindow : Window
    {
        public ADODataSourceWindow()
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

                this.lv.ItemsSource = dt.DefaultView;
                this.dg.ItemsSource = dt.DefaultView;
                this.ic.ItemsSource = dt.DefaultView;

            }
        }
    }
}
