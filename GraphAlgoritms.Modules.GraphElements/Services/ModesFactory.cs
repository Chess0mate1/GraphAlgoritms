using GraphAlgoritms.Core.Types;
using GraphAlgoritms.Modules.Elements.ViewModels;

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GraphAlgoritms.Modules.Elements.Services
{
    public class ModesFactory
    {
        public ObservableCollection<ModeViewModel> Create()
        {
            return new()
            {
                new()
                {
                    Mode = ElementMode.Creation,
                    Name = "Создание",
                    IsEnabled = true
                },
                new()
                {
                    Mode = ElementMode.Modification,
                    Name = "Изменение",
                    IsEnabled = false
                },
                new()
                {
                    Mode = ElementMode.Removal,
                    Name = "Удаление",
                    IsEnabled = false
                },
                new()
                {
                    Mode = ElementMode.Algoritm,
                    Name = "Алгоритм",
                    IsEnabled = false
                }
            };
        }
    }
}
