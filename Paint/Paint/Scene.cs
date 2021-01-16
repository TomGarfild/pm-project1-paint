namespace Paint
{
    public class Scene
    {
        public string Name { get; }
        public int Id { get; }
        public Scene(string name)
        {
            Name = name;
            Id = 1;
        }
    }
}