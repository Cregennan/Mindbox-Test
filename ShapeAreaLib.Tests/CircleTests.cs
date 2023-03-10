using ShapeAreaLib.Shapes;


namespace ShapeAreaLib.Tests
{
    [TestClass]
    public class CircleTests
    {

        [TestMethod("Test for circle area calculation")]
        public void CircleArea()
        {

            Random r = new Random();

            double[] radiuses = Enumerable.Repeat(0, 10).Select(x => r.NextDouble() * 1000).ToArray();


            double[] expectedAreas = radiuses.Select(x => Math.Pow(x, 2) * Math.PI).ToArray();

            double[] areas = radiuses.Select(x => new Circle(x).Area).ToArray();

            for(int i =0; i < expectedAreas.Length; i++)
            {

                Assert.AreEqual(expectedAreas[i], areas[i], Definitions.Delta);

            }
            
        }


        [TestMethod("Test for non-positive radius")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeRadius()
        {
            _ = new Circle(0);
        }


        [TestMethod("Test for too large radius")]
        [ExpectedException(typeof(OverflowException))]
        public void TooLargeCircle()
        {
            _ = new Circle(double.MaxValue).Area;
        }

    }
}
