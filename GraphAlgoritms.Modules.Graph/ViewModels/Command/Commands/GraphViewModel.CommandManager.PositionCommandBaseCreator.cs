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
            private abstract class PositionCommandBaseCreator : CommandBaseCreator<Point?>
            {
                public PositionCommandBaseCreator(GraphViewModel graphVM) 
                    : base(graphVM) { }

                protected override bool CanExecute(Point? position)
                {
                    return _viewModel.IsActiveNodePositionCommandEnabled;
                }
            }
        }
    }
}
