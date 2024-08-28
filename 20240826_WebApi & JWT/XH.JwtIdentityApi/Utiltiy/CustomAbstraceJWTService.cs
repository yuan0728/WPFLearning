using XH.Models;

namespace XH.JwtIdentityApi.Utiltiy
{
    public abstract class CustomAbstraceJWTService
    {
        /// <summary>
        /// 专门呢颁发token的方法
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public abstract string CreateToken(UserInfo user);
    }
}
