using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.CMLesson.MultiPage.ViewModels
{
    public class AViewModel:Screen, IChildViewModel
    {
        public int Value { get; set; } = 1111;
        public AViewModel()
        {
            this.DisplayName = "A View";
        }
    }
}
