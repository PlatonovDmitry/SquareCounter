using SquareCounter.Enums;
using SquareCounter.Models;
using System;
using SquareCounter.Properties;

namespace SquareCounter.Services
{
    internal class FigureGenerator
    {
        public IFigure GenerateFigure(FigureType type, params double[] sizes)
        {
            switch (type)
            {
                case FigureType.Circle:
                    return CircleFigure.GetCircle(sizes);
                case FigureType.Triangle:
                    return TriangleFigure.GetTriangle(sizes);
                default:
                    throw new ArgumentException(Resources.FigureGenerator_WrongTypeException);
            }
        }
    }
}
