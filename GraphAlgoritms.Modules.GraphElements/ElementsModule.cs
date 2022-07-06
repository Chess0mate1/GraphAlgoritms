using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Mvvm;
using GraphAlgoritms.Modules.Elements.ViewModels;
using GraphAlgoritms.Modules.Elements.Views;
using GraphAlgoritms.Core;

namespace GraphAlgoritms.Modules.Elements
{
    public class ElementsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.ElementTypesRegion, typeof(ElementsView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<ElementsView, ElementsViewModel>();
        }
    }
}