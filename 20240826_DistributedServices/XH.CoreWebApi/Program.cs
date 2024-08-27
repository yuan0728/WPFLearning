
namespace XH.CoreWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //builder.Services.AddSwaggerGen();
            // 添加注释 及UI界面显示
            builder.Services.AddSwaggerGen(option =>
            {
                string basePath = AppContext.BaseDirectory; // 执行目录
                string xmlPath = Path.Combine(basePath, "XH.CoreWebApi.xml"); // 注释文件
                option.IncludeXmlComments(xmlPath); // 注释
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // 开发环境才开启Swagger 和 SwaggerUI 
            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
            app.UseSwaggerUI();
            //}

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
