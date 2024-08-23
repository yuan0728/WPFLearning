using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.AdoNetDemo.Contexts;
using XH.AdoNetDemo.Models;

namespace XH.AdoNetDemo
{
    public class ERCoreTest
    {
        // EFCore的使用
        public static void Show()
        {
            // 1.NuGet：核心应用程序：Microsoft.EntityFrameworkCore
            //          数据库驱动程序：Microsoft.EntityFrameworkCore.SqlServer
            //          帮助类库：Microsoft.EntityFrameworkCore.Tools

            // 2.准备和数据库完全匹配的实体对象，还有DbContext -- 可以生成
            // 自动生成命令
            // Scaffold-DbContext "数据库连接字符串" Microsoft.EntityFrameworkCore.SqlServer -OutputDir {Models文件夹目录} -ContextDir {Contexts文件夹目录} -Force
            /*命令：
                Scaffold-DbContext "Data Source=LITTLESEAPAD;Initial Catalog=XiaoHaiStudy; Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Contexts -Force
            */
            // 3.操作DbContext
            ScoreInfo scoreInfo = new ScoreInfo()
            {
                Name = "小帅",
                Course = "语文",
                Score = 100
            };

            using (XiaoHaiStudyDbContext context = new XiaoHaiStudyDbContext())
            {
                context.Add(scoreInfo);
                // 提交保存
                context.SaveChanges();
                // 查询
                var score = context.ScoreInfos.FirstOrDefault(c => c.Name.Equals("小帅"));
                // 修改
                scoreInfo.Course = "数学";
                context.SaveChanges();

                context.Remove(scoreInfo);
                context.SaveChanges();
            }

        }
    }
}
