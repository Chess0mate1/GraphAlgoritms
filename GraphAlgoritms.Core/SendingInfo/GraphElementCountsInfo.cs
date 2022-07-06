using GraphAlgoritms.Core.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Core.SendingInfo
{
    public enum GraphElementCountChangeMode
    {
        Increased,
        Decreased
    }

    public class GraphElementCountsInfo
    {
        public readonly int NodesMaxCount = 20;

        public int NodesCount { get; set; }
        public int EdgesCount { get; set; }

        public int EdgesMaxCount => NodesCount * (NodesCount - 1) / 2;
    }
}
