using GraphAlgoritms.Core.Commands;
using GraphAlgoritms.Core.Events;
using GraphAlgoritms.Core.SendingInfo;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Modules.Graph.ViewModels
{
    public partial class GraphViewModel
    {
        private partial class CommandManager
        {
            private class EdgeCreationCommandCreator : GraphCommandBaseCreator
            {
                private NodeViewModel _firstNode;
                private bool _isFirstNodeSelected;

                public EdgeCreationCommandCreator(GraphViewModel graphVM) 
                    : base(graphVM) { }

                protected override void Execute(GraphElementViewModel graphElementVM)
                {
                    if (graphElementVM is NodeViewModel currentNode)
                    {
                        if (_isFirstNodeSelected is false)
                        {
                            _firstNode = currentNode;
                            _isFirstNodeSelected = true;

                            return;
                        }

                        if (_firstNode.Index == currentNode.Index)
                            return;

                        //if (_viewModel.EdgeViewModels.Contains(_viewModel.EdgeViewModels.Where(e=>
                        //    (e.FirstNodeViewModel.Index == _firstNode.Index || e.FirstNodeViewModel.Index == currentNode.Index) &&
                        //    (e.SecondNodeViewModel.Index == _firstNode.Index || e.SecondNodeViewModel.Index == currentNode.Index)).First()))
                        //    return;

                        EdgeViewModel vm = new(_index)
                        {
                            FirstNodeViewModel = _firstNode,
                            SecondNodeViewModel = currentNode
                        };

                        _firstNode.GetNode().TryAddNeigbour(vm.GetEdge(), currentNode.GetNode());
                        currentNode.GetNode().TryAddNeigbour(vm.GetEdge(), _firstNode.GetNode());
                        _graph.Edges.Add(vm.GetEdge());

                        _nodeViewModels.Single(vm => vm.Index == _firstNode.Index).EdgeViewModels.Add(vm);
                        _nodeViewModels.Single(vm => vm.Index == currentNode.Index).EdgeViewModels.Add(vm);
                        _edgeViewModels.Add(vm);

                        _index++;
                        _isFirstNodeSelected = false;
                    }
                }
            }
        }
    }
}
