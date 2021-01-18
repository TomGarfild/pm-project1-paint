namespace Paint.Shapes
{
    public abstract class Shape
    {
        public int Size { get; }
        public int Depth { get; }

        protected Shape(int size, int depth)
        {
            Size = size;
            Depth = depth;
        }
    }
}