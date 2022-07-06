using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

using System.Windows;
using GraphAlgoritms.Core.Types;
using Prism.Events;
using GraphAlgoritms.Core.Events;
using GraphAlgoritms.Core.SendingInfo;

namespace GraphAlgoritms.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        IEventAggregator _eventAggregator;

        private string _title; 
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            _title = "Алгоритмы на графах";

            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<GraphElementsCountChangedEvent>().Subscribe(OnGraphElementsCountChangedEvent);
            _eventAggregator.GetEvent<BehavierSelectedEvent>().Subscribe(OnModeSelectedEvent);

            AlgoritmExecuteCommand = new(SendSelectedAction, CanSendSelectedAction);
        }



        public DelegateCommand<AlgoritmExecuteType?> AlgoritmExecuteCommand { get; }

        private void SendSelectedAction(AlgoritmExecuteType? type)
        {
            //MessageBox.Show(type.ToString());
            _eventAggregator.GetEvent<AlgoritmExecuteTypeSelectedEvent>().Publish((AlgoritmExecuteType)type);
        }

        
        private bool CanSendSelectedAction(AlgoritmExecuteType? type)
        {
            bool algoritmExecuteTypeSelected = type is not AlgoritmExecuteType.None;

            return _isAlgoritmMode && _anyNodes && algoritmExecuteTypeSelected;
        }

        private bool _isAlgoritmMode;
        private void OnModeSelectedEvent(BehavierInfo info)
        {
            _isAlgoritmMode = info.SelectedElementMode is ElementMode.Algoritm;
        }

        private bool _anyNodes;
        private void OnGraphElementsCountChangedEvent(GraphElementCountsInfo info)
        {
            _anyNodes = info.NodesCount > 0;
        }
    }
}
