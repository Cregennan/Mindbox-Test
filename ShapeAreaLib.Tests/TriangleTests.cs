using ShapeAreaLib.Shapes;


namespace ShapeAreaLib.Tests
{
    [TestClass]
    public class TriangleTests
    {

        [TestMethod("����������� ���������������")]
        public void RightTriangleTest()
        {

            var triangle = new Triangle(3, 4, 5);

            Assert.IsTrue(triangle.IsRight, "������������� �����������");

            var triangle2 = new Triangle(3, 4, 6);

            Assert.IsFalse(triangle2.IsRight, "�� ������������� �����������");

        }

        [TestMethod("���������� ������� �������������� ������������")]
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
            
                6, 210, 60, 84
            };

            for(int i = 0; i < areas.Length; i++)
            {

                Assert.AreEqual(expectedAreas[i], areas[i]);

            }
            //CollectionAssert.AreEqual(expectedAreas, areas);

        }

        [TestMethod("���������� ������� ������������")]
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
                0.75 * Math.Sqrt(39),
                0.25d * 15d * Math.Sqrt(247),
                0.25 * Math.Sqrt(20735)
            };

            for(int i = 0; i < expectedAreas.Length; i++)
            {

                Assert.AreEqual(expectedAreas[i], areas[i], Definitions.Delta);

            }

        }

        [TestMethod("��������� ������� ������� �������������")]
        [ExpectedException(typeof(OverflowException), "�������� ��������� ������� ������� ������")]
        public void TooLargeTriangle()
        {

            _ = new Triangle(double.MaxValue, double.MaxValue - 1, double.MaxValue - 1)
                    .Area;

        }

        [TestMethod("��������� ������ �� �������������� �������")]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "�������� ��������� ������� ��������� ������")]
        public void NonPositiveSides()
        {

            _ = new Triangle(0, 0, 0);

        }

        [TestMethod("��������� ��������� ������� ������������")]
        [ExpectedException(typeof(ArgumentException), "�������� ��������� ��������� ������� ������������")]
        public void TriangleRuleViolation()
        {

            _ = new Triangle(7, 3, 3);

        }
        
        
    }
}