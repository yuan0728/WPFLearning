
using Prism.Ioc;
using Prism.Modularity;

namespace XH.PrismModule.ModuleA
{
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
