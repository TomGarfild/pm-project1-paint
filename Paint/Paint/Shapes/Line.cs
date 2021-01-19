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
            switch (Type)
            {
                case 1:
                    for (int l = 1; l <= Length; l++)
                    {
                        Picture[pictureSize - l][0] = (char)('0'+Depth);
                    }
                    break;
                case 2:
                    for (int l = 0; l < Length; l++)
                    {
                        Picture[pictureSize - 1][l] = (char)('0' + Depth);
                    }
                    break;
                case 3:
                    for (int l = 1; l <= Length; l++)
                    {
                        Picture[pictureSize-l][l-1] = (char)('0' + Depth);
                    }
                    break;
            }
        }
        private int GetLength()
        {
            Console.Write("Enter length of the line: ");
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