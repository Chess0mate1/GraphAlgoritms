using GraphAlgoritms.Business;
using GraphAlgoritms.Core;
using GraphAlgoritms.Core.Events;
using GraphAlgoritms.Core.SendingInfo;
using GraphAlgoritms.Core.Types;

using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GraphAlgoritms.Modules.Graph.ViewModels
{
    public partial class GraphViewModel : BindableBase
    {
        private GraphContainer _graph;

        private BehavierManager _behavierManager;
        private CommandManager _commandManager;
        private readonly IEventAggregator _eventAggregator;



        private ObservableCollection<EdgeViewModel> _edgeViewModels;
        public ObservableCollection<EdgeViewModel> EdgeViewModels
        {
            get { return _edgeViewModels; }
            set { SetProperty(ref _edgeViewModels, value); }
        }

        private ObservableCollection<NodeViewModel> _nodeViewModels;
        public ObservableCollection<NodeViewModel> NodeViewModels
        {
            get { return _nodeViewModels; }
            set { SetProperty(ref _nodeViewModels, value); }
        }



        private bool _isWeightChangingEnabled;
        public bool IsWeightChangingEnabled
        {
            get { return _isWeightChangingEnabled; }
            set { SetProperty(ref _isWeightChangingEnabled, value); }
        }

        private bool _isNodesMovingEnabled;
        public bool IsNodesMovingEnabled
        {
            get { return _isNodesMovingEnabled; }
            set { SetProperty(ref _isNodesMovingEnabled, value); }
        }

        private bool _isNodeWeightsVisible;
        public bool IsNodeWeightsVisible
        {
            get { return _isNodeWeightsVisible; }
            set { SetProperty(ref _isNodeWeightsVisible, value); }
        }

        private bool _isEdgesWeightsVisible;
        public bool IsEdgesWeightsVisible
        {
            get { return _isEdgesWeightsVisible; }
            set { SetProperty(ref _isEdgesWeightsVisible, value); }
        }



        private bool _isActiveGraphCommandEnabled;
        public bool IsActiveGraphCommandEnabled
        {
            get { return _isActiveGraphCommandEnabled; }
            set { SetProperty(ref _isActiveGraphCommandEnabled, value); }
        }

        private DelegateCommand<GraphElementViewModel> _activeGraphCommand;
        public DelegateCommand<GraphElementViewModel> ActiveGraphCommand
        {
            get { return _activeGraphCommand; }
            set { SetProperty(ref _activeGraphCommand, value); }
        }


        private bool _isActiveNodePositionCommandEnabled;
        public bool IsActiveNodePositionCommandEnabled
        {
            get { return _isActiveNodePositionCommandEnabled; }
            set { SetProperty(ref _isActiveNodePositionCommandEnabled, value); }
        }

        private DelegateCommand<Point?> _activeNodePositionCommand;
        public DelegateCommand<Point?> ActiveNodePositionCommand
        {
            get { return _activeNodePositionCommand; }
            set { SetProperty(ref _activeNodePositionCommand, value); }
        }



        public GraphViewModel(IEventAggregator eventAggregator)
        {
            _graph = new();

            EdgeViewModels = new();
            NodeViewModels = new();

            _eventAggregator = eventAggregator;

            _behavierManager = new(this);
            _commandManager = new(this);
            _eventAggregator.GetEvent<BehavierSelectedEvent>().Subscribe(_behavierManager.SetBehavier);
            _eventAggregator.GetEvent<BehavierSelectedEvent>().Subscribe(_commandManager.SetCommand);

            NodeViewModels.CollectionChanged += new SenderManager(this).SendGraphElementsCountsInfo;
            EdgeViewModels.CollectionChanged += new SenderManager(this).SendGraphElementsCountsInfo;
        }
    }
}
