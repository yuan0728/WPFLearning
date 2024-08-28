using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XH.JwtIdentityApi.Utiltiy;
using XH.Models;

namespace XH.JwtIdentityApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        //认证服务器中的 Login() XH.CoreWebApi中 不是也可以吗？为什么要多建一个认证服务器呢

        private readonly ILogger<AccountController> _logger;
        private readonly CustomAbstraceJWTService _CustomJWTService;

        public AccountController(ILogger<AccountController> logger, CustomAbstraceJWTService customJWTService)
        {
            _logger = logger;
            _CustomJWTService = customJWTService;
        }


        /// <summary>
        /// 登录功能 
        /// 接口用户名和密码---验证----生成Token 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(string name, string password)
        {
            {
                //验证身份---连接数据库 校验数据
                //
            }

            //就认为验证通过了 模拟场景
            if (name.Equals("admin") && password.Equals("1"))
            {
                //就可以从数据库中查询出来用户的信息，还可以计算出用户能够访问的api资源；
                //开始去生成Token
                UserInfo user = new UserInfo()  //这里认为 这里就是到数据库查询出来的数据
                {
                    Id = 123,
                    Name = "admin",
                    Address = "江苏苏州",
                    Email = "18672713698@163.com",
                    Mobile = "18672713698",
                    QQ = 123456789,
                    Sex = 1,
                    RoleList = new List<string>() { "admin", "teacher", "student", "user" },
                    UserMenueList = new List<string>() { "JwtAuthorize_GetUser", "JwtAuthorize_Show1", "JwtAuthorize_GetUse2" }
                };

                //开始生成token
                //1. 对称可逆
                string accessToken = _CustomJWTService.CreateToken(user);

                // 返回结果
                var result = new ApiResult<string>
                {
                    Success = true,
                    Message = "录成功，得到了token",
                    Value = accessToken
                };

                return new JsonResult(result);

                //2. 非对称可逆

            }
            else
            {
                return new JsonResult(new ApiResult<string>
                {
                    Success = false,
                    Message = "用户名或者是密码错误"
                });
            }

        }
    }
}
