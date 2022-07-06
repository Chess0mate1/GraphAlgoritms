using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Business.AlgoritmInfoResult.Traversal
{
    public class VisitStepGTA
    {
        public Node RemovedToBeVisitedElement { get; set; }
        public List<NeigbourNodeStepGTA> NeigbourNodeStepsSA { get; set; } = new();
    }
}
