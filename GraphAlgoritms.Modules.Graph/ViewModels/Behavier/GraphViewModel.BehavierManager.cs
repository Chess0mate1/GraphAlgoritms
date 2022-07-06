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
        private partial class BehavierManager
        {
            private readonly Dictionary<ElementMode, Dictionary<ElementType, BehavierBase>> _behaviers;
            private readonly GraphViewModel _viewModel;

            public BehavierManager(GraphViewModel viewModel)
            {
                _viewModel = viewModel;

                //var algoritmBehavier = 

                _behaviers = new()
                {
                    [ElementMode.Creation] = new()
                    {
                        [ElementType.Node] = new NodeCreationBehavier(_viewModel),
                        [ElementType.Edge] = new EdgeCreationBehavier(_viewModel),
                    },
                    [ElementMode.Modification] = new()
                    {
                        [ElementType.Weight] = new WeightChangingBehavier(_viewModel),
                        [ElementType.Move] = new PositionChangingBehavier(_viewModel),
                    },
                    [ElementMode.Removal] = new()
                    {
                        [ElementType.Node] = new NodeRemovalBehavier(_viewModel),
                        [ElementType.Edge] = new EdgeRemovalBehavier(_viewModel),
                    },
                    [ElementMode.Algoritm] = new()
                    {
                        [ElementType.BreadthFirstSearch] = new BreadthFirstSearch(_viewModel),
                        [ElementType.DepthFirstSearch] = new DepthFirstSearch(_viewModel),
                        [ElementType.Dijkstra] = new Dijkstra(_viewModel),
                        [ElementType.AStar] = new AStar(_viewModel),
                    },
                };
            }


            public void SetBehavier(BehavierInfo info)
            {
                ResetState();

                SetIfNotNull();

                void ResetState()
                {
                    _viewModel.IsActiveGraphCommandEnabled = false;
                    _viewModel.IsActiveNodePositionCommandEnabled = false;

                    _viewModel.IsNodesMovingEnabled = false;
                    _viewModel.IsWeightChangingEnabled = false;

                    _viewModel.IsEdgesWeightsVisible = false;
                    _viewModel.IsNodeWeightsVisible = false;
                }
                void SetIfNotNull()
                {
                    ElementMode mode = info.SelectedElementMode;
                    ElementType type = info.SelectedElementType;

                    if (mode is not ElementMode.None &&
                        type is not ElementType.None)
                    {
                        _behaviers[mode][type].MakeActive();
                    }
                }
            }
        }
    }
}
