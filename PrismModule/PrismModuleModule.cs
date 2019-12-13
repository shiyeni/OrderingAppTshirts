using Prism.Ioc;
using Prism.Modularity;
using PrismModule.Views;
using PrismModule.ViewModels;

namespace PrismModule
{
    public class PrismModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
        }
    }
}
