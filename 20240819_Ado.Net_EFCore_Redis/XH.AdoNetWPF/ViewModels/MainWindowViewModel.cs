using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.AdoNetWPF.Utility;
using XH.DbModels.Models;
using XH.Interfaces;
using XH.Services;

namespace XH.AdoNetWPF.ViewModels
{
    public class MainWindowViewModel : RedisBase
    {
        public int Value { get; set; } = 123;
        public ObservableCollection<ScoreInfo> ScoreList { get; set; } = new ObservableCollection<ScoreInfo>();
        public RelayCommand ExportCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand GetCommand { get; set; }

        private readonly DbContext _context;
        private readonly IScoreInfoService _scoreInfoService;
        public MainWindowViewModel(DbContext context, IScoreInfoService scoreInfoService)
        {
            _context = context;
            _scoreInfoService = scoreInfoService;
            ExportCommand = new RelayCommand(DoExport);
            SaveCommand = new RelayCommand(DoSave);
            GetCommand = new RelayCommand(InitScoreList);

            // 分层：UI：WPF BLL：业务逻辑层 DAL：数据访问层

            {
                // 不能直接New对象 需要IOC注册
            }
            // 每一个实体的操作 都需要一个Service和一个接口


            InitScoreList();
        }

        private void InitScoreList()
        {
            // 直接基于数据库获取
            List<ScoreInfo> scoreList = new List<ScoreInfo>();

            string key = "scoreList";
            scoreList = GetCacheData(key, () =>
            {
                return _scoreInfoService.Set<ScoreInfo>().ToList();
            });
            // 可以优化 
            //List<ScoreInfo> data = rds.Get<List<ScoreInfo>>(key);
            //if (data == null) // redis里面没有数据
            //{
            //    data = _scoreInfoService.Set<ScoreInfo>().ToList();
            //    // 可以吧data存放在redis中，下次可以直接请求redis获取

            //    rds.Set(key, data, 30); // 第三个参数：可以缓存多少秒

            //    //scoreList = _context.Set<ScoreInfo>().ToList();
            //}

            ScoreList.Clear();
            //foreach (ScoreInfo item in scoreList)
            //{
            //    ScoreList.Add(item);

            //}
            scoreList.ForEach(x => ScoreList.Add(x));
        }

        private void DoExport()
        {

        }

        private void DoSave()
        {

        }
    }

    //public class ScoreInfo
    //{
    //    public string? Name { get; set; }

    //    public string? Course { get; set; }

    //    public int? Score { get; set; }
    //}
}
