using System;
using System.Linq;
using SquareCounter.Properties;

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
            return Math.Abs(squares.Take(2).Sum() - squares.Last()) < squares.Last() * 0.01;
        }


        public static TriangleFigure GetTriangle(params double[] edges)
        {
            var myEdges = edges?.Take(3).OrderBy(t => t).ToArray();
            if (myEdges?.Count() < 3)
                throw new ArgumentException(Resources.Figure_DataFormatException);

            if (myEdges.Any(t => t <= 0))
                throw new ArgumentException(Resources.TriangleFigure_LessZeroSideException);

            if (myEdges.Take(2).Sum() <= myEdges.Last())
                throw new ArgumentException(Resources.TriangleFigure_WonngSizesException);

            return new TriangleFigure(edges.Take(3).ToArray());
        }
    }
}
