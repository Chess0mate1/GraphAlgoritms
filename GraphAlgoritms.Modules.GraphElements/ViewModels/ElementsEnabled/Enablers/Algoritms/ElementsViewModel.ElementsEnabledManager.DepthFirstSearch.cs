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
            private class DepthFirstSearch : EnablerBase
            {
                protected override ElementMode _mode => ElementMode.Algoritm;
                protected override ElementType _type => ElementType.DepthFirstSearch;


                public DepthFirstSearch(ElementsEnabledManager manager)
                    : base(manager) { }


                //доделать + 
                protected override bool CanBeEnabled()
                {
                    return _nodesCount > 0;
                }
            }
        }
    }
}
