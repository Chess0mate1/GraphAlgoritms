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
            class AStar : BehavierBase
            {
                public AStar(GraphViewModel viewModel)
                    : base(viewModel) { }

                public override void MakeActive()
                {
                    _viewModel.IsActiveGraphCommandEnabled = true;

                    _viewModel.IsNodeWeightsVisible = true;
                    _viewModel.IsEdgesWeightsVisible = true;
                }
            }
        }
    }
}
