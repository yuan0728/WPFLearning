using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Models;
using XH.WPFClient.HttpRequestUtil;
using XH.WPFClient.Utility;
using XH.WPFDbModels.Models;
using XH.WPFInterfaces;

namespace XH.WPFClient.ViewModels
{
    public class MainWindowViewModel  //: RedisBase
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
            //List<ScoreInfo> scoreList = new List<ScoreInfo>();
            //scoreList = _scoreInfoService.Set<ScoreInfo>().ToList();
            //ScoreList.Clear();
            //scoreList.ForEach(x => ScoreList.Add(x));

            // 从 webapi 获取数据 发起http请求
            // 1.HttpClient
            // 2.HttpWebRequest
            // 没有权限的时候 获取不到数据 没有Token
            // 获取数据之前 先获取token
            // 获取token
            var tokenJson = HttpClientHelpler.HttpPost<ApiResult<string>>($"http://localhost:63071/Account?name=admin&password=1");
            string token = tokenJson.Value;

            // 请求带上token
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {token}" }
            };
            var scoreList = HttpClientHelpler.HttpGet<List<ScoreInfo>>("http://localhost:15510/First/GetScoreInfoList",headers: headers); 
            ScoreList.Clear();
            scoreList.ForEach(x => ScoreList.Add(x));
        }

        private void DoExport()
        {

        }

        private void DoSave()
        {

        }
    }
}
