using GraphAlgoritms.Business;
using GraphAlgoritms.Business.AlgoritmInfoResult;
using GraphAlgoritms.Business.Graph;
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
            private abstract class AlgoritmCommandCreator<T> : GraphCommandBaseCreator
                where T : GraphResultInfo
            {
                private NodeViewModel _firstNode;
                private bool _isFirstNodeSelected;

                public AlgoritmCommandCreator(GraphViewModel graphVM) 
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

                        //if (_firstNode.Index == currentNode.Index)
                        //    return;
                        try
                        {
                            T result = GetMinWay(_firstNode.GetNode(), currentNode.GetNode());
                            ShowResult(result);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show($"{e.Message}");
                        }
                        

                        _isFirstNodeSelected = false;
                    }
                }

                protected abstract T GetMinWay(Node startNode, Node finishNode);

                protected abstract void ShowResult(GraphResultInfo info);
            }
        }
    }
}
