using ShapeAreaLib.Shapes;

namespace ShapeAreaLib.Tests
{
    [TestClass]
    public class TriangleTests
    {

        [TestMethod]
        public void RightTriangleTest()
        {

            var triangle = new Triangle(3, 4, 5);

            Assert.IsTrue(triangle.IsRight, "Прямоугольный треугольник");

            var triangle2 = new Triangle(3, 4, 6);

            Assert.IsFalse(triangle2.IsRight, "Не прямоугольный треугольник");

        }

        [TestMethod]
        public void RightTriangleArea() {

            var triangles = new Triangle[]
            {
                new Triangle(3, 4, 5),
                new Triangle(20, 21, 29),
                new Triangle(8, 15, 17),
                new Triangle(7, 24, 25)
            };

            var areas = triangles.Select(x => x.Area).ToArray();

            var expectedAreas = new double[] {
            
                6, 110, 60, 84
            };

            CollectionAssert.AreEqual(expectedAreas, areas);

        }

        [TestMethod]
        public void AnyTriangleArea()
        {

            var triangles = new Triangle[]
            {
                new Triangle(2, 5, 6),
                new Triangle(10, 12, 17),
                new Triangle(9, 12, 8)
            };

            var areas = triangles.Select(x => x.Area).ToArray();

            var expectedAreas = new double[]
            {

            };

        }

        [TestMethod]
        public void Right() { }
        
        
    }
}