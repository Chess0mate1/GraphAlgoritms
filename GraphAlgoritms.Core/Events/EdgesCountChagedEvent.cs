using GraphAlgoritms.Core.SendingInfo;
using Prism.Events;

namespace GraphAlgoritms.Core.Events
{
    public class EdgesCountChagedEvent : PubSubEvent<GraphElementCountsInfo> { }
}
