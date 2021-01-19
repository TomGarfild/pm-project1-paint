using System;
using System.Security.Cryptography;

namespace Paint.Shapes
{
    public class Circle : Shape
    {
        public bool Filled { get; }
        public int Diameter { get; }

        public Circle() : base()
        {

        }
        public Circle(int pictureSize, int depth, bool filled)
            : base(pictureSize, depth)
        {
            Filled = filled;
            Diameter = Math.Min(GetDiameter()+2, pictureSize);
            for (int i = 1; i < 2*Diameter-1; i++)
            {
                Picture[pictureSize - 1][i] = (char) (Depth + '0');
                Picture[pictureSize - Diameter][i] = (char) (Depth + '0');
            }

            for (int i = pictureSize - Diameter + 1; i < pictureSize - 1; i++)
            {
                Picture[i][0] = (char) (Depth + '0');
                Picture[i][2*Diameter - 1] = (char) (Depth + '0');
                if (filled)
                {
                    for (int j = 1; j < 2*Diameter; j++)
                    {
                        Picture[i][j] = (char) (Depth + '0');
                    }
                }
                
            }

        }
        private int GetDiameter()
        {
            Console.Write("Enter diameter of your circle: ");
            if (int.TryParse(Console.ReadLine(), out var d)
                && d >= 1) return d;
            return 1;
        }
    }
}