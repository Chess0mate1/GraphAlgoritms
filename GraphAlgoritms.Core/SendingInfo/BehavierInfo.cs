using GraphAlgoritms.Core.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Core.SendingInfo
{
    public class BehavierInfo
    {
        public ElementMode SelectedElementMode { get; set; }

        public ElementType SelectedElementType { get; set; }

        //public bool IsSet 
        //    => SelectedElementMode is not null && 
        //       SelectedElementType is not null;
    }
}
