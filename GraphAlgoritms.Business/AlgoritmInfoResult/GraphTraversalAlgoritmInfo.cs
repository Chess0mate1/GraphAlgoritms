using GraphAlgoritms.Business.AlgoritmInfoResult.Traversal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Business.AlgoritmInfoResult
{
    public class GraphTraversalAlgoritmInfo : GraphResultInfo
    {
        public override HashSet<Node> ResultWay
        {
            get
            {
                HashSet<Node> resultWay = new();

                foreach (var step in VisitStepsSA)
                {
                    Node removedNode = step.RemovedToBeVisitedElement;

                    if (removedNode is not null)
                    {
                        resultWay.Add(removedNode);
                    }
                }

                return resultWay;
            }
        }

        public List<VisitStepGTA> VisitStepsSA { get; set; } = new();
    }
}
