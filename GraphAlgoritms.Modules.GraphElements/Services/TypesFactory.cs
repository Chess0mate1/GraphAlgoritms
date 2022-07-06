using GraphAlgoritms.Core.Extentions;
using GraphAlgoritms.Core.Types;
using GraphAlgoritms.Modules.Elements.ViewModels;

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GraphAlgoritms.Modules.Elements.Services
{
    public class TypesFactory
    {
        public Dictionary<ElementMode, ObservableCollection<TypeViewModel>> Create()
        {
            ObservableCollection<TypeViewModel> graphElementsCreation = new()
            {
                new()
                {
                    Type = ElementType.Node,
                    Name = "Узел",
                    ImagePath = @"..\Resources\Node.png",
                    IsEnabled = true
                },
                new()
                {
                    Type = ElementType.Edge,
                    Name = "Ребро",
                    ImagePath = @"..\Resources\Edge.png",
                    IsEnabled = false
                },
            };

            ObservableCollection<TypeViewModel> modificationElements = new()
            {
                new()
                {
                    Type = ElementType.Move,
                    Name = "Перемещение",
                    ImagePath = @"..\Resources\Move.png",
                    IsEnabled = false
                },
                new()
                {
                    Type = ElementType.Weight,
                    Name = "Вес",
                    ImagePath = @"..\Resources\Weight.png",
                    IsEnabled = false
                },
            };

            ObservableCollection<TypeViewModel> graphElementsRemoval = new()
            {
                new()
                {
                    Type = ElementType.Node,
                    Name = "Узел",
                    ImagePath = @"..\Resources\Node.png",
                    IsEnabled = false
                },
                new()
                {
                    Type = ElementType.Edge,
                    Name = "Ребро",
                    ImagePath = @"..\Resources\Edge.png",
                    IsEnabled = false
                },
            };

            ObservableCollection<TypeViewModel> algoritmExecute = new()
            {
                new()
                {
                    Type = ElementType.BreadthFirstSearch,
                    Name = "Поиск в ширину",
                    ImagePath = @"..\Resources\BreadthFirstSearch.png",
                    IsEnabled = true
                },
                new()
                {
                    Type = ElementType.DepthFirstSearch,
                    Name = "Поиск в глубину",
                    ImagePath = @"..\Resources\DepthFirstSearch.png",
                    IsEnabled = false
                },
                new()
                {
                    Type = ElementType.Dijkstra,
                    Name = "Алгоритм дейкстры",
                    ImagePath = @"..\Resources\Dijkstra.png",
                    IsEnabled = false
                },
                new()
                {
                    Type = ElementType.AStar,
                    Name = "А*",
                    ImagePath = @"..\Resources\AStar.png",
                    IsEnabled = false
                },
            };

            return new()
            {
                [ElementMode.Creation] = graphElementsCreation,
                [ElementMode.Modification] = modificationElements,
                [ElementMode.Removal] = graphElementsRemoval,
                [ElementMode.Algoritm] = algoritmExecute
            };
        }
    }
}
