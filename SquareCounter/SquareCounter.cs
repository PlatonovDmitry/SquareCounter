using System.Runtime.CompilerServices;
using SquareCounter.Enums;
using SquareCounter.Models;
using SquareCounter.Services;

[assembly: InternalsVisibleTo("SquareCounterTests")]
namespace SquareCounter
{
    public class SquareCounter
    {
        private readonly FigureGenerator _figureGenerator;

        public SquareCounter()
        {
            _figureGenerator = new FigureGenerator();
        }

        /// <summary>
        /// Вычисляет площадь фигуры по её геометрическим размерам
        /// </summary>
        /// <param name="type">Тип фигуры</param>
        /// <param name="sizes">Размеры. </param>
        /// <returns></returns>
        public double FigureSquareCount(FigureType type, params double[] sizes)
        {
            var figure = _figureGenerator.GenerateFigure(type, sizes);
            return figure.GetSquare();
        }

        /// <summary>
        /// Вычисляет площадь треугольника по трём сторонам
        /// </summary>
        /// <param name="a">Длина стороны 1</param>
        /// <param name="b">Длина стороны 2</param>
        /// <param name="c">Длина стороны 3</param>
        /// <returns></returns>
        public double TriangleSquareCount(double a, double b, double c) => FigureSquareCount(FigureType.Triangle, a, b, c);

        /// <summary>
        /// Вычисляет площадь окружности по её радиусу
        /// </summary>
        /// <param name="radius">Радиус окружности</param>
        /// <returns></returns>
        public double CircleSquareCount(double radius) => FigureSquareCount(FigureType.Circle, radius);

        /// <summary>
        /// Определяет, является ли треугольник прямоугольным
        /// </summary>
        /// <param name="a">Длина стороны 1</param>
        /// <param name="b">Длина стороны 2</param>
        /// <param name="c">Длина стороны 3</param>
        /// <returns></returns>
        public bool IsTriangleNormal(double a, double b, double c)
        {
            var figure = _figureGenerator.GenerateFigure(FigureType.Triangle, a, b, c);
            return ((TriangleFigure)figure).IsNormal();
        }

    }
}
