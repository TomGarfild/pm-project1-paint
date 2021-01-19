using System;

namespace Paint.Shapes
{
    public class Triangle : Shape
    {
        public bool Filled { get; }
        public int Type { get; }
        public int Side { get; }

        public Triangle() : base()
        {

        }
        public Triangle(int pictureSize, int depth, bool filled)
            : base(pictureSize, depth)
        {
            Filled = filled;
            Type = GetShapeKind(new string[] {"Right triangle", "Isosceles triangle"}, "triangle");
            Side = Math.Min(GetSide(), pictureSize);
            switch (Type)
            {
                case 1:
                    for (int i = pictureSize - Side; i < pictureSize; i++)
                    {
                        Picture[i][0] = (char)('0' + Depth);
                        Picture[i][i-pictureSize+Side] = (char)('0' + Depth);
                        if (filled || i == pictureSize - 1)
                        {
                            for (int j = 1; j < i - pictureSize + Side; j++)
                            {
                                Picture[i][j] = (char)('0' + Depth);
                            }
                        }
                    }
                    break;
                case 2:
                    for (int i = pictureSize - Side; i < pictureSize; i++)
                    {
                        Picture[i][pictureSize-i-1] = (char)('0' + Depth);
                        Picture[i][i - pictureSize + 2*Side] = (char)('0' + Depth);
                        if (filled || i == pictureSize - 1)
                        {
                            for (int j = pictureSize-i; j < i - pictureSize + 2 * Side; j++)
                            {
                                Picture[i][j] = (char)('0' + Depth);
                            }
                        }
                    }
                    break;
            }
        }

        private int GetSide()
        {
            Console.Write("Enter length of the base side of your triangle: ");
            if (int.TryParse(Console.ReadLine(), out var size)
                && size >= 1) return size;
            return 1;
        }
    }
}