using System;

namespace Paint.Shapes
{
    public class Line : Shape
    {
        public int Length { get; }
        public int Type { get; }

        public Line() : base()
        {

        }
        public Line(int pictureSize, int depth)
            : base(pictureSize, depth)
        {
            Type = GetShapeKind(new string[] { "Vertical", "Horizontal", "Diagonal" }, "line");
            Length = Math.Min(GetLength(), pictureSize);
            Color = GetColor();
            ChangePicture();

            Perimeter = Length;
            Square = Length;
        }
        private int GetLength()
        {
            Console.Write("Enter length of the line: ");
            if (int.TryParse(Console.ReadLine(), out var size)
                && size >= 1) return size;
            return 1;
        }
        public override void ChangePicture()
        {
            Reset();
            X = Math.Max(0, X);
            Y = Math.Max(0, Y);
            switch (Type)
            {
                case 1:
                    for (int l = 1; l <= Length; l++)
                    {
                        X = Math.Min(X, PictureSize-1);
                        Y = Math.Min(Y, PictureSize - Length);
                        Picture[PictureSize - l - Y][X] = (char)('0' + Depth);
                    }
                    break;
                case 2:
                    X = Math.Min(X, PictureSize - Length);
                    Y = Math.Min(Y, PictureSize-1);
                    for (int l = 0; l < Length; l++)
                    {
                        Picture[PictureSize - 1 - Y][l+X] = (char)('0' + Depth);
                    }
                    break;
                case 3:
                    X = Math.Min(X, PictureSize - Length);
                    Y = Math.Min(Y, PictureSize - Length);
                    for (int l = 1; l <= Length; l++)
                    {
                        Picture[PictureSize - l - Y][l - 1 + X] = (char)('0' + Depth);
                    }
                    break;
            }
        }
    }
}