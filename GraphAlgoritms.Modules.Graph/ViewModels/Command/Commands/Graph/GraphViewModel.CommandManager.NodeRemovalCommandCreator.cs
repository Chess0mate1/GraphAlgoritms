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
            private class NodeRemovalCommandCreator : GraphCommandBaseCreator
            {
                public NodeRemovalCommandCreator(GraphViewModel graphVM)
                    : base(graphVM) { }

                protected override void Execute(GraphElementViewModel graphElementVM)
                {
                    if (graphElementVM is NodeViewModel nodeVM)
                    {
                        foreach (var edgeVM in nodeVM.EdgeViewModels)
                            _edgeViewModels.Remove(edgeVM);

                        _nodeViewModels.Remove(nodeVM);
                    }
                }
            }
        }
    }
}
