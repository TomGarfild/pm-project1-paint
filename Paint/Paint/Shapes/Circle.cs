using System;
using System.Security.Cryptography;
using System.Threading;

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
            Diameter = Math.Min(GetDiameter()+2, pictureSize)-2;
            Color = GetColor();
            ChangePicture();
            Perimeter = Math.PI * Diameter;
            if (Filled) Square = Math.PI * Diameter * Diameter / 4;
            else Square = 0;

        }
        private int GetDiameter()
        {
            Console.Write("Enter diameter of your circle: ");
            if (int.TryParse(Console.ReadLine(), out var d)
                && d >= 1) return d;
            return 1;
        }
        public override void ChangePicture()
        {
            Reset();
            X = Math.Min(Math.Max(0, X), PictureSize - Diameter);
            Y = Math.Min(Math.Max(0, Y), PictureSize - Diameter);
            if (Diameter == 1)
            {
                Picture[PictureSize - 1-Y][X] = (char)(Depth + '0');
            }
            else if (Diameter == 2)
            {
                Picture[PictureSize - 1-Y][X] = (char)(Depth + '0');
                Picture[PictureSize - 1-Y][X+1] = (char)(Depth + '0');
                Picture[PictureSize - 2-Y][X] = (char)(Depth + '0');
                Picture[PictureSize - 2-Y][X+1] = (char)(Depth + '0');
            }
            else
            {
                for (int i = 1; i < Diameter - 1; i++)
                {
                    Picture[PictureSize - 1-Y][X+i] = (char)(Depth + '0');
                    Picture[PictureSize - Diameter-Y][X+i] = (char)(Depth + '0');
                }
                //To Save proportion multiply by 2
                for (int i = PictureSize - Diameter + 1; i < PictureSize - 1; i++)
                {
                    Picture[i-Y][X] = (char)(Depth + '0');
                    Picture[i-Y][Diameter - 1 + X] = (char)(Depth + '0');
                    if (Filled)
                    {
                        for (int j = 1; j < Diameter; j++)
                        {
                            Picture[i-Y][j+X] = (char)(Depth + '0');
                        }
                    }
                }
            }
        }

    }
}