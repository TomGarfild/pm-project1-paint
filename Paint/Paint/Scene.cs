using System.Collections.Generic;

namespace Paint
{
    public class Scene
    {
        public string Name { get; }
        public int Id { get; }
        public List<Shape> shapes;
        public Scene(string name)
        {
            Name = name;
            Id = 1;
            shapes = new List<Shape>();
        }
    }
}