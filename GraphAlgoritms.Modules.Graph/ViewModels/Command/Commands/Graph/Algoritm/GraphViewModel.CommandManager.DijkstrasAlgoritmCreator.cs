using GraphAlgoritms.Business;
using GraphAlgoritms.Business.AlgoritmInfoResult;
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
            private class DijkstrasAlgoritmCreator : GraphFindingShortestPathAlgoritmCreator
            {
                public DijkstrasAlgoritmCreator(GraphViewModel graphVM) 
                    : base(graphVM) { }

                protected override GraphFindingShortestPathAlgoritmInfo GetMinWay(Node startNode, Node finishNode)
                {
                    return _graph.GetDijkstrasAlgorithmInfo(startNode, finishNode);
                }
            }
        }
    }
}
