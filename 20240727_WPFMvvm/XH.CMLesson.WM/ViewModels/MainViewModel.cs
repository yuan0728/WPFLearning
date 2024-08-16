using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace XH.CMLesson.WM.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        private int _value = 100;

        public int Value
        {
            get { return _value; }
            set { Set<int>(ref _value, value); }
        }

        IWindowManager _windowManager;
        AViewModel _aViewModel;
        BViewModel _bViewModel;
        public MainViewModel(IWindowManager windowManager, AViewModel aViewModel, BViewModel bViewModel)
        {
            _windowManager = windowManager;
            _aViewModel = aViewModel;
            _bViewModel = bViewModel;
        }

        public async void OpenWindow()
        {
            // 触发打开另一个窗口
            // 打开一个模态窗口 卡线程 
            //var vm = IoC.Get<AViewModel>();
            _aViewModel.Title = "Title";

            // key ：窗口的属性
            // 可以设置打开窗口的参数
            IDictionary<string, object> args = new Dictionary<string, object>();
            args.Add("Width", 300d);
            args.Add("Height", 200d);
            args.Add("Foreground", Brushes.Red);

            var result = await _windowManager.ShowDialogAsync(_aViewModel, settings: args);

            if (result == true)
            {
                Value = _aViewModel.Value;
            }
            // 打开一个一般的窗口 和Show一样
            //await _windowManager.ShowWindowAsync(_aViewModel);
        }

        public async void OpenPopup()
        {
            // 打开一个Popup
            // Popup数据对象的数据源
            await _windowManager.ShowPopupAsync(_bViewModel);
        }
    }
}
