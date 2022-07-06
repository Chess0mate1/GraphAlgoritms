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
using System.Windows;

namespace GraphAlgoritms.Modules.Graph.ViewModels
{
    public partial class GraphViewModel
    {
        private partial class CommandManager
        {
            private class DepthFirstSearchAlgoritmCreator : GraphTraversalAlgoritmCreator
            {

                public DepthFirstSearchAlgoritmCreator(GraphViewModel graphVM) 
                    : base(graphVM) { }

                protected override void ShowResult(GraphResultInfo info)
                {
                    var curInfo = (GraphTraversalAlgoritmInfo)info;

                    string path = "порядок обхода:\n";
                    foreach (var node in curInfo.ResultWay)
                    {
                        path += "\n" + _nodeViewModels.First(vm => vm.Index == node.Id).Name;
                    }

                    MessageBox.Show(path);
                }

                protected override GraphTraversalAlgoritmInfo GetMinWay(Node startNode, Node finishNode)
                {
                    return _graph.GetDfsAlgorithmInfo(startNode, finishNode);
                }
            }
        }
    }
}
