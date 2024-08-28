
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
            // ���ע�� ��UI������ʾ
            builder.Services.AddSwaggerGen(option =>
            {
                #region ���ע��

                string basePath = AppContext.BaseDirectory; // ִ��Ŀ¼
                // ��Ҫ������ע���ļ�������-->����-->������ĵ����ɣ�����API�ĵ���
                string xmlPath = Path.Combine(basePath, "XH.CoreWebApi.xml"); // ע���ļ�
                option.IncludeXmlComments(xmlPath); // ע��

                #endregion

                // �汾�Ŀ��� 
                // token �Ĵ���
                #region ֧��jwt token��Ȩ

                //��Ӱ�ȫ����--����֧��token��Ȩ����
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "������token,��ʽΪ Bearer xxxxxxxx��ע���м�����пո�",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                //��Ӱ�ȫҪ��
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

            #region ����Jwt������У��
            {
                JWTTokenOptions tokenOptions = new JWTTokenOptions();
                builder.Configuration.Bind("JWTTokenOptions", tokenOptions);

                //nuget�� Microsoft.AspNetCore.Authentication.JwtBearer
                builder.Services
               .AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //���ü�Ȩ����
               .AddJwtBearer(options =>
               {
                   //Ĭ�ϵ���֤����
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       //JWT��һЩĬ�ϵ����ԣ����Ǹ���Ȩʱ�Ϳ���ɸѡ��
                       ValidateIssuer = true,//�Ƿ���֤Issuer
                       ValidateAudience = true,//�Ƿ���֤Audience
                       ValidateLifetime = true,//�Ƿ���֤ʧЧʱ��
                       ValidateIssuerSigningKey = true,//�Ƿ���֤SecurityKey
                       ValidAudience = tokenOptions.Audience,//
                       ValidIssuer = tokenOptions.Issuer,//Issuer���������ǰ��ǩ��jwt������һ��
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
                   };
                   //���п���ȥ���ò�����Ȩ�������Զ����ҵ���߼����жϣ�
               });
            }

            builder.Services.AddAuthorization();   //ɶҲû������
            #endregion

            // IOC����ע��
            builder.Services.AddTransient<IScoreInfoService, ScoreInfoService>();

            builder.Services.AddDbContext<DbContext, XiaoHaiStudyDbContext>(contextBuilder =>
            {
                contextBuilder.UseSqlServer("Data Source=LITTLESEAPAD;Initial Catalog=XiaoHaiStudy;Persist Security Info=True;User ID=sa;Password=abc123;Encrypt=True;Trust Server Certificate=True");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // ���������ſ���Swagger �� SwaggerUI 
            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
            app.UseSwaggerUI();
            //}

            app.UseAuthentication(); // ���ü�Ȩ�м�� ����token��Ϣ
            app.UseAuthorization(); // ���ݽ��������û���Ϣ �ж��Ƿ���Է��ʵ�ǰ����Դ

            app.MapControllers();

            app.Run();
        }
    }
}
