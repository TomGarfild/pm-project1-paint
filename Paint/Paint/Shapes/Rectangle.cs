namespace Paint.Shapes
{
    public class Rectangle : Shape
    {
        public bool Filled { get; }
        public Rectangle(int size, int depth, bool filled)
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