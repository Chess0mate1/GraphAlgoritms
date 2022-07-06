using GraphAlgoritms.Business;
using GraphAlgoritms.Core.Commands;
using GraphAlgoritms.Core.SendingInfo;
using GraphAlgoritms.Core.Types;

using Prism.Events;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Modules.Graph.ViewModels
{
    public partial class GraphViewModel
    {
        private partial class CommandManager
        {
            private abstract class CommandBaseCreator<CommandParameter> : CommandCreator<GraphViewModel, CommandParameter>
            {
                protected GraphContainer _graph => _viewModel._graph;

                protected IEventAggregator _eventAggregator => _viewModel._eventAggregator;
                protected ObservableCollection<NodeViewModel> _nodeViewModels => _viewModel.NodeViewModels;
                protected ObservableCollection<EdgeViewModel> _edgeViewModels => _viewModel.EdgeViewModels;


                protected readonly List<char> _alphabet = new()
                {
                    'A',
                    'B',
                    'C',
                    'D',
                    'E',
                    'F',
                    'G',
                    'H',
                    'I',
                    'G',
                    'K',
                    'L',
                    'M',
                    'N',
                    'O',
                    'P',
                    'Q',
                    'R',
                    'S',
                    'T',
                    'U',
                    'V',
                    'W',
                    'X',
                    'Y',
                    'Z',
                };
                protected int _index = 0;
                protected double _radious = NodeViewModel.Radious;


                public CommandBaseCreator(GraphViewModel graphVM)
                    : base(graphVM) { }
            }
        }
    }
}
