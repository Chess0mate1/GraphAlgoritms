using GraphAlgoritms.Core.SendingInfo;
using GraphAlgoritms.Core.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Modules.Elements.ViewModels
{
    public partial class ElementsViewModel
    {
        private partial class ElementsEnabledManager
        {
            private class EdgesRemovalEnabler : EnablerBase
            {
                protected override ElementMode _mode => ElementMode.Removal;
                protected override ElementType _type => ElementType.Edge;


                public EdgesRemovalEnabler(ElementsEnabledManager manager)
                    : base(manager) { }


                protected override bool CanBeEnabled()
                {
                    return _edgesCount > 0;
                }
            }
        }
    }
}
