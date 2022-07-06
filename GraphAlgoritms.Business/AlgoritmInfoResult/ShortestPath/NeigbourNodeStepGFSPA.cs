using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Business.AlgoritmInfoResult.ShortestPath
{
    public class NeigbourNodeStepGFSPA
    {
        public double NeigbourNodeWeight;
        public double CurrentNodeWeight;
        public double EdgeWeight;
        public double NewProbableNeigbourNodeWeight;

        public Node AddedToBeVisitedElement { get; set; }
    }
}
