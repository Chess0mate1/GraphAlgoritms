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
            private abstract class EnablerBase
            {
                protected ElementsEnabledManager _manager;
                //protected ElementsViewModel _viewModel => _manager._viewModel;
                //protected ElementMode _mode => _viewModel._selectedMode;
                //protected ElementType _type => _viewModel._selectedType;
                protected abstract ElementMode _mode { get; }
                protected abstract ElementType _type { get; }

                protected int _nodesCount;
                protected int _nodesMaxCount;
                protected int _edgesCount;
                protected int _edgesMaxCount;


                public EnablerBase(ElementsEnabledManager manager)
                {
                    _manager = manager;
                }


                public void SetCountsInfo(GraphElementCountsInfo info)
                {
                    _nodesCount = info.NodesCount;
                    _nodesMaxCount = info.NodesMaxCount;
                    _edgesCount = info.EdgesCount;
                    _edgesMaxCount = info.EdgesMaxCount;
                }

                public void Enable()
                {
                    if (CanBeEnabled())
                        _manager._allTypeViewModels[_mode][_type].IsEnabled = true;
                }

                protected abstract bool CanBeEnabled();
            }
        }
    }
}
