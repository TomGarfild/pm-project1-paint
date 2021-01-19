using System;

namespace Paint.Shapes
{
    public class Rectangle : Shape
    {
        public bool Filled { get; }
        public int Width { get; }
        public int Height { get; }
        public Rectangle(int depth, bool filled)
            : base(depth)
        {
            Filled = filled;
            Width = GetSide("width");
            Height = GetSide("height");
        }
        private int GetSide(string type)
        {
            Console.Write($"Enter {type} of your rectangle: ");
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