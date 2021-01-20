using System;
using System.Dynamic;

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
            Width = Math.Min(GetSide("width"), PictureSize);
            Height = Math.Min(GetSide("height"), PictureSize);
            Color = GetColor();

            ChangePicture();

            Perimeter = 2 * Height + 2 * Width;
            if (Filled) Square = Height * Width;
            else Square = 0;
        }
        private int GetSide(string type)
        {
            Console.Write($"Enter {type} of your rectangle: ");
            if (int.TryParse(Console.ReadLine(), out var size)
                && size >= 1) return size;
            return 1;
        }

        public override void ChangePicture()
        {
            Reset();
            X = Math.Min(Math.Max(0, X), 2*PictureSize-Width);
            Y = Math.Min(Math.Max(0, Y), PictureSize - Height);
            for (int i = 0; i < Width; i++)
            {
                Picture[PictureSize - 1 - Y][i + X] = (char)(Depth + '0');
                Picture[PictureSize - Height - Y][i + X] = (char)(Depth + '0');
            }

            for (int i = PictureSize - Height + 1; i < PictureSize - 1; i++)
            {
                Picture[i-Y][X] = (char)(Depth + '0');
                Picture[i-Y][Width - 1+X] = (char)(Depth + '0');
                if (Filled)
                {
                    for (int j = 1; j < Width - 1; j++)
                    {
                        Picture[i-Y][j+X] = (char)(Depth + '0');
                    }
                }

            }
        }
    }
}