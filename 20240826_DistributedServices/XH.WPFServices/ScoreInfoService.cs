using Microsoft.EntityFrameworkCore;
using XH.WPFDbModels.Models;
using XH.WPFInterfaces;

namespace XH.WPFServices
{
    /// <summary>
    /// ScoreInfo 的业务逻辑操作
    /// </summary>
    public class ScoreInfoService : BaseService, IScoreInfoService
    {
        // 子类继承父类，如果在构造子类实例的时候，执行子类的构造之前，要先去执行父类的构造函数
        // base(context)：把子类的context传给父类
        public ScoreInfoService(DbContext context) : base(context)
        {

        }

        // 删除某一个信息 和 级联用户信息
        public void DeleteScoreInfoAndUser(int scoreId)
        {
            Delete(new ScoreInfo() { Id = 1 });
            Delete(new ScoreInfo() { Id = 2 });
        }
    }
}
