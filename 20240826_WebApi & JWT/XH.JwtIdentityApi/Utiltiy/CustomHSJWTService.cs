using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XH.Models;

namespace XH.JwtIdentityApi.Utiltiy
{
    public class CustomHSJWTService : CustomAbstraceJWTService
    {

        //最终需要加密--必然需要加密key--最好放在配置文件中
        private readonly JWTTokenOptions _JWTTokenOptions;
        public CustomHSJWTService(IOptionsMonitor<JWTTokenOptions> jwtTokenOptions)
        {
            _JWTTokenOptions = jwtTokenOptions.CurrentValue;
        }



        /// <summary>
        /// 这里是实现 关于对称可逆加密的逻辑
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public override string CreateToken(UserInfo user)
        {
            //准备加密解密key
            #region 第一步，准备有效载荷
            List<Claim> claimsArray = new List<Claim>()
            {
               new Claim(ClaimTypes.Sid, user.Id.ToString()),
               new Claim(ClaimTypes.Name, user.Name!),
               new Claim(ClaimTypes.MobilePhone, user.Mobile),
               new Claim(ClaimTypes.StreetAddress, user.Address),
               new Claim(ClaimTypes.Email, user.Email),
               new Claim("QQ", user.QQ.ToString()),
               new Claim("Sex", user.Sex.ToString())
            };
            foreach (var roleId in user.RoleList)
            {
                claimsArray.Add(new Claim(ClaimTypes.Role, roleId.ToString()));
            }
            foreach (var menud in user.UserMenueList)
            {
                claimsArray.Add(new Claim("Menues", menud.ToString()));
            }
            #endregion


            #region 二、准备加密key   
            //nuget： Microsoft.IdentityModel.Tokens
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JWTTokenOptions.SecurityKey));   //使用的是配置文件的信息

            #endregion


            #region 三、选择加密算法，使用上面准备的信息生成Token
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //使用加密key，选定加密算法


            //开始准备生成token
            //nuget： System.IdentityModel.Tokens.Jwt
            JwtSecurityToken JwtAccessToken = new JwtSecurityToken(
                  issuer: _JWTTokenOptions.Issuer,
                  audience: _JWTTokenOptions.Audience,
                  claims: claimsArray.ToArray(), //有效载荷
                  expires: DateTime.Now.AddMinutes(5),//5分钟有效期 
                  signingCredentials: creds);


            string accesstoken = new JwtSecurityTokenHandler().WriteToken(JwtAccessToken);
            #endregion


            return accesstoken;

        }
    }
}
