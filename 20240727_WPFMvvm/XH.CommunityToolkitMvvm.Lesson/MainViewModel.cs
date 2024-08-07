using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.CommunityToolkitMvvm.Lesson
{
    // 同过 partial 把框架中自动生成的和此类合并
    // ObservableObject：通知属性 // ObservableValidator：验证属性 // ObservableRecipient：订阅
    //[ObservableRecipient]
    public partial class MainViewModel : ObservableRecipient, IDisposable, IRecipient<string>
    {
        // 1、基本通知属性
        private string _value;

        public string Value
        {
            get { return _value; }
            set
            {
                SetProperty(ref _value, value);
                //_value = value;
                //this.OnPropertyChanging();
            }
        }

        // 2、业务需求：
        // 从API接口获取相关的数据
        // 这个数据以Json/XML 形式返回
        // 拿到数据后，进行反序列化 通过程序中的实体/模型进行接受
        // 实体：属性需要和Json中的名称相同
        // 可能实体里的数据被多个Mdoel进行引用；也有可能在一个Model中需要多个实体的数据
        // 转换过程：实体-->Model的数据转换过程

        UserEntity userEntity = new UserEntity();

        //private string _name;
        // 直接通过实体返回 或者赋值
        public string UserName
        {
            get { return userEntity.userName; }
            set
            {
                userEntity.userName = value;
                this.OnPropertyChanging(nameof(UserName));

                // 通过 SetProperty 给 Model 赋值
                SetProperty<UserEntity, string>(userEntity.userName, value, userEntity, (entity, v) => { entity.userName = v; });
            }
        }

        // 3、有一个属性、获取一个值赋值给属性
        // 问题获取值的过程是异步的耗时操作
        // 使用场景：用户信息添加-->用户ID不能重复 -->检查数据库
        private TaskNotifier<int> taskValue;

        public Task<int> TaskValue
        {
            get { return taskValue; }
            set
            {
                // 异步赋值 
                SetPropertyAndNotifyOnCompletion(ref taskValue, value);
            }
        }

        private void Refresh()
        {
            //Task.Run(async () =>
            //{
            //    await Task.Delay(3000);
            //    TaskValue = 1000;
            //});
            // 执行Set
            TaskValue = new Task<int>(() => { Thread.Sleep(3000); return 1000; });
        }

        // 命令定义
        public RelayCommand BtnCommand { get; set; }

        // 异步绑定
        public AsyncRelayCommand AsyncButtonCommand { get; set; }
        public MainViewModel()
        {
            AsyncButtonCommand = new AsyncRelayCommand(AsyncButtonClick);
            BtnCommand = new RelayCommand(BtnClick);

            // 消息订阅 Token 
            WeakReferenceMessenger.Default.Register<string, string>(this, "One", (obj, str) =>
            {
                (obj as MainViewModel).Value = str;
            });
            WeakReferenceMessenger.Default.Register<string, string>(this, "Two", (obj, str) =>
            {
                (obj as MainViewModel).Value = str;
            });
            // 释放
            WeakReferenceMessenger.Default.UnregisterAll(this);

            this.Name = "Hello";

            // 开启消息接收
            this.IsActive = true;
        }

        // 异步执行绑定
        private Task AsyncButtonClick()
        {
            return Task.Run(() => { });
        }

        private void BtnClick()
        {
            Task.Run(() => { });
            // 触发
            //WeakReferenceMessenger.Default.Send<string, string>("One", "One");
            //WeakReferenceMessenger.Default.Send<string, string>("Two", "Two");
            WeakReferenceMessenger.Default.Send<string>("Hello");
        }

        public void Dispose()
        {
            // 释放资源

        }

        // 关于特性的使用
        // 1、ObservableProperty 通知属性
        // 可以在页面 直接绑定 Name ,ObservableProperty自动生成propfull
        [ObservableProperty]
        [NotifyPropertyChangedFor("FullName")] //NotifyPropertyChangedFor：修改此属性的时候，通知指定属性；当更新name的时候，也要更新FullName 
        public string name;// abcNet --> AbcNet ; _abcNet --> AbcNet ; m_abcNet --> AbcNet

        // 如何处理这个字段特性的变化set逻辑/过程
        partial void OnNameChanged(string? oldValue, string newValue)
        {
            // 处理字段变化过程

        }

        partial void OnNameChanging(string? oldValue, string newValue)
        {
            // 当字段开始变化时执行

        }
        // 页面绑定的是FullName 属性 ，
        private string FullName { get => "xh" + name; }

        // 以下特性：需要继承 ObservableValidator 基类处理
        //[ObservableProperty]
        //[NotifyDataErrorInfo] //NotifyDataErrorInfo：关键的校验特性
        //[Required(ErrorMessage = "必填")]// 必填项目
        //[MinLength(1)] // 最小长度
        ////[NotifyPropertyChangedRecipients] //NotifyPropertyChangedRecipients：当属性发生变化的时候，做广播通知
        //private string inputValue = "123";
        // 这个字段所对应的属性 需要进行数据校验
        // 第一步：类继承ObservableValidator
        // 第二步：给字段添加相关校验特性

        //  命令 
        [RelayCommand] // RelayCommand：自动生成相关内容，可以直接绑定 自动生成name+Command
        private void DoButton()
        {

        }
        // 自动生成命令属性
        //public RelayCommand DoButtonCommand { get; set; }

        // 广播
        protected override void Broadcast<T>(T oldValue, T newValue, string? propertyName)
        {
            base.Broadcast(oldValue, newValue, propertyName);
        }
        // 实现接口：IRecipient
        public void Receive(string message)
        {
            //
        }
    }

    [NotifyPropertyChangedRecipients]
    class A : ObservableRecipient
    {
        public string Name { get; set; }
        // 广播信息
        protected override void Broadcast<T>(T oldValue, T newValue, string? propertyName)
        {
            base.Broadcast(oldValue, newValue, propertyName);
        }
    }
}
