using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace XH.PrismEventAggregator
{
    public class MainViewModel
    {
        public DelegateCommand OpenCommand { get; set; }

        [Dependency]
        IEventAggregator _eventAggregator;
        public MainViewModel()
        {
            OpenCommand = new DelegateCommand(OnOpen);
        }

        private void OnOpen()
        {
            // 打开子窗口
            //_eventAggregator.GetEvent<EventMessage>().Publish();
            Messenger.Defualt.GetEvent<EventMessage>().Publish();
        }
    }
}
