using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XH.MvvmPattern.Base;

namespace XH.MvvmPattern.ViewModels
{
    public class CommandViewModel
    {
        public Command BtnCommand { get; set; }

        public Command PreBtnCommand { get; set; }
        public Command SeletedCommand { get; set; }

        public CommandViewModel()
        {
            BtnCommand = new Command(obj =>
            {
                // 组合键
                if(Keyboard.Modifiers == ModifierKeys.Control)
                {

                }
            });

            PreBtnCommand = new Command(obj =>
            {

            });

            SeletedCommand = new Command(obj =>
            {

            });
        }
    }
}
