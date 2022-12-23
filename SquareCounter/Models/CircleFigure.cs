using System;
using System.Linq;
using SquareCounter.Properties;

namespace SquareCounter.Models
{
    internal class CircleFigure : IFigure
    {
        public CircleFigure(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; }

        public double GetSquare() => Math.PI * Math.Pow(Radius, 2) / 2;

        public static CircleFigure GetCircle(params double[] sizes)
        {
            if (sizes?.Any() != true)
                throw new ArgumentException(Resources.Figure_DataFormatException);

            var radius = sizes[0];
            if (radius <= 0)
                throw new ArgumentException(Resources.CircleFigure_RadiusValueException);

            return new CircleFigure(radius);
        }
    }
}
