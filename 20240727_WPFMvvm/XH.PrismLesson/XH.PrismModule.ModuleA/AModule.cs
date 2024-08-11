
using Prism.Ioc;
using Prism.Modularity;

namespace XH.PrismModule.ModuleA
{
    [Module(ModuleName ="AAA",OnDemand =true)]
    public class AModule : IModule
    {
        // ³õÊ¼»¯
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        // ×¢Èë
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
        }
    }

}
