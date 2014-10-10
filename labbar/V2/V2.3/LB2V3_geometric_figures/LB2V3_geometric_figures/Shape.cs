using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2V3_geometric_figures
{

    enum ShapeType { Ellips, Rektangel };

    abstract class Shape : IComparable
    {
        private double _length;
        private double _width;

        protected Shape(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public abstract double Area
        {
            get;
        }

        public double Length
        {
            get
            {
                return _length;
            }

            set
            {
                if (value > 0)
                {
                    _length = value;
                }
                else
                {
                    throw new ArgumentException("Längden måste vara större än 0");
                }
            }
        }

        public abstract double Perimeter
        {
            get;
        }

        public double Width
        {
            get
            {
                return _width;
            }

            set
            {
                if (value > 0)
                {
                    _width = value;
                }
                else
                {
                    throw new ArgumentException("Bredden måste vara större än 0");
                }
            }
        }
        //Överlagring av ToString-metoden som returnerar en formaterad sträng värden.
        public string ToString()
        {
            return String.Format("{0, -10}{1, 10:n1}{2, 10:n1}{3, 10:n1}{4, 10:n1}", this.GetType().Name, Length, Width, Math.Round(Perimeter, 1), Math.Round(Area, 1));
        }
        //Metoden jämför ett Shape area-värde med ett annat. Om det som ska jämföras med är null eller större än det aktuella värdet returneras 1.
        //Om det aktuella värdet är större än det som ska jämföras med returneras -1. Om värderna är lika med varandra returneras 0.
        public int CompareTo(object obj)
        {
            Shape otherShape = obj as Shape;

            if (obj == null)
            {
                return 1;
            }
            else if (this.Area > otherShape.Area)
            {
                return -1;
            }
            else if (this.Area < otherShape.Area)
            {
                return 1;
            }
            else if (this.Area == otherShape.Area)
            {
                return 0;
            }
            else
                throw new ArgumentException("Fel typ av objekt");
        }
    }
}
