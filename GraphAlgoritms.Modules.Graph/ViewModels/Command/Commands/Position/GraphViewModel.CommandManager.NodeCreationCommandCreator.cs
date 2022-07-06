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
            private class NodeCreationCommandCreator : PositionCommandBaseCreator
            {
                public NodeCreationCommandCreator(GraphViewModel graphVM)
                    : base(graphVM) { }

                protected override void Execute(Point? position)
                {
                    Point currentPosition = (Point)position;

                    NodeViewModel nodeViewModel = new(_index)
                    {
                        Name = _alphabet[_index].ToString(),

                        NamePositionX = currentPosition.X - _radious,
                        NamePositionY = currentPosition.Y - _radious
                    };

                    _graph.Nodes.Add(nodeViewModel.GetNode());

                    _nodeViewModels.Add(nodeViewModel);

                    _index++;
                }
            }
        }
    }
}
