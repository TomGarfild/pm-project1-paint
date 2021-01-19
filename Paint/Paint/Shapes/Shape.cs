using System;
using System.Collections.Generic;

namespace Paint.Shapes
{
    public abstract class Shape
    {
        public int Depth { get; }
        public List<string> Picture { get; }
        protected Shape(int depth)
        {
            Depth = depth;
        }
        protected abstract int CalculateSquare();
        protected abstract int CalculatePerimeter();
        protected int GetShapeKind(string[] types, string shapeName)
        {
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {types[i]}");
            }
            Console.Write($"Enter number of the type of your {shapeName}: ");
            if (int.TryParse(Console.ReadLine(), out var key)
                && key >= 1 && key <= types.Length) return key;
            return 1;
        }
    }
}