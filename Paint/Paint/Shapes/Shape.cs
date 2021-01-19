namespace Paint.Shapes
{
    public abstract class Shape
    {
        public int Depth { get; }

        protected Shape(int depth)
        {
            Depth = depth;
        }
        protected abstract int CalculateSquare();
        protected abstract int CalculatePerimeter();
    }
}