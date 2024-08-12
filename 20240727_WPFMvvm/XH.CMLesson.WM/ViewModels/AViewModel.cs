using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.CMLesson.WM.ViewModels
{
    public class AViewModel : Screen
    {
        public int Value { get; set; } = 456;
        public string Title { get; set; }
        public void OnClose()
        {
            // 通过这个方法来判断返回的是true 还是false
            this.TryCloseAsync(true);
        }
    }
}
