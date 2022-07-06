using GraphAlgoritms.Core.Events;
using GraphAlgoritms.Core.SendingInfo;

using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Modules.Elements.ViewModels
{
    public partial class ElementsViewModel
    {
        private class SenderManager
        {
            private ElementsViewModel _viewModel;

            public SenderManager(ElementsViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public void Send()
            {
                BehavierInfo info = new()
                {
                    SelectedElementMode = _viewModel._selectedMode,
                    SelectedElementType = _viewModel._selectedType,
                };

                _viewModel._eventAggregator.GetEvent<BehavierSelectedEvent>().Publish(info);
            }
        }
    }
}
