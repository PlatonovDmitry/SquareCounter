using SquareCounter.Enums;
using SquareCounterTests.Models;
using SquareCounter.Properties;

namespace SquareCounterTests
{
    [TestClass]
    public class SquareCounterTests
    {
        private readonly SquareCounter.SquareCounter _counter;
        private readonly CircleTestData[] _circleTestData;
        private readonly TriangleTestData[] _triangleTestData;

        public SquareCounterTests()
        {
            _counter = new SquareCounter.SquareCounter();
            _circleTestData = CircleTestData.GetTestData();
            _triangleTestData = TriangleTestData.GetTestData();
        }

        [TestMethod]
        public void TriangleSquareCount()
        {
            foreach (var curTriangle in _triangleTestData)
            {
                try
                {
                    var result = _counter.TriangleSquareCount(
                        curTriangle.Sides[0],
                        curTriangle.Sides[1],
                        curTriangle.Sides[2]);

                    Assert.AreEqual(result, curTriangle.Square, curTriangle.Square * 0.01);
                }
                catch (IndexOutOfRangeException)
                {
                    // ignore
                }
                catch (Exception e)
                {
                    Assert.IsInstanceOfType(e, curTriangle.ExceptionType);
                    StringAssert.Contains(e.Message, curTriangle.ErrorMessage);
                }
            }
        }

        [TestMethod]
        public void CircleSquareCount()
        {
            foreach (var curCircle in _circleTestData)
            {
                try
                {
                    var result = _counter.CircleSquareCount(curCircle.Radius[0]);
                    Assert.AreEqual(result, curCircle.Square, curCircle.Square * 0.01);
                }
                catch (IndexOutOfRangeException)
                {
                    // ignore
                }
                catch (Exception e)
                {
                    Assert.IsInstanceOfType(e, curCircle.ExceptionType);
                    StringAssert.Contains(e.Message, curCircle.ErrorMessage);
                }
            }
        }

        [TestMethod]
        public void FigureSquareCount()
        {
            foreach (var curTriangle in _triangleTestData)
            {
                try
                {
                    var result = _counter.FigureSquareCount(FigureType.Triangle, curTriangle.Sides);
                    Assert.AreEqual(result, curTriangle.Square, curTriangle.Square * 0.01);
                }
                catch (Exception e)
                {
                    Assert.IsInstanceOfType(e, curTriangle.ExceptionType);
                    StringAssert.Contains(e.Message, curTriangle.ErrorMessage);
                }
            }

            foreach (var curCircle in _circleTestData)
            {
                try
                {
                    var result = _counter.FigureSquareCount(FigureType.Circle, curCircle.Radius);
                    Assert.AreEqual(result, curCircle.Square, curCircle.Square * 0.01);
                }
                catch (Exception e)
                {
                    Assert.IsInstanceOfType(e, curCircle.ExceptionType);
                    StringAssert.Contains(e.Message, curCircle.ErrorMessage);
                }
            }

            try
            {
                var result = _counter.FigureSquareCount((FigureType)8, 8);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, Resources.FigureGenerator_WrongTypeException);
            }
        }

        [TestMethod]
        public void IsTriangleNormal1()
        {
            foreach (var curTriangle in _triangleTestData)
            {
                try
                {
                    var result = _counter.IsTriangleNormal(
                        curTriangle.Sides[0],
                        curTriangle.Sides[1],
                        curTriangle.Sides[2]);

                    Assert.AreEqual(result, curTriangle.IsNormal);
                }
                catch (IndexOutOfRangeException)
                {
                    // ignore
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