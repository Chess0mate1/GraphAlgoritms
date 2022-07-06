using GraphAlgoritms.Business.Graph;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Business
{
    public class Node : GraphElement
    {
        private Dictionary<Node, Edge> _edgeByNodes = new();
        private Dictionary<Edge, Node> _nodesByEdges = new();

        public double Weight {get; set; }


        public bool TryAddNeigbour(Edge commonEdge, Node neigbourNode)
        {
            if (_nodesByEdges.ContainsKey(commonEdge) is false &&
                _edgeByNodes.ContainsKey(neigbourNode) is false)
            {
                _edgeByNodes[neigbourNode] = commonEdge;
                _nodesByEdges[commonEdge] = neigbourNode;

                return true;
            }

            return false;
        }

        public bool TryRemoveNeigbour(Edge commonEdge)
        {
            if (_nodesByEdges.ContainsKey(commonEdge))
            {
                Node neigbourNode = _nodesByEdges[commonEdge];
                RemoveNeigbour(neigbourNode, commonEdge);

                return true;
            }

            return false;
        }
        public bool TryRemoveNeigbour(Node neigbourNode)
        {
            if (_edgeByNodes.ContainsKey(neigbourNode))
            {
                Edge commonEdge = _edgeByNodes[neigbourNode];
                RemoveNeigbour(neigbourNode, commonEdge);

                return true;
            }

            return false;
        }
        private void RemoveNeigbour(Node neigbourNode, Edge commonEdge)
        {
            _edgeByNodes.Remove(neigbourNode);
            _nodesByEdges.Remove(commonEdge);
        }

        public bool ContainsNeigbouNode(Node node)
            => _edgeByNodes.ContainsKey(node);
        public bool ContainsCommonEdge(Edge edge)
            => _nodesByEdges.ContainsKey(edge);

        public Edge GetCommonEdge(Node neigbourNode) 
            => _edgeByNodes[neigbourNode];
        public Node GetNeigbourNode(Edge commonEdge)
            =>_nodesByEdges[commonEdge];

        public HashSet<Node> NeigbourNodes
            => _nodesByEdges.Values.ToHashSet();
        public HashSet<Edge> CommonEdges
            => _edgeByNodes.Values.ToHashSet();
    }
}
