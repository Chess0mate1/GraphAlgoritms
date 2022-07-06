using GraphAlgoritms.Core.Commands;

using Prism.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphAlgoritms.Modules.Elements.ViewModels
{
    public partial class ElementsViewModel
    {
        private class TypeSelectedCommandCreator : CommandCreator<ElementsViewModel, TypeViewModel>
        {
            public event Action TypeSelected;

            public TypeSelectedCommandCreator(ElementsViewModel elementsVM)
                : base(elementsVM) { }

            protected override void Execute(TypeViewModel typeVM)
            {
                _viewModel._selectedType = typeVM.Type;

                TypeSelected();
            }

            protected override bool CanExecute(TypeViewModel typeVM)
            {
                return typeVM is not null;
            }
        }
    }
}
