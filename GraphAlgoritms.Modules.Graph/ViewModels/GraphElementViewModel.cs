using GraphAlgoritms.Business.Graph;

using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Modules.Graph.ViewModels
{
    public class GraphElementViewModel : BindableBase
    {
        private int _index;
        public int Index
        {
            get { return _index; }
            set { SetProperty(ref _index, value); }
        }

        public GraphElementViewModel(int index)
        {
            _index = index;
        }
    }
}
