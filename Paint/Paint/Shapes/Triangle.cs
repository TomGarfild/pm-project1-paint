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
            Side = Math.Min(GetSide(), pictureSize/2);
            Color = GetColor();
            ChangePicture();
            switch (Type)
            {
                case 1:
                    Perimeter = Side * (2 + Math.Sqrt(2));
                    if (Filled) Square = Side * Side / 2d;
                    else Square = 0;
                    break;
                case 2:
                    Perimeter = Side * (2 + 2 * Math.Sqrt(2));
                    if (Filled) Square = Side * Side;
                    else Square = 0;
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
        public override void ChangePicture()
        {
            Reset();
            
            Y = Math.Min(Math.Max(0, Y), PictureSize - Side);
            switch (Type)
            {
                case 1:
                    X = Math.Min(Math.Max(0, X), PictureSize - Side);
                    for (int i = PictureSize - Side; i < PictureSize; i++)
                    {
                        Picture[i-Y][X] = (char)('0' + Depth);
                        Picture[i - Y][i - PictureSize + Side+X] = (char)('0' + Depth);
                        if (Filled || i == PictureSize - 1)
                        {
                            for (int j = 1; j < i - PictureSize + Side; j++)
                            {
                                Picture[i-Y][j+X] = (char)('0' + Depth);
                            }
                        }
                    }
                    break;
                case 2:
                    X = Math.Min(Math.Max(0, X), PictureSize - 2*Side);
                    for (int i = PictureSize - Side; i < PictureSize; i++)
                    {
                        Picture[i-Y][PictureSize - i - 1+X] = (char)('0' + Depth);
                        Picture[i-Y][i - PictureSize + 2*Side+X] = (char)('0' + Depth);
                        if (Filled || i == PictureSize - 1)
                        {
                            for (int j = PictureSize - i; j < i - PictureSize + 2*Side; j++)
                            {
                                Picture[i-Y][j+X] = (char)('0' + Depth);
                            }
                        }
                    }
                    break;
            }
        }
    }
}