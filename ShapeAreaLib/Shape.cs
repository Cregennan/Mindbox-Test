using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaLib
{
    public abstract class Shape
    {

        /// <summary>
        /// Calculates area of a shape
        /// </summary>
        /// <returns></returns>
        protected abstract double CalculateArea();

        /// <summary>
        /// Area of the shape. If called first time, area will be calculated.
        /// </summary>
        protected readonly Lazy<double> _area;

        /// <summary>
        /// Area of the shape
        /// </summary>
        /// <exception cref="OverflowException">Throw when area of shape is too large to be fit in double</exception>
        public double Area { 
            get { 
                
                if (_area.Value <= 0 || double.IsInfinity(_area.Value))
                {
                    throw new OverflowException("Area of the shape is too large");
                }
                return _area.Value;
            } 
        }


        protected Shape() {
        
            _area= new Lazy<double>(CalculateArea);

        }

    }
}
