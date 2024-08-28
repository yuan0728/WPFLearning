namespace XH.Models
{

    /// <summary>
    /// 用作记录用户的信息和，当前用户能够访问的资源，以及角色的之类的，可以保存和授权相关的任何数据
    /// </summary>
    public class UserInfo
    {
        public int Id { get; set; }
        public string? Name { set; get; }

        public string? Password { set; get; }

        public int Status { set; get; }

        public string? Phone { set; get; }

        public string? Mobile { set; get; }

        public string? Address { set; get; }

        public string? Email { set; get; }

        public long QQ { set; get; }

        public string? WeChat { set; get; }

        public int Sex { set; get; }

        /// <summary>
        /// 角色Id集合
        /// </summary>
        public List<string>? RoleList { get; set; }

        /// <summary>
        /// 用户拥有菜单
        /// </summary>
        public List<string>? UserMenueList { get; set; }
    }
}
