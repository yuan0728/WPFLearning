using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Models
{
    /// <summary>
    /// 与appsettings.json中的配置一模一样
    /// </summary>
    public class JWTTokenOptions
    {
        public string? Audience { get; set; }

        public string? SecurityKey { get; set; }

        public string? Issuer { get; set; }
    }
}
