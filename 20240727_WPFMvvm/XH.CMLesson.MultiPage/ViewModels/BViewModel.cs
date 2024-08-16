using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.CMLesson.MultiPage.ViewModels
{
    public class BViewModel :Screen, IChildViewModel
    {
        public int Value { get; set; } = 2222;

        public BViewModel()
        {
            this.DisplayName = "B View";
        }
    }
}
