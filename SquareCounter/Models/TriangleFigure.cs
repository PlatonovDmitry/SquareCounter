using System;
using System.Linq;

namespace SquareCounter.Models
{
    internal class TriangleFigure : IFigure
    {
        private double[] _edges;

        public TriangleFigure(double[] edges)
        {
            _edges = edges;
        }

        public double A => _edges[0];

        public double B => _edges[1];

        public double C => _edges[2];


        public double GetSquare()
        {
            var p = _edges.Sum() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public bool IsNormal()
        {
            var squares = _edges.OrderBy(t => t).Select(t => Math.Pow(t, 2)).ToArray();
            return squares.Take(2).Sum().Equals(squares.Last());
        }


        public static TriangleFigure GetTriangle(double[] edges)
        {
            var myEdges = edges?.Take(3).OrderBy(t => t).ToArray();
            if (myEdges?.Count() < 3)
                throw new ArgumentException("Не верный формат входных данных");

            if (myEdges.Any(t => t <= 0))
                throw new ArgumentException("Ни одна сторона треугольника не должна быть меньше нуля");

            if (myEdges.Take(2).Sum() <= myEdges.Last())
                throw new ArgumentException("Не возможно построить треугольник с таки м набором сторон");

            return new TriangleFigure(edges.Take(3).ToArray());
        }
    }
}
