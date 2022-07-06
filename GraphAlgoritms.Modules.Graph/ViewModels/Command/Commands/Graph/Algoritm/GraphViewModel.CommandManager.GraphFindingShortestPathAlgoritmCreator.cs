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
            private abstract class GraphFindingShortestPathAlgoritmCreator : AlgoritmCommandCreator<GraphFindingShortestPathAlgoritmInfo>
            {

                public GraphFindingShortestPathAlgoritmCreator(GraphViewModel graphVM) 
                    : base(graphVM) { }

                protected override void ShowResult(GraphResultInfo info)
                {
                    string path = "путь: ";
                    foreach (var node in info.ResultWay)
                    {
                        path += _nodeViewModels.First(vm => vm.Index == node.Id).Name;
                    }

                    path += " вес" + info.ResultWay.Last().Weight.ToString();
                    MessageBox.Show(path);
                }
            }
        }
    }
}
