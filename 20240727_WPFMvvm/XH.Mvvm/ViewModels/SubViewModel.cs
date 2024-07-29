using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Mvvm.Base;

namespace XH.Mvvm.ViewModels
{
    public class SubViewModel
    {
        public int Value { get; set; }
        public Command SubmitCommand { get; set; }
        public SubViewModel()
        {
            SubmitCommand = new Command(obj =>
            {
                // 发布的动作 传值
                ActionManager.Invoke<object>("AAA",Value);

                // 接受
                var v = ActionManager.InvokeWithResult<object>("BBB");

            });
        }
    }
}
