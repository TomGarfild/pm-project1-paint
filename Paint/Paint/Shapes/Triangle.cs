using System;

namespace Paint.Shapes
{
    public class Triangle : Shape
    {
        public bool Filled { get; }
        public int Type { get; }
        public int Side { get; }
        public Triangle(int pictureSize, int depth, bool filled)
            : base(pictureSize, depth)
        {
            Filled = filled;
            Type = GetShapeKind(new string[] {"Right triangle", "Isosceles triangle"}, "triangle");
            Side = GetSide();
        }

        private int GetSide()
        {
            Console.Write("Enter length of the base side of your triangle: ");
            if (int.TryParse(Console.ReadLine(), out var size)
                && size >= 1) return size;
            return 1;
        }
        protected override int CalculateSquare()
        {
            throw new System.NotImplementedException();
        }

        protected override int CalculatePerimeter()
        {
            throw new System.NotImplementedException();
        }
    }
}