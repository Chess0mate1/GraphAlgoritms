using GraphAlgoritms.Business.AlgoritmInfoResult;
using GraphAlgoritms.Business.Algoritms.ShortestPath;
using GraphAlgoritms.Business.Algoritms.Traversal;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GraphAlgoritms.Business
{
    public class GraphContainer
    {
        public readonly HashSet<Node> Nodes = new();
        public readonly HashSet<Edge> Edges = new();

        public GraphContainer()
        {
            Nodes = new();
            Edges = new();
        }

        public GraphTraversalAlgoritmInfo GetBfsAlgorithmInfo(Node startNode, Node finishNode)
        {
            return new BreadthFirstSearchAlgoritm().Calculate(startNode, finishNode);
        }
        public GraphTraversalAlgoritmInfo GetDfsAlgorithmInfo(Node startNode, Node finishNode)
        {
            return new DepthFirstSearchAlgoritm().Calculate(startNode, finishNode);
        }
        public GraphFindingShortestPathAlgoritmInfo GetDijkstrasAlgorithmInfo(Node startNode, Node finishNode)
        {
            ResetWeights(startNode);
            return new DijkstrasAlgorithm().Calculate(startNode, finishNode);
        }
        public GraphFindingShortestPathAlgoritmInfo GetAStarAlgoritmInfo(Node startNode, Node finishNode)
        {
            ResetWeights(startNode);
            return new AStarAlgoritm().Calculate(startNode, finishNode);
        }

        private void ResetWeights(Node startNode)
        {
            foreach (var node in Nodes)
                node.Weight = double.PositiveInfinity;

            Nodes.Single(n => n.Id == startNode.Id).Weight = 0;
        }
    }
}
