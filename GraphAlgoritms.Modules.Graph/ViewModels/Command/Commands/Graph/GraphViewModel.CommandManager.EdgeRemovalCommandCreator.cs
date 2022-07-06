using GraphAlgoritms.Core.Commands;
using GraphAlgoritms.Core.Events;
using GraphAlgoritms.Core.SendingInfo;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphAlgoritms.Modules.Graph.ViewModels
{
    public partial class GraphViewModel
    {
        private partial class CommandManager
        {
            private class EdgeRemovalCommandCreator : GraphCommandBaseCreator
            {
                public EdgeRemovalCommandCreator(GraphViewModel graphVM)
                    : base(graphVM) { }

                protected override void Execute(GraphElementViewModel graphElementVM)
                {
                    if (graphElementVM is EdgeViewModel edgeVM)
                    {
                        foreach (var nodeVM in _nodeViewModels)
                            if (nodeVM.EdgeViewModels.Contains(edgeVM))
                                nodeVM.EdgeViewModels.Remove(edgeVM);

                        _edgeViewModels.Remove(edgeVM);
                    }
                }
            }
        }
    }
}
