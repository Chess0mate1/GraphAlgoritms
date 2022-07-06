using GraphAlgoritms.Business.AlgoritmInfoResult;
using GraphAlgoritms.Business.AlgoritmInfoResult.Traversal;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GraphAlgoritms.Business.Algoritms
{
    internal abstract class GraphTraversalAlgorithm<T>
        where T : IEnumerable<Node>, IEnumerable, IReadOnlyCollection<Node>, ICollection, new()
    {
        protected T _toBeVisited;
        protected HashSet<Node> _visited;
        protected GraphTraversalAlgoritmInfo _result;

        public GraphTraversalAlgorithm()
        {
            _toBeVisited = new();
            _visited = new();

            _result = new();
        }


        public GraphTraversalAlgoritmInfo Calculate(Node startNode, Node finishNode)
        {
            AddNodeOperations(startNode);

            while (_toBeVisited.Any())
            {
                var currentNode = RemoveItemFromToBeVisted();
                AddRemovedFromToBeVisitedNodeInfo(currentNode);

                foreach (var neigbourNode in currentNode.NeigbourNodes
                    .Where(n => !_visited.Contains(n)))
                {
                    AddNodeOperations(neigbourNode);
                }
            }

            return _result;
        }


        private void AddNodeOperations(Node node)
        {
            AddNodeToCollections(node);
            AddNodeToCollectionsInfo(node);
        }

        protected void AddNodeToCollections(Node node)
        {
            AddNodeToToBeVisited(node);
            _visited.Add(node);
        }

        protected void AddNodeToCollectionsInfo(Node node)
        {
            NeigbourNodeStepGTA neigbourSearchStep = new()
            {
                AddedToBeVisitedElement = node,
                VisitedElement = node
            };

            List<VisitStepGTA> visitSteps = _result.VisitStepsSA;

            if (visitSteps.Count is 0)
            {
                neigbourSearchStep.Way = new HashSet<Node>() 
                { 
                    node 
                };

                visitSteps.Add(new VisitStepGTA()
                {
                    NeigbourNodeStepsSA = new List<NeigbourNodeStepGTA>()
                    {
                        neigbourSearchStep
                    }
                });
            }
            else
            {
                neigbourSearchStep.Way = new HashSet<Node>(GetPrivious()) 
                { 
                    node 
                };

                visitSteps[^1].NeigbourNodeStepsSA.Add(neigbourSearchStep);

                HashSet<Node> GetPrivious()
                {
                    Node removedToBeVisitedElement = _result.VisitStepsSA[^1].RemovedToBeVisitedElement;

                    return (from n in _result.VisitStepsSA
                            from t in n.NeigbourNodeStepsSA
                            where t.AddedToBeVisitedElement == removedToBeVisitedElement
                            select t.Way).First();
                }
            }
        }

        protected void AddRemovedFromToBeVisitedNodeInfo(Node node)
        {
            _result.VisitStepsSA.Add(new VisitStepGTA()
            {
                RemovedToBeVisitedElement = node
            });
        }

        protected abstract void AddNodeToToBeVisited(Node node);
        protected abstract Node RemoveItemFromToBeVisted();
    }
}
