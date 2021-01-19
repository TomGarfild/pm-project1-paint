using System;

namespace Paint.Shapes
{
    public class Triangle : Shape
    {
        public bool Filled { get; }
        public int Type { get; }
        public int Side { get; }
        public Triangle(int depth, bool filled)
            : base(depth)
        {
            Filled = filled;
            Type = GetTriangleType(new string[] {"Right triangle", "Isosceles triangle"});
            Side = GetSide();
        }

        private int GetTriangleType(string[] types)
        {
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {types[i]}");
            }
            Console.Write("Enter number of the type of your triangle: ");
            if (int.TryParse(Console.ReadLine(), out var key)
                && key >= 1 && key <= types.Length) return key;
            return 1;
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