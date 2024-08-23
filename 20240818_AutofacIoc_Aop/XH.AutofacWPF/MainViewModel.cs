using Autofac.Extras.DynamicProxy;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XH.AutofacWPF
{
    // 既不需要接口和虚方法的可以继承这个基类：MarshalByRefObject -- 但是不建议 。。。。。
    public class MainViewModel  //: IMainViewModel //MarshalByRefObject
    {
        public int Value { get; set; } = 200;

        public RelayCommand<string> SaveCommand { get; set; }
        public RelayCommand ExportCommand { get; set; }
        
        public MainViewModel()
        {
            SaveCommand = new RelayCommand<string>(DoSave);
            ExportCommand = new RelayCommand(DoExport);
        }
        // Log
        [Log]
        public virtual void DoExport()
        {
            Console.WriteLine("触发了MainViewModel中的Export方法");
        }
        // Log - Monitor
        [Monitor]
        [Log] 
        public virtual void DoSave(string args)
        {
            Thread.Sleep(10);
            Console.WriteLine("触发了MainViewModel中的Save方法");
        }
    }

    public interface IMainViewModel
    {
        [Monitor]
        [Log]
        void DoSave(string args);
        [Log]
        void DoExport(); 
        int Value { get; set; }
        RelayCommand<string> SaveCommand { get; set; }
        RelayCommand ExportCommand { get; set; }
    }
}
