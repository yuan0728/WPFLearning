
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
            // ���ע�� ��UI������ʾ
            builder.Services.AddSwaggerGen(option =>
            {
                string basePath = AppContext.BaseDirectory; // ִ��Ŀ¼
                string xmlPath = Path.Combine(basePath, "XH.CoreWebApi.xml"); // ע���ļ�
                option.IncludeXmlComments(xmlPath); // ע��
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // ���������ſ���Swagger �� SwaggerUI 
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
