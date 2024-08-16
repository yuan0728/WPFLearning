using Caliburn.Micro;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.CMLesson.MultiPage.ViewModels
{
    // 如果使用的是ContenControl的时候 --> Conductor<object>
    // 使用TabControl --> Conductor<object>.Collection.OneActive
    // OneActive：只有一个是被激活的对象
    // AllActive：所有的页面都是激活的，没有失去激活状态切换
    public class MainViewModel:Conductor<object>.Collection.OneActive
    {
        public async void ShowPage(string name)
        {
            // 通过key获取对应的viewModel
            var vm = IoC.Get<IChildViewModel>(name);
            await this.ActivateItemAsync(vm);
        }
    }
    // 实现：
    // IResult：协同任务组件
    // INavigationService：导航Page  默认有个实现：FramAdapter-->Fram导航
}
