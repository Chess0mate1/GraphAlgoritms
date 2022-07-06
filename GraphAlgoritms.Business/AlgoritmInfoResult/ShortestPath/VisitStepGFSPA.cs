using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Business.AlgoritmInfoResult.ShortestPath
{
    public class VisitStepGFSPA
    {
        public MinimumWeightNodeInfo MinimumWeightNodeInfo { get; set; }

        public Node RemovedToBeVisitedNode { get; set; }
        public Node VisitedElement { get; set; }
        public HashSet<Node> Way { get; set; }

        public List<NeigbourNodeStepGFSPA> NeigbourNodeStepsHA { get; set; } = new();
    }
}
