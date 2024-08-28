using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml.Linq;
using XH.Models;

namespace XH.JwtIdentityApi.Utiltiy
{
    /// <summary>
    /// 非对称可逆加密
    /// </summary>
    public class CustomRSSJWTervice : CustomAbstraceJWTService

    {
        #region Option注入
        private readonly JWTTokenOptions _JWTTokenOptions;
        public CustomRSSJWTervice(IOptionsMonitor<JWTTokenOptions> jwtTokenOptions)
        {
            _JWTTokenOptions = jwtTokenOptions.CurrentValue;
        }

        public override string CreateToken(UserInfo user)
        {
            #region 使用加密解密Key  非对称 
            string keyDir = Directory.GetCurrentDirectory();
            if (RSAHelper.TryGetKeyParameters(keyDir, true, out RSAParameters keyParams) == false)
            {
                keyParams = RSAHelper.GenerateAndSaveKey(keyDir);
            }
            #endregion
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

            SigningCredentials credentials = new SigningCredentials(new RsaSecurityKey(keyParams), SecurityAlgorithms.RsaSha256Signature);

            var token = new JwtSecurityToken(
               issuer: _JWTTokenOptions.Issuer,
               audience: _JWTTokenOptions.Audience,
               claims: claimsArray,
               expires: DateTime.Now.AddMinutes(60),//5分钟有效期
               signingCredentials: credentials);

            var handler = new JwtSecurityTokenHandler();
            string tokenString = handler.WriteToken(token);
            return tokenString;
        }
        #endregion


    }
}
