using GraphAlgoritms.Core.Events;
using GraphAlgoritms.Core.SendingInfo;

using Prism.Events;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Modules.Graph.ViewModels
{
    public partial class GraphViewModel
    {
        private class SenderManager
        {
            private GraphViewModel _viewModel;

            public SenderManager(GraphViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public void SendGraphElementsCountsInfo(object sender, NotifyCollectionChangedEventArgs e)
            {
                GraphElementCountsInfo info = new()
                {
                    NodesCount = _viewModel.NodeViewModels.Count,
                    EdgesCount = _viewModel.EdgeViewModels.Count,
                };

                _viewModel._eventAggregator.GetEvent<GraphElementsCountChangedEvent>().Publish(info);
                //PubSubEvent
            }
        }
    }
}
