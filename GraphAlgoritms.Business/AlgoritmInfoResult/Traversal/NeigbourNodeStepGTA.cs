using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Business.AlgoritmInfoResult.Traversal
{
    public class NeigbourNodeStepGTA
    {
        public Node AddedToBeVisitedElement { get; set; }
        public Node VisitedElement { get; set; }

        public HashSet<Node> Way { get; set; }
    }
}
