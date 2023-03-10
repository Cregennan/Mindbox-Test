using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaLib.Shapes
{
    public class Triangle : Shape
    {
        #region Properties

        /// <summary>
        /// First side of triangle
        /// </summary>
        public double First { get; private set; }

        /// <summary>
        /// Second side of triangle
        /// </summary>
        public double Second { get; private set; }

        /// <summary>
        /// Third side of triangle
        /// </summary>
        public double Third { get; private set; }

        /// <summary>
        /// True if triangle is right angled
        /// </summary>
        protected readonly Lazy<bool> _isRight;

        public bool IsRight => _isRight.Value;
        
        #endregion

        /// <summary>
        /// Triangle. Three sides required
        /// </summary>
        /// <param name="one">First side</param>
        /// <param name="two">Second side</param>
        /// <param name="three">Third side</param>
        /// <exception cref="ArgumentOutOfRangeException">Is thrown when any of sides is not positive</exception>
        /// <exception cref="ArgumentException">Is thrown if triangle sides rule is violated</exception>
        public Triangle(double one, double two, double three)
        {

            if (one <= 0 || two <= 0 || three <= 0)
            {
                throw new ArgumentOutOfRangeException(null, "Any side of a triangle must be positive");
            }


            var errors = new double[] { one + two - three, one + three - two, two + three - one };
            if (errors.Where(x => Math.Abs(x) > _defaultDelta).Any())
            {
                throw new ArgumentException(null, "The sum of lengths of any two sides should be greater than the length of third side");
            }

            First = one;
            Second = two;
            Third = three;

            _isRight = new Lazy<bool>(IsRightTriangle);
        }

        /// <summary>
        /// Checks if this triangle is right angled
        /// </summary>
        /// <returns>True if triangle is right angled</returns>
        protected bool IsRightTriangle()
        {
            var maxSide = double.Max(double.Max(this.First, this.Second), this.Third);

            var error = 2 * maxSide * maxSide - First * First + Second * Second + Third * Third;

            return Math.Abs(error) < _defaultDelta;

        }


        /// <summary>
        /// Calculates area of a triangle
        /// </summary>
        /// <returns>Area of a triangle</returns>
        protected override double CalculateArea()
        {
            
            //Area is calculated with Heron's formula

            var semi = (First + Second + Third) / 2;

            return Math.Sqrt(semi * (semi - First) * (semi-Second) * (semi-Third));

        }
    }
}
