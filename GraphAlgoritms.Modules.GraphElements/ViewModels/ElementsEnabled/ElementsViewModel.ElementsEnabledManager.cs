using GraphAlgoritms.Core.SendingInfo;
using GraphAlgoritms.Core.Types;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgoritms.Modules.Elements.ViewModels
{
    public partial class ElementsViewModel
    {
        private partial class ElementsEnabledManager
        {
            private Dictionary<ElementMode, Dictionary<ElementType, TypeViewModel>> _allTypeViewModels;
            private Dictionary<ElementMode, ModeViewModel> _modeViewModels;
            private List<EnablerBase> _enablers;
            private ElementsViewModel _viewModel;


            public ElementsEnabledManager(ElementsViewModel viewModel)
            {
                _viewModel = viewModel;

                _modeViewModels = new();
                _allTypeViewModels = new();

                SetEnablers();
                SetModeViewModels();
                SetTypeViewModels();


                void SetEnablers()
                {
                    _enablers = new()
                    {
                        new NodesCreationEnabler(this),
                        new EdgesCreationEnabler(this),

                        new MoveEnabler(this),
                        new WeightChangingEnabler(this),

                        new NodesRemovalEnabler(this),
                        new EdgesRemovalEnabler(this),

                        new BreadthFirstSearch(this),
                        new DepthFirstSearch(this),
                        new Dijkstra(this),
                        new AStar(this),
                    };
                }
                void SetModeViewModels()
                {
                    foreach (var modeVM in _viewModel.ModeViewModels)
                    {
                        _modeViewModels[modeVM.Mode] = modeVM;
                    }
                }
                void SetTypeViewModels()
                {
                    foreach (var modeTypesVMs in _viewModel._allTypeViewModels)
                    {
                        Dictionary<ElementType, TypeViewModel> typeViewModels = new();

                        foreach (var typesVM in modeTypesVMs.Value)
                        {
                            typeViewModels[typesVM.Type] = typesVM;
                        }

                        _allTypeViewModels[modeTypesVMs.Key] = typeViewModels;
                    }
                }
            }

            public void SetState(GraphElementCountsInfo info)
            {
                ResetState();

                UpdateTypes();

                UpdateModes();


                void ResetState()
                {
                    foreach (var modeVM in _modeViewModels.Values)
                    {
                        modeVM.IsEnabled = false;
                    }

                    foreach (var typeVMs in _allTypeViewModels.Values)
                    {
                        foreach (var typeVm in typeVMs.Values)
                        {
                            typeVm.IsEnabled = false;
                        }
                    }
                }
                void UpdateTypes()
                {
                    foreach (var enabler in _enablers)
                    {
                        enabler.SetCountsInfo(info);
                        enabler.Enable();
                    }
                }
                void UpdateModes()
                {
                    foreach (var modeTypeVMs in _allTypeViewModels)
                    {
                        var mode = modeTypeVMs.Key;
                        var typeVMs = modeTypeVMs.Value;

                        int isNotEnabledTypeVMsCount = typeVMs
                            .Where(typeVM => typeVM.Value.IsEnabled is false)
                            .Count();

                        if (isNotEnabledTypeVMsCount == typeVMs.Count)
                        {
                            _modeViewModels[mode].IsEnabled = false;

                            if (_viewModel._selectedMode == mode)
                                _viewModel.ActiveTypeViewModels = null;
                        }
                        else
                        {
                            _modeViewModels[mode].IsEnabled = true; ;
                        }
                    }
                }
            }
        }
    }
}
