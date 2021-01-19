using System;

namespace Paint.Shapes
{
    public class Line : Shape
    {
        public int Length { get; }
        public int Type { get; }
        public Line(int pictureSize, int depth)
            : base(pictureSize, depth)
        {
            Type = GetShapeKind(new string[] { "Vertical", "Horizontal", "Diagonal" }, "line");
            Length = GetLength();
        }
        private int GetLength()
        {
            Console.Write("Enter length of the line: ");
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