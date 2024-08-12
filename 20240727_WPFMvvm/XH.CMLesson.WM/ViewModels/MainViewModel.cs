using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.CMLesson.WM.ViewModels
{
    public class MainViewModel:PropertyChangedBase
    {
        private int _value = 100;

        public int Value
        {
            get { return _value; }
            set { Set<int>(ref _value, value); }
        }

        IWindowManager _windowManager;
        AViewModel _aViewModel;
        public MainViewModel(IWindowManager windowManager, AViewModel aViewModel)
        {
            _windowManager = windowManager;
            _aViewModel = aViewModel;
        }

        public async void Open()
        {
            // 触发打开另一个窗口
            // 打开一个模态窗口 卡线程
            //var vm = IoC.Get<AViewModel>();
            _aViewModel.Title = "Title";
            var result = await _windowManager.ShowDialogAsync(_aViewModel);

            if (result == true)
            {
                Value = _aViewModel.Value;
            }
            // 打开一个一般的窗口 和Show一样
            //_windowManager.ShowWindowAsync(this);
            // 打开一个Popup
            //_windowManager.ShowPopupAsync(this);
        }
    }
}
