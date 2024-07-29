using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.MvvmPattern.Base;
using XH.MvvmPattern.Models;

namespace XH.MvvmPattern.ViewModels
{
    public class MainViewModel
    {
        public MainModel _model { get; set; } = new MainModel();

        // ObservableCollection：集合通知属性，代替List 可以通知界面修改数据
        //public ObservableCollection<ResultModel> ResultList { get; set; } = new ObservableCollection<ResultModel>();
        public ObservableCollection<string> ResultList { get; set; } = new ObservableCollection<string>();

        public Command BtnCommand { get; set; }
        public Command BtnCheckCommand { get; set; }
        public Command BtnDelCommand { get; set; }

        public MainViewModel()
        {
            BtnCommand = new Command(DoLogic, CanDoLogic);
            BtnCheckCommand = new Command(DoCheck);
            BtnDelCommand = new Command(DoDel);

            _model.PropertyChanged += _model_PropertyChanged;
        }

        // 删除按钮
        private void DoDel(object obj)
        {
            ResultList.Remove((string)obj);
        }

        // 属性变化事件
        private void _model_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //if((sender as MainModel).Value1 > 0 && (sender as MainModel).Value2 > 0)
            //{
            BtnCommand.RaiseCanExecuteChanged();
            //}
        }

        // 检查按钮
        private void DoCheck(object obj)
        {
            BtnCommand.RaiseCanExecuteChanged();
        }

        // 控制逻辑
        private void DoLogic(object obj)
        {
            _model.Value3 = _model.Value1 + _model.Value2;

            // 如果希望通知子项的变化（这个集合中的子项的增减）
            // 需要实现INotifyCollectionChanged接口，进行子项变化通知
            // 框架提供了通知集合对象ObservableCollection
            //ResultList.Add(new ResultModel
            //{
            //    Msg = $"第{ResultList.Count + 1}次{_model.Value1} + {_model.Value2} = {_model.Value3}",
            //});
            ResultList.Add($"第{ResultList.Count + 1}次{_model.Value1} + {_model.Value2} = {_model.Value3}");
        }

        // 是否可以启用按钮
        private bool CanDoLogic(object obj)
        {
            return _model.Value1 > 0 && _model.Value2 > 0;
        }
    }
}
