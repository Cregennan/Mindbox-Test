using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaLib.Shapes
{
    public class Circle : Shape
    {

        #region Properties
        /// <summary>
        /// Radius of a circle
        /// </summary>
        public double Radius { get; private set; }

        #endregion

        /// <summary>
        /// Creates Circle
        /// </summary>
        /// <param name="radius">Radius of the Circle. Positive number</param>
        /// <exception cref="ArgumentOutOfRangeException">Is thrown when radius is not positive</exception>
        public Circle (double radius)
        {
            if (radius <= 0) throw new ArgumentOutOfRangeException(nameof(radius), "Positive number required");

            Radius = radius;

        }

        /// <summary>
        /// Calculates area of a circle
        /// </summary>
        /// <returns></returns>
        protected override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

    }
}
