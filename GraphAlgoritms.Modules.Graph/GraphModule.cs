using GraphAlgoritms;
using GraphAlgoritms.Core;
using GraphAlgoritms.Modules.Graph.ViewModels;
using GraphAlgoritms.Modules.Graph.Views;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace GraphAlgoritms.Modules.Graph
{
    public class GraphModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.GraphRegion, typeof(GraphView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<GraphView, GraphViewModel>();
        }
    }
}