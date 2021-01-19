using System;

namespace Paint.Shapes
{
    public class Rectangle : Shape
    {
        public bool Filled { get; }
        public int Width { get; }
        public int Height { get; }

        public Rectangle() : base()
        {

        }
        public Rectangle(int pictureSize, int depth, bool filled)
            : base(pictureSize, depth)
        {
            Filled = filled;
            Width = Math.Min(GetSide("width"), pictureSize);
            Height = Math.Min(GetSide("height"), pictureSize);
            for (int i = 0; i < Width; i++)
            {
                Picture[pictureSize - 1][i] = (char)(Depth + '0');
                Picture[pictureSize - Height][i] = (char)(Depth + '0');
            }

            for (int i = pictureSize - Height + 1; i < pictureSize - 1; i++)
            {
                Picture[i][0] = (char)(Depth + '0');
                Picture[i][Width-1] = (char)(Depth + '0');
                if (filled)
                {
                    for (int j = 1; j < Width-1; j++)
                    {
                        Picture[i][j] = (char)(Depth + '0');
                    }
                }

            }
        }
        private int GetSide(string type)
        {
            Console.Write($"Enter {type} of your rectangle: ");
            if (int.TryParse(Console.ReadLine(), out var size)
                && size >= 1) return size;
            return 1;
        }
    }
}