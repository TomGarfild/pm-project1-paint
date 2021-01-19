using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Paint.Shapes;

namespace Paint
{
    public class Scene
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("shapes")]
        public List<Shape> _shapes { get; set; }

        public Scene()
        {
        }
        public Scene(string name, int id)
        {
            Name = name;
            Id = id;
            _shapes = new List<Shape>();
        }

        public void DrawScene(int width, int height)
        {
            Console.SetWindowSize(width, height);
        }
        public void Draw()
        {
            
            //Max depth is 10 (from 0 to 9)
            if (_shapes.Count == 10)
            {
                Console.WriteLine("Sorry, but you cannot draw new shape.");
                Console.WriteLine("Firstly, please remove one or more shapes from current scene.");
            }
            else
            {
                var type = GetType();
                var size = GetSize(new string[] {"small", "medium", "large"});
                Shape shape;
                switch (type)
                {
                    case Shapes.Shapes.Line:
                        shape = new Line(size, _shapes.Count + 1);
                        break;
                    case Shapes.Shapes.Triangle:
                        shape = new Triangle(size, _shapes.Count + 1, IsFilled());
                        break;
                    case Shapes.Shapes.Rectangle:
                        shape = new Rectangle(size, _shapes.Count + 1, IsFilled());
                        break;
                    case Shapes.Shapes.Circle:
                        shape = new Circle(size, _shapes.Count + 1, IsFilled());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                _shapes.Add(shape);

            }
        }
        public void Change()
        {

        }

        public void Remove()
        {
            int depth;
            Console.WriteLine("Enter depth of the shape that you want to remove");
            while (!int.TryParse(Console.ReadLine(), out depth) || depth < 0 || depth > 9)
            {
                Console.WriteLine("Your input is wrong. Please try again.");
            }

            if (_shapes.Count <= depth)
            {
                Console.WriteLine($"Sorry, but shape with depth {depth} doesn't exist in current scene.");
            }
            else
            {
                Console.WriteLine($"Are you sure about removing shape with depth {depth}?");
                Console.WriteLine("Press y to confirm.");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    _shapes.Remove(_shapes.FirstOrDefault(sh => sh.Depth == depth));
                    Console.WriteLine($"Shape with {depth} was successfully removed from current scene.");
                }
                
            }
        }

        public void Arrange()
        {

        }

        private new Shapes.Shapes GetType()
        {
            foreach (var s in Enum.GetValues(typeof(Shapes.Shapes)))
            {
                Console.WriteLine($"{(int)s} - {s}");
            }

            int type;
            Console.Write("Enter number of the shape that you choose: ");
            while (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 4)
            {
                Console.WriteLine("Sorry, but your input is wrong. Try again.\n");
                foreach (var s in Enum.GetValues(typeof(Shapes.Shapes)))
                {
                    Console.WriteLine($"{(int)s} - {s}");
                }
                Console.Write("Enter number of the shape that you choose: ");
            }
            return (Shapes.Shapes)type;
        }

        private int GetSize(string[] sizes)
        {
            for (int i = 0; i < sizes.Length; i++)
            {
                Console.WriteLine($"{i+1} - {sizes[i]}");
            }

            Console.Write("Enter number of the size for your shape: ");
            if (int.TryParse(Console.ReadLine(), out var key)
                && key >= 1 && key <= sizes.Length) return key;
            //else return small size
            return 1;
        }

        private bool IsFilled()
        {
            Console.WriteLine("Do you want to fill shape?");
            Console.WriteLine("Press T to confirm.");
            if (Console.ReadKey().Key == ConsoleKey.T) return true;
            return false;
        }
    }
}