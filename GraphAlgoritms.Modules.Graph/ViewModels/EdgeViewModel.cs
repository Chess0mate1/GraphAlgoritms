using GraphAlgoritms.Business;
using GraphAlgoritms.Core.CustomUIElements;

using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace GraphAlgoritms.Modules.Graph.ViewModels
{
    public enum WayToNode
    {
        None,
        First,
        Second,
    }

    public class EdgeViewModel : GraphElementViewModel
    {
        private Edge _edge;

        private WayToNode _wayTo;
        public WayToNode WayTo
        {
            get { return _wayTo; }
            set { SetProperty(ref _wayTo, value); }
        }


        private double _lineStartPositionX;
        public double LineStartPositionX
        {
            get { return _lineStartPositionX; }
            set 
            { 
                SetProperty(ref _lineStartPositionX, value); 
                UpdateWeightPosition(); 
            }
        }

        private double _lineStartPositionY;
        public double LineStartPositionY
        {
            get { return _lineStartPositionY; }
            set 
            { 
                SetProperty(ref _lineStartPositionY, value); 
                UpdateWeightPosition(); 
            }
        }


        private double _lineFinishPositionX;
        public double LineFinishPositionX
        {
            get { return _lineFinishPositionX; }
            set 
            { 
                SetProperty(ref _lineFinishPositionX, value); 
                UpdateWeightPosition(); 
            }
        }

        private double _lineFinishPositionY;
        public double LineFinishPositionY
        {
            get { return _lineFinishPositionY; }
            set 
            { 
                SetProperty(ref _lineFinishPositionY, value); 
                UpdateWeightPosition(); 
            }
        }


        private double _weight;
        public double Weight
        {
            get { return _weight; }
            set 
            { 
                SetProperty(ref _weight, value);
                _edge.Weight = value;
            }
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


        private NodeViewModel _firstNodeViewModel;
        public NodeViewModel FirstNodeViewModel 
        {
            get => _firstNodeViewModel;
            set
            {
                _firstNodeViewModel = value;

                _firstNodeViewModel.NodeChanged += Update;
                if (SecondNodeViewModel is not null)
                    Update();
            }
        }

        private NodeViewModel _secondNodeViewModel;
        public NodeViewModel SecondNodeViewModel
        {
            get => _secondNodeViewModel;
            set
            {
                _secondNodeViewModel = value;

                _secondNodeViewModel.NodeChanged += Update;
                if (FirstNodeViewModel is not null)
                    Update();
            }
        }



        public EdgeViewModel(int index)
            :base(index) 
        {
            _edge = new()
            {
                Id = index,
            };
        }


        public Edge GetEdge() => _edge; 

        private void Update()
        {
            double radious = NodeViewModel.Radious;

            double X1 = FirstNodeViewModel.NamePositionX + radious;
            double Y1 = FirstNodeViewModel.NamePositionY + radious;
            double X2 = SecondNodeViewModel.NamePositionX  + radious;
            double Y2 = SecondNodeViewModel.NamePositionY + radious;

            double legX = Math.Abs(X1 - X2);
            double legY = Math.Abs(Y1 - Y2);

            double hypotenuse = Math.Sqrt(legX * legX + legY * legY);
            double ratio = hypotenuse / radious;

            double distanceBetweenNodeCenterAndEdgeX = legX / ratio;
            double distanceBetweenNodeCenterAndEdgeY = legY / ratio;

            if (X1 < X2)
            {
                if (Y1 < Y2)
                {
                    LineStartPositionX = X1 + distanceBetweenNodeCenterAndEdgeX;
                    LineStartPositionY = Y1 + distanceBetweenNodeCenterAndEdgeY;
                    LineFinishPositionX = X2 - distanceBetweenNodeCenterAndEdgeX;
                    LineFinishPositionY = Y2 - distanceBetweenNodeCenterAndEdgeY;
                }
                else if (Y1 > Y2)
                {
                    LineStartPositionX = X1 + distanceBetweenNodeCenterAndEdgeX;
                    LineStartPositionY = Y1 - distanceBetweenNodeCenterAndEdgeY;
                    LineFinishPositionX = X2 - distanceBetweenNodeCenterAndEdgeX;
                    LineFinishPositionY = Y2 + distanceBetweenNodeCenterAndEdgeY;
                }
            }
            else if (X1 > X2)
            {
                if (Y1 < Y2)
                {
                    LineStartPositionX = X1 - distanceBetweenNodeCenterAndEdgeX;
                    LineStartPositionY = Y1 + distanceBetweenNodeCenterAndEdgeY;
                    LineFinishPositionX = X2 + distanceBetweenNodeCenterAndEdgeX;
                    LineFinishPositionY = Y2 - distanceBetweenNodeCenterAndEdgeY;
                }
                else if (Y1 > Y2)
                {
                    LineStartPositionX = X1 - distanceBetweenNodeCenterAndEdgeX;
                    LineStartPositionY = Y1 - distanceBetweenNodeCenterAndEdgeY;
                    LineFinishPositionX = X2 + distanceBetweenNodeCenterAndEdgeX;
                    LineFinishPositionY = Y2 + distanceBetweenNodeCenterAndEdgeY;
                }
            }
        }


        private void UpdateWeightPosition()
        {
            WeightPositionX = (LineStartPositionX + LineFinishPositionX) / 2 - NodeViewModel.Radious;
            WeightPositionY = (LineStartPositionY + LineFinishPositionY) / 2 - NodeViewModel.Radious;
        }
    }
}
