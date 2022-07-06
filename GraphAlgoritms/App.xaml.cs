using GraphAlgoritms.Modules.Algoritms;
using GraphAlgoritms.Modules.Elements;
using GraphAlgoritms.Modules.Graph;
using GraphAlgoritms.Views;

using Prism.Ioc;
using Prism.Modularity;

using System.Windows;

namespace GraphAlgoritms
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AlgoritmsModule>();
            moduleCatalog.AddModule<GraphModule>();
            moduleCatalog.AddModule<ElementsModule>();
        }
    }
}
