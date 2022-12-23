using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public static CircleFigure GetCircle(double[] sizes)
        {
            if (sizes?.Any() != true)
                throw new ArgumentException("Не верный формат входных параметров");

            var radius = sizes[0];
            if (radius <= 0)
                throw new ArgumentException("Радиус окружности не может быть отрицательным числом");

            return new CircleFigure(radius);
        }
    }
}
