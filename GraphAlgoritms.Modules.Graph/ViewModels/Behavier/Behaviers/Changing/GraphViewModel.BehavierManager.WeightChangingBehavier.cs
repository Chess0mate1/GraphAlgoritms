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
            class WeightChangingBehavier : BehavierBase
            {
                public WeightChangingBehavier(GraphViewModel viewModel)
                    : base(viewModel) { }

                public override void MakeActive()
                {
                    _viewModel.IsEdgesWeightsVisible = true;
                    _viewModel.IsWeightChangingEnabled = true;
                }
            }
        }
    }
}
