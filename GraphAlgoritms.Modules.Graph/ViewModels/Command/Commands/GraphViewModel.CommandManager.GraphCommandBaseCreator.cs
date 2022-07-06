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
            private abstract class GraphCommandBaseCreator : CommandBaseCreator<GraphElementViewModel>
            {
                public GraphCommandBaseCreator(GraphViewModel graphVM)
                    : base(graphVM) { }

                protected override bool CanExecute(GraphElementViewModel graphElementVM)
                {
                    return _viewModel.IsActiveGraphCommandEnabled;
                }
            }
        }
    }
}
