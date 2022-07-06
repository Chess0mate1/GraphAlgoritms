using GraphAlgoritms.Core.SendingInfo;
using GraphAlgoritms.Core.Types;

using Prism.Events;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Core.Events
{
    public class NodesCountChagedEvent : PubSubEvent<GraphElementCountsInfo> { }
}
