namespace Paint.Shapes
{
    public class Circle : Shape
    {
        public bool Filled { get; }
        public Circle(int size, int depth, bool filled)
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