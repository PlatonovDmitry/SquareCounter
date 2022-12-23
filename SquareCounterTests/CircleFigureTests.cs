using SquareCounter.Models;
using SquareCounterTests.Constants;
using SquareCounterTests.Models;

namespace SquareCounterTests
{
    [TestClass]
    public class CircleFigureTests
    {
        private readonly CircleTestData[] _testData;


        public CircleFigureTests()
        {
            _testData = CircleTestData.GetTestData();
        }

        [TestMethod]
        public void GetCircle1()
        {
            foreach (var curCircle in _testData)
            {
                try
                {
                    var circle = CircleFigure.GetCircle(curCircle.Radius);
                    var square = circle.GetSquare();
                    Assert.AreEqual(circle.Radius, curCircle.Radius[0]);
                    Assert.AreEqual(square, curCircle.Square, curCircle.Square * Const.SQUARE_TOLERANCE);
                }
                catch (Exception e)
                {
                    Assert.IsInstanceOfType(e, curCircle.ExceptionType);
                    StringAssert.Contains(e.Message, curCircle.ErrorMessage);
                }
            }
        }
    }
}
