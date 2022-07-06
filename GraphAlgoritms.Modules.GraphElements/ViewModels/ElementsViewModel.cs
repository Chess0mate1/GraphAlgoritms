using GraphAlgoritms.Core;
using GraphAlgoritms.Core.Events;
using GraphAlgoritms.Core.SendingInfo;
using GraphAlgoritms.Core.Types;
using GraphAlgoritms.Modules.Elements.Services;

using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Modules.Elements.ViewModels
{
    public partial class ElementsViewModel : BindableBase
    {
        private ElementsEnabledManager _enabledManager;
        private readonly IEventAggregator _eventAggregator;
        private ElementMode _selectedMode;
        private ElementType _selectedType;


        private readonly Dictionary<ElementMode, ObservableCollection<TypeViewModel>> _allTypeViewModels;

        private ObservableCollection<ModeViewModel> _modeViewModels;
        public ObservableCollection<ModeViewModel> ModeViewModels
        {
            get { return _modeViewModels; }
            set { SetProperty(ref _modeViewModels, value); }
        }

        private ObservableCollection<TypeViewModel> _activeTypeViewModels;
        public ObservableCollection<TypeViewModel> ActiveTypeViewModels
        {
            get { return _activeTypeViewModels; }
            set { SetProperty(ref _activeTypeViewModels, value); }
        }


        public DelegateCommand<TypeViewModel> TypeSelectedCommand { get; }
        public DelegateCommand<ModeViewModel> ModeSelectedCommand { get; }


        public ElementsViewModel(IEventAggregator eventAggregator)
        {
            ModeViewModels = new(new ModesFactory().Create());
            _allTypeViewModels = new(new TypesFactory().Create());

            TypeSelectedCommandCreator creator = new(this);
            creator.TypeSelected += new SenderManager(this).Send;
            TypeSelectedCommand = creator.Create();
            ModeSelectedCommand = new ModeSelectedCommandCreator(this).Create();

            _eventAggregator = eventAggregator;
            _enabledManager = new(this);
            _eventAggregator.GetEvent<GraphElementsCountChangedEvent>().Subscribe(_enabledManager.SetState);
        }
    }
}
