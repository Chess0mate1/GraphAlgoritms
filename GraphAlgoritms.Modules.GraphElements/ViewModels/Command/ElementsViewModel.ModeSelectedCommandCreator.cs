using GraphAlgoritms.Core.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Modules.Elements.ViewModels
{
    public partial class ElementsViewModel
    {
        private class ModeSelectedCommandCreator : CommandCreator<ElementsViewModel, ModeViewModel>
        {
            public ModeSelectedCommandCreator(ElementsViewModel elementsVM)
                : base(elementsVM) { }

            protected override void Execute(ModeViewModel modeVM)
            {
                _viewModel._selectedMode = modeVM.Mode;

                _viewModel.ActiveTypeViewModels = _viewModel._allTypeViewModels[_viewModel._selectedMode];
            }

            protected override bool CanExecute(ModeViewModel modeVM)
            {
                return true;
            }
        }
    }
}
