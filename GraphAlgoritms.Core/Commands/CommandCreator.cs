using Prism.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Core.Commands
{
    public abstract class CommandCreator<ViewModel, CommandParameterType>
    {
        protected ViewModel _viewModel;

        public CommandCreator(ViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public DelegateCommand<CommandParameterType> Create()
        {
            return new(Execute, CanExecute);
        }

        protected abstract void Execute(CommandParameterType modeVM);

        protected abstract bool CanExecute(CommandParameterType modeVM);
    }
}
