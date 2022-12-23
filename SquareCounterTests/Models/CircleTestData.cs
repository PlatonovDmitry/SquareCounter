using SquareCounter.Properties;

namespace SquareCounterTests.Models
{
    internal class CircleTestData
    {
        public double[] Radius { get; set; }
        public double Square { get; set; }
        public Type ExceptionType { get; set; }
        public string ErrorMessage { get; set; }

        public static CircleTestData[] GetTestData()
        {
            return new[]
            {
                new CircleTestData()
                {
                    Radius = Array.Empty<double>(),
                    ExceptionType = typeof(ArgumentException),
                    ErrorMessage = Resources.Figure_DataFormatException
                },
                new CircleTestData()
                {
                    Radius = new double[] {-1},
                    ExceptionType = typeof(ArgumentException),
                    ErrorMessage = Resources.CircleFigure_RadiusValueException
                },
                new CircleTestData()
                {
                    Radius = new double[] {0},
                    ExceptionType = typeof(ArgumentException),
                    ErrorMessage = Resources.CircleFigure_RadiusValueException
                },
                new CircleTestData()
                {
                    Radius = new double[] {1},
                    Square = Math.PI / 2,
                },
                new CircleTestData()
                {
                    Radius = new[] {4.5},
                    Square = 31.7925,
                },
            };
        }
    }
}
