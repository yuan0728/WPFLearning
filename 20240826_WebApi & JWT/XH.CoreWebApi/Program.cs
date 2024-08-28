
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using XH.Models;
using XH.WPFDbModels.Contexts;
using XH.WPFInterfaces;
using XH.WPFServices;

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
                #region 添加注释

                string basePath = AppContext.BaseDirectory; // 执行目录
                // 需要先生成注释文件：属性-->生成-->输出：文档生成（生成API文档）
                string xmlPath = Path.Combine(basePath, "XH.CoreWebApi.xml"); // 注释文件
                option.IncludeXmlComments(xmlPath); // 注释

                #endregion

                // 版本的控制 
                // token 的传递
                #region 支持jwt token授权

                //添加安全定义--配置支持token授权机制
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "请输入token,格式为 Bearer xxxxxxxx（注意中间必须有空格）",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                //添加安全要求
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference =new OpenApiReference()
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id ="Bearer"
                                }
                            },
                            new string[]{ }
                        }
                    });

                #endregion


            });

            #region 配置Jwt渠道的校验
            {
                JWTTokenOptions tokenOptions = new JWTTokenOptions();
                builder.Configuration.Bind("JWTTokenOptions", tokenOptions);

                //nuget： Microsoft.AspNetCore.Authentication.JwtBearer
                builder.Services
               .AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //配置鉴权渠道
               .AddJwtBearer(options =>
               {
                   //默认的验证参数
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       //JWT有一些默认的属性，就是给鉴权时就可以筛选了
                       ValidateIssuer = true,//是否验证Issuer
                       ValidateAudience = true,//是否验证Audience
                       ValidateLifetime = true,//是否验证失效时间
                       ValidateIssuerSigningKey = true,//是否验证SecurityKey
                       ValidAudience = tokenOptions.Audience,//
                       ValidIssuer = tokenOptions.Issuer,//Issuer，这两项和前面签发jwt的设置一致
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
                   };
                   //还有可以去配置策略授权，增加自定义的业务逻辑的判断；
               });
            }

            builder.Services.AddAuthorization();   //啥也没有配置
            #endregion

            // IOC容器注入
            builder.Services.AddTransient<IScoreInfoService, ScoreInfoService>();

            builder.Services.AddDbContext<DbContext, XiaoHaiStudyDbContext>(contextBuilder =>
            {
                contextBuilder.UseSqlServer("Data Source=LITTLESEAPAD;Initial Catalog=XiaoHaiStudy;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // 开发环境才开启Swagger 和 SwaggerUI 
            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
            app.UseSwaggerUI();
            //}

            app.UseAuthentication(); // 启用鉴权中间件 解析token信息
            app.UseAuthorization(); // 根据解析到的用户信息 判断是否可以访问当前的资源

            app.MapControllers();

            app.Run();
        }
    }
}
