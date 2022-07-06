using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Modules.Graph.ViewModels
{
    public partial class GraphViewModel
    {
        private partial class BehavierManager
        {
            class NodeRemovalBehavier : BehavierBase
            {
                public NodeRemovalBehavier(GraphViewModel viewModel)
                    : base(viewModel) { }

                public override void MakeActive()
                {
                    _viewModel.IsActiveGraphCommandEnabled = true;
                }
            }
        }
    }
}
