using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.DbModels.Models;
using XH.Interfaces;
using XH.Services;

namespace XH.AdoNetWPF.ViewModels
{
    public class MainWindowViewModel
    {
        public int Value { get; set; } = 123;
        public ObservableCollection<ScoreInfo> ScoreList { get; set; } = new ObservableCollection<ScoreInfo>();
        public RelayCommand ExportCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }

        private readonly DbContext _context;
        private readonly IScoreInfoService _scoreInfoService;
        public MainWindowViewModel(DbContext context, IScoreInfoService scoreInfoService)
        {
            _context = context;
            _scoreInfoService = scoreInfoService;
            ExportCommand = new RelayCommand(DoExport);
            SaveCommand = new RelayCommand(DoSave);

            // 分层：UI：WPF BLL：业务逻辑层 DAL：数据访问层

            {
                // 不能直接New对象 需要IOC注册
            }
            // 每一个实体的操作 都需要一个Service和一个接口


            InitScoreList();
        }

        private void InitScoreList()
        {
            List<ScoreInfo> scoreList = new List<ScoreInfo>();
            {
                //scoreList = _context.Set<ScoreInfo>().ToList();
                scoreList= _scoreInfoService.Set<ScoreInfo>().ToList();
            }
            foreach (ScoreInfo item in scoreList)
            {
                ScoreList.Add(item);
            }
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
