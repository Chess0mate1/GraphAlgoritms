using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Business.Algoritms.ShortestPath
{
    internal class BreadthFirstSearchAlgoritm : GraphTraversalAlgorithm<Queue<Node>>
    {
        protected override void AddNodeToToBeVisited(Node node)
        {
            _toBeVisited.Enqueue(node);
        }

        protected override Node RemoveItemFromToBeVisted()
        {
            return _toBeVisited.Dequeue();
        }
    }
}
