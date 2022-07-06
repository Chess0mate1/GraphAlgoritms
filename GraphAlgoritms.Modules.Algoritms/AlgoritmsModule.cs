using GraphAlgoritms.Core;
using GraphAlgoritms.Modules.Algoritms.ViewModels;
using GraphAlgoritms.Modules.Algoritms.Views;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace GraphAlgoritms.Modules.Algoritms
{
    public class AlgoritmsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.AlgoritmsRegion, typeof(GraphAlgoritmsView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<GraphAlgoritmsView, GraphAlgoritmsViewModel>();
        }
    }
}