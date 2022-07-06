using GraphAlgoritms.Business.Graph;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Business
{
    public class Edge : GraphElement
    {
        public double Weight { get; set; }

        public Node FirstNode { get; set; }
        public Node SecondNode { get; set; }
    }
}
