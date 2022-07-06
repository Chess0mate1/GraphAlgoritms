using GraphAlgoritms.Business.AlgoritmInfoResult;
using GraphAlgoritms.Business.AlgoritmInfoResult.ShortestPath.AStar;
using GraphAlgoritms.Business.Algoritms.ShortestPath;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GraphAlgoritms.Business.Algoritms.Traversal
{ 
    internal class AStarAlgoritm : GraphFindingShortestPathAlgoritm
    {
        private Node _finishNode;

        public override GraphFindingShortestPathAlgoritmInfo Calculate(Node startNode, Node finishNode)
        {
            _finishNode = finishNode;

            return base.Calculate(startNode, finishNode);
        }

        protected override Node GetMinWeightNode()
        {
            var minWeightNode = base.GetMinWeightNode();

            var minWeightNodes = _toBeVisited.Where(node => node.Weight == minWeightNode.Weight);
            var minNodeWithShortestWay = FindNodeHeuristically();
            AddGetMinWeightNodeStarAInfo(minWeightNodes, minNodeWithShortestWay);

            return minNodeWithShortestWay;

            Node FindNodeHeuristically()
            {
                return minWeightNodes.MinBy(node => 
                    new BreadthFirstSearchAlgoritm().Calculate(node, _finishNode).ResultWay.Count
                );
            }
        }

        private void AddGetMinWeightNodeStarAInfo(IEnumerable<Node> nodes, Node node)
        {
            MinimumWeightNodeAStarInfo info = new()
            {
                MinWeightNode = node,
                MinWeightNodes = nodes.ToHashSet(),
                HeuristicallyFoundNode = node
            };

            _info.VisitStepsHA[^1].MinimumWeightNodeInfo = info;
        }
    }
}
