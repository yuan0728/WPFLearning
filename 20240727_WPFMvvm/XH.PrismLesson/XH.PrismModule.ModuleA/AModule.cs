
using Prism.Ioc;
using Prism.Modularity;

namespace XH.PrismModule.ModuleA
{
    public class AModule : IModule
    {
        // ��ʼ��
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        // ע��
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
        }
    }

}
