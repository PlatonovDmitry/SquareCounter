using SquareCounter.Models;
using SquareCounterTests.Constants;
using SquareCounterTests.Models;

namespace SquareCounterTests
{
    [TestClass]
    public class TriangleFigureTests
    {
        private readonly TriangleTestData[] _testData;

        public TriangleFigureTests()
        {
            _testData = TriangleTestData.GetTestData();
        }

        [TestMethod]
        public void GetTriangle()
        {
            foreach (var curTriangle in _testData)
            {
                try
                {
                    var triangle = TriangleFigure.GetTriangle(curTriangle.Sides);
                    var square = triangle.GetSquare();
                    Assert.AreEqual(triangle.A, curTriangle.Sides[0]);
                    Assert.AreEqual(triangle.B, curTriangle.Sides[1]);
                    Assert.AreEqual(triangle.C, curTriangle.Sides[2]);
                    Assert.AreEqual(square, curTriangle.Square, curTriangle.Square * Const.SQUARE_TOLERANCE);

                    var isNormal = triangle.IsNormal();
                    Assert.AreEqual(isNormal, curTriangle.IsNormal);
                }
                catch (Exception e)
                {
                    Assert.IsInstanceOfType(e, curTriangle.ExceptionType);
                    StringAssert.Contains(e.Message, curTriangle.ErrorMessage);
                }
            }
        }
    }
}
