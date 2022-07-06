using GraphAlgoritms.Core.Types;

using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Modules.Elements.ViewModels
{
    public class TypeViewModel : BindableBase
    {
        public ElementType Type { get; set; }
        public string Name { get; set; }        
        public string ImagePath { get; set; }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }
    }
}
