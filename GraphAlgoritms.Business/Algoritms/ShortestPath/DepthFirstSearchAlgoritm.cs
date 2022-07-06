using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Business.Algoritms.ShortestPath
{
    internal class DepthFirstSearchAlgoritm : GraphTraversalAlgorithm<Stack<Node>>
    {
        protected override void AddNodeToToBeVisited(Node node)
        {
            _toBeVisited.Push(node);
        }

        protected override Node RemoveItemFromToBeVisted()
        {
            return _toBeVisited.Pop();
        }
    }
}
