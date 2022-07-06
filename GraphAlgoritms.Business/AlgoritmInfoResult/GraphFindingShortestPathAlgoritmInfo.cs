using GraphAlgoritms.Business.AlgoritmInfoResult.ShortestPath;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Business.AlgoritmInfoResult
{
    public class GraphFindingShortestPathAlgoritmInfo : GraphResultInfo
    {
        public override HashSet<Node> ResultWay => VisitStepsHA[^1].Way;

        public List<VisitStepGFSPA> VisitStepsHA { get; set; } = new();
    }
}
