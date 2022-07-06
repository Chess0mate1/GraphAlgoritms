using GraphAlgoritms.Core;
using GraphAlgoritms.Core.SendingInfo;
using GraphAlgoritms.Core.Types;
using Prism.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphAlgoritms.Modules.Graph.ViewModels
{
    public partial class GraphViewModel
    {
        private partial class CommandManager
        {
            private readonly Dictionary<ElementMode, Dictionary<ElementType, DelegateCommand<GraphElementViewModel>>> _graphCommands;
            private readonly Dictionary<ElementMode, Dictionary<ElementType, DelegateCommand<Point?>>> _nodePositionCommands;
            private readonly GraphViewModel _viewModel;

            public CommandManager(GraphViewModel viewModel)
            {
                _viewModel = viewModel;

                _nodePositionCommands = new()
                {
                    [ElementMode.Creation] = new()
                    {
                        [ElementType.Node] = new NodeCreationCommandCreator(_viewModel).Create()                   
                    }
                };

                _graphCommands = new()
                {
                    [ElementMode.Creation] = new()
                    {
                        [ElementType.Edge] = new EdgeCreationCommandCreator(_viewModel).Create()
                    },
                    [ElementMode.Removal] = new()
                    {
                        [ElementType.Node] = new NodeRemovalCommandCreator(_viewModel).Create(),
                        [ElementType.Edge] = new EdgeRemovalCommandCreator(_viewModel).Create()
                    },
                    [ElementMode.Algoritm] = new()
                    {
                        [ElementType.BreadthFirstSearch] = new BreadthFirstSearchAlgoritmCreator(_viewModel).Create(),
                        [ElementType.DepthFirstSearch] = new DepthFirstSearchAlgoritmCreator(_viewModel).Create(),
                        [ElementType.Dijkstra] = new DijkstrasAlgoritmCreator(_viewModel).Create(),
                        [ElementType.AStar] = new AStarAlgoritmCreator(_viewModel).Create()
                    },
                };
            }


            public void SetCommand(BehavierInfo info)
            {
                ElementMode mode = info.SelectedElementMode;
                ElementType type = info.SelectedElementType;

                if (IsBehavierSet() && IsCommandBehavier())
                {
                    ChooseCommand();
                }

                bool IsBehavierSet()
                {
                    return mode is not ElementMode.None && 
                           type is not ElementType.None;
                }
                bool IsCommandBehavier()
                {
                    return mode is ElementMode.Creation or ElementMode.Removal or ElementMode.Algoritm;
                }
                void ChooseCommand()
                {
                    switch (mode, type)
                    {
                        case (ElementMode.Creation, ElementType.Node):
                            _viewModel.ActiveNodePositionCommand = _nodePositionCommands[mode][type];
                            break;
                        default:
                            _viewModel.ActiveGraphCommand = _graphCommands[mode][type];
                            break;
                    };
                }
            }
        }
    }
}
