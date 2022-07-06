using GraphAlgoritms.Business;

using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphAlgoritms.Modules.Graph.ViewModels
{
    public class NodeViewModel : GraphElementViewModel
    {
        private Node _node;

        public Node GetNode() => _node;

        public static double Diameter { get; }
        public static double Radious { get; }


        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }


        private double _namePositionX;
        public double NamePositionX
        {
            get { return _namePositionX; }
            set 
            { 
                SetProperty(ref _namePositionX, value);

                UpdateWeightPositionX();
                NodeChanged?.Invoke();
            }
        }

        private double _NamePositionY;
        public double NamePositionY
        {
            get { return _NamePositionY; }
            set 
            { 
                SetProperty(ref _NamePositionY, value);

                UpdateWeightPositionY();
                NodeChanged?.Invoke();
            }
        }


        private double _weight;
        public double Weight
        {
            get { return _weight; }
            set { SetProperty(ref _weight, value); }
        }


        private double _weightPositionX;
        public double WeightPositionX
        {
            get { return _weightPositionX; }
            set { SetProperty(ref _weightPositionX, value); }
        }

        private double _weightPositionY;
        public double WeightPositionY
        {
            get { return _weightPositionY; }
            set { SetProperty(ref _weightPositionY, value); }
        }



        public event Action NodeChanged;

        public List<EdgeViewModel> EdgeViewModels { get; }



        static NodeViewModel()
        {
            Radious = 20;
            Diameter = Radious * 2;
        }
        public NodeViewModel(int index)
            : base(index)
        {
            _node = new()
            {
                Id = index,
            };

            EdgeViewModels = new();
        }



        private void UpdateWeightPositionX()
        {
            WeightPositionX = NamePositionX /*- FindOptimalPlace()*/;

            double FindOptimalPlace()
            {
                int weightSize = _weight.ToString().Length;

                return (weightSize - 2) / 2 * 17;
            }
        }
        private void UpdateWeightPositionY()
        {
            WeightPositionY = NamePositionY - 38;
        }
    }
}
