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
            private abstract class BehavierBase
            {
                protected readonly GraphViewModel _viewModel;

                protected BehavierBase(GraphViewModel viewModel)
                {
                    _viewModel = viewModel;
                }

                public abstract void MakeActive();
            }
        }
    }
}
