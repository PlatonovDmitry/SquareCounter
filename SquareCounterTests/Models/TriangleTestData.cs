using SquareCounter.Properties;

namespace SquareCounterTests.Models
{
    internal class TriangleTestData
    {
        public double[] Sides { get; set; }
        public double Square { get; set; }
        public Type ExceptionType { get; set; }
        public string ErrorMessage { get; set; }
        public bool? IsNormal { get; set; }

        public static TriangleTestData[] GetTestData()
        {
            return new[]
            {
                new TriangleTestData()
                {
                    Sides = Array.Empty<double>(),
                    ExceptionType = typeof(ArgumentException),
                    ErrorMessage = Resources.Figure_DataFormatException
                },
                new TriangleTestData()
                {
                    Sides = new double[]{ 0 },
                    ExceptionType = typeof(ArgumentException),
                    ErrorMessage = Resources.Figure_DataFormatException
                },
                new TriangleTestData()
                {
                    Sides = new double[]{ 4, 5 },
                    ExceptionType = typeof(ArgumentException),
                    ErrorMessage = Resources.Figure_DataFormatException
                },
                new TriangleTestData()
                {
                    Sides = new double[]{ 4, 5, 0 },
                    ExceptionType = typeof(ArgumentException),
                    ErrorMessage = Resources.TriangleFigure_LessZeroSideException
                },
                new TriangleTestData()
                {
                    Sides = new double[]{ 3, 5, 1 },
                    ExceptionType = typeof(ArgumentException),
                    ErrorMessage = Resources.TriangleFigure_WonngSizesException
                },
                new TriangleTestData()
                {
                    Sides = new double[]{ -4, -5, -3 },
                    ExceptionType = typeof(ArgumentException),
                    ErrorMessage = Resources.TriangleFigure_LessZeroSideException
                },
                new TriangleTestData()
                {
                    Sides = new double[]{ 4, 5, 3 },
                    Square = 6,
                    IsNormal = true
                },
                new TriangleTestData()
                {
                    Sides = new double[]{ 4, 5, 2 },
                    Square = 3.8,
                    IsNormal = false
                },
            };
        }
    }
}
