using SquareCounter.Enums;
using SquareCounter.Models;
using SquareCounter.Services;
using SquareCounterTests.Models;
using SquareCounter.Properties;
using SquareCounterTests.Constants;

namespace SquareCounterTests
{
    [TestClass]
    public class FigureGeneratorTests
    {
        private readonly FigureGenerator _figureGenerator;
        private readonly CircleTestData[] _circleTestData;
        private readonly TriangleTestData[] _triangleTestData;

        public FigureGeneratorTests()
        {
            _figureGenerator = new FigureGenerator();
            _circleTestData = CircleTestData.GetTestData();
            _triangleTestData = TriangleTestData.GetTestData();
        }

        [TestMethod]
        public void GenerateCircle()
        {
            foreach (var curCircle in _circleTestData)
            {
                try
                {
                    var circleFigure = _figureGenerator.GenerateFigure(FigureType.Circle, curCircle.Radius);
                    Assert.IsInstanceOfType(circleFigure, typeof(CircleFigure));

                    var circle = (CircleFigure)circleFigure;
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

        [TestMethod]
        public void GenerateTriangle()
        {
            foreach (var curTriangle in _triangleTestData)
            {
                try
                {
                    var triangleFigure = _figureGenerator.GenerateFigure(FigureType.Triangle, curTriangle.Sides);
                    Assert.IsInstanceOfType(triangleFigure, typeof(TriangleFigure));

                    var triangle = (TriangleFigure)triangleFigure;
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

        [TestMethod]
        public void GenerateFigure()
        {
            try
            {
                var _ = _figureGenerator.GenerateFigure((FigureType)8, 2, 4, 3);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, Resources.FigureGenerator_WrongTypeException);
            }
        }
    }
}
