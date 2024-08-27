namespace XH.WPFInterfaces
{
    public interface IScoreInfoService: IBaseService
    {
        // 删除某一个信息 级联删除用户
        void DeleteScoreInfoAndUser(int scoreId);
    }
}
