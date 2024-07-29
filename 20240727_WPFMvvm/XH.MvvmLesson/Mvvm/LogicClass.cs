namespace XH.MvvmLesson.Mvvm
{
    // MvvmWindow 类
    public class LogicClass
    {
        public DataModel _model { get; set; } = new DataModel();

        public Command BtnCommand { get; set; }
        public Command BtnCheckCommand { get; set; }

        public LogicClass()
        {
            BtnCommand = new Command(DoLogic, CanDoLogic);

            BtnCheckCommand = new Command(DoCheck);

            _model.PropertyChanged += _model_PropertyChanged;
        }

        // 属性变化事件
        private void _model_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //if((sender as DataModel).Value1 > 0 && (sender as DataModel).Value2 > 0)
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
        }

        // 是否可以启用按钮
        private bool CanDoLogic(object obj)
        {
            return _model.Value1 > 0 && _model.Value2 > 0;
        }
    }
}
