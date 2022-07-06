using GraphAlgoritms.Business.AlgoritmInfoResult;
using GraphAlgoritms.Business.AlgoritmInfoResult.ShortestPath;

namespace GraphAlgoritms.Business.Algoritms
{
    internal abstract class GraphFindingShortestPathAlgoritm
    {
        protected HashSet<Node> _toBeVisited = new();
        protected HashSet<Node> _visited = new();
        protected GraphFindingShortestPathAlgoritmInfo _info = new();

        public GraphFindingShortestPathAlgoritm()
        {
            _toBeVisited = new();
            _visited = new();
            _info = new();
        }

        public virtual GraphFindingShortestPathAlgoritmInfo Calculate(Node startNode, Node finishNode)
        {
            _toBeVisited.Add(startNode);
            AddNodeToBeVisitedInfo(startNode);

            while (_toBeVisited.Any())
            {
                var currentNode = GetMinWeightNode();

                _toBeVisited.Remove(currentNode);
                AddRemovedFromToBeVisitedNodeInfo(currentNode);
                AddWayInfo(currentNode);

                if (currentNode == finishNode)
                    return _info;

                foreach (var neigbourNode in currentNode.NeigbourNodes
                    .Where(n => !_visited.Contains(n)))
                {
                    _toBeVisited.Add(neigbourNode);
                    AddNodeToBeVisitedInfo(neigbourNode);

                    double edgeWeight = neigbourNode.GetCommonEdge(currentNode).Weight;
                    double newProbableNeigbourNodeWeight = currentNode.Weight + edgeWeight;
                    AddNewNeigbourNodeInfo(
                        currentNode.Weight, neigbourNode.Weight, 
                        edgeWeight, newProbableNeigbourNodeWeight);

                    if (neigbourNode.Weight > newProbableNeigbourNodeWeight)
                        neigbourNode.Weight = newProbableNeigbourNodeWeight;
                }

                _visited.Add(currentNode);
                AddVisitedNodeInfo(currentNode);
            }

            throw new Exception($"Путь не существует: узлы {startNode.Id} и {finishNode.Id} не находятся в общем графе");
        }


        protected virtual Node GetMinWeightNode()
        {
            var minWeightNode = _toBeVisited.MinBy(n => n.Weight);
            AddGetMinWeightNodeInfo(minWeightNode);

            return minWeightNode;
        }

        private void AddGetMinWeightNodeInfo(Node node)
        {
            _info.VisitStepsHA.Add(new VisitStepGFSPA()
            {
                MinimumWeightNodeInfo = new MinimumWeightNodeInfo()
                {
                    MinWeightNode = node
                }
            });
        }

        private void AddNewNeigbourNodeInfo(
            double currentNodeWeight,
            double neigbourNodeWeight,
            double edgeWeight,
            double newProbableNeigbourNodeWeight)
        {
            _info.VisitStepsHA[^1].NeigbourNodeStepsHA[^1].CurrentNodeWeight = currentNodeWeight;
            _info.VisitStepsHA[^1].NeigbourNodeStepsHA[^1].NeigbourNodeWeight = neigbourNodeWeight;
            _info.VisitStepsHA[^1].NeigbourNodeStepsHA[^1].EdgeWeight = edgeWeight;
            _info.VisitStepsHA[^1].NeigbourNodeStepsHA[^1].NewProbableNeigbourNodeWeight = newProbableNeigbourNodeWeight;
        }

        private void AddVisitedNodeInfo(Node node)
        {
            _info.VisitStepsHA[^1].VisitedElement = node;
        }

        private void AddNodeToBeVisitedInfo(Node node)
        {
            List<VisitStepGFSPA> allVisitSteps = _info.VisitStepsHA;
            NeigbourNodeStepGFSPA newNeigbourStep = new()
            {
                AddedToBeVisitedElement = node
            };

            if (allVisitSteps.Any())
            {
                allVisitSteps[^1].NeigbourNodeStepsHA.Add(newNeigbourStep);
            }
            else
            {
                allVisitSteps.Add(new VisitStepGFSPA()
                {
                    NeigbourNodeStepsHA = new List<NeigbourNodeStepGFSPA>()
                    {
                        newNeigbourStep
                    }
                });
            }
        }

        private void AddRemovedFromToBeVisitedNodeInfo(Node node)
        {
            _info.VisitStepsHA[^1].RemovedToBeVisitedNode = node;
        }

        private void AddWayInfo(Node node)
        {
            List<VisitStepGFSPA> allSteps = _info.VisitStepsHA;

            bool isStartStep = allSteps.Count is 2;
            if (isStartStep)
            {
                allSteps[1].Way = new HashSet<Node>() 
                { 
                    node 
                };
            }
            else
            {
                allSteps[^1].Way = new HashSet<Node>(GetWayPriviousNode()) 
                { 
                    node 
                };


                HashSet<Node> GetWayPriviousNode() => (from n in _info.VisitStepsHA
                                                        from t in n.NeigbourNodeStepsHA
                                                        where t.AddedToBeVisitedElement == node
                                                        orderby t.NewProbableNeigbourNodeWeight
                                                        select n.Way).First();
            }
        }
    }
}
