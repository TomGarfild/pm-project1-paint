namespace Paint.Shapes
{
    public class Triangle : Shape
    {
        public bool Filled { get; }
        public Triangle(int size, int depth, bool filled)
            : base(size, depth)
        {
            Filled = filled;
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