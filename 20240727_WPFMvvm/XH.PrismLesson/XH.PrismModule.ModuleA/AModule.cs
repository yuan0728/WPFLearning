
using Prism.Ioc;
using Prism.Modularity;

namespace XH.PrismModule.ModuleA
{
    [Module(ModuleName ="AAA",OnDemand =true)]
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
