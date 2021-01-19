using System;

namespace Paint.Shapes
{
    public class Circle : Shape
    {
        public bool Filled { get; }
        public int Radius { get; }
        public Circle(int depth, bool filled)
            : base(depth)
        {
            Filled = filled;
            Radius = GetRadius();
        }
        private int GetRadius()
        {
            Console.Write("Enter radius of your circle: ");
            if (int.TryParse(Console.ReadLine(), out var r)
                && r >= 1) return r;
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