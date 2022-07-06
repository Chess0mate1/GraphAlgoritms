using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Business.AlgoritmInfoResult.ShortestPath.AStar
{
    internal class MinimumWeightNodeAStarInfo : MinimumWeightNodeInfo
    {
        public IEnumerable<Node> MinWeightNodes { get; set; }

        public Node HeuristicallyFoundNode { get; set; }
    }
}
