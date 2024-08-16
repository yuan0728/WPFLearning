using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.CMLesson.MultiPage.ViewModels
{
    public class CViewModel : Screen, IChildViewModel
    {
        public int Value { get; set; } = 3333;
        public CViewModel()
        {
            // 显示TabControl的Title
            this.DisplayName = "C View";
        }
    }
}
