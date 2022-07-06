using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Business.AlgoritmInfoResult
{
    public abstract class GraphResultInfo
    {
        public abstract HashSet<Node> ResultWay { get; }
    }
}
