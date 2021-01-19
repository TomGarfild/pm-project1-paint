using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
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

        private List<Shape> _shapes;

        private const int PictureSize = 25;

        public Scene()
        {
        }

        public Scene(string name, int id)
        {
            Name = name;
            Id = id;
            _shapes = new List<Shape>();
        }

        public void DrawScene()
        {
            Console.SetWindowSize(ConsoleSize.Width, ConsoleSize.Height);
            for (int i = 0; i < PictureSize+2; i++)
            {
                Console.Write(' ');
                for (int j = 0; j < PictureSize*2+2; j++)
                {
                    //borders
                    if (i == 0 || i == PictureSize + 1 ||
                        j == 0 || j == 2 * PictureSize + 1)
                    {
                        Console.Write('#');
                        continue;
                    }
                    var selected = _shapes.Where(s => s.Picture[i-1][j-1] != '\0').Select(s => s.Depth).ToList();
                    
                    if (!selected.Any())
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write(selected.Min());
                    }
                }
                Console.WriteLine();
            }
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
                Shape shape;
                switch (type)
                {
                    case Shapes.Shapes.Line:
                        shape = new Line(PictureSize, _shapes.Count);
                        break;
                    case Shapes.Shapes.Triangle:
                        shape = new Triangle(PictureSize, _shapes.Count, IsFilled());
                        break;
                    case Shapes.Shapes.Rectangle:
                        shape = new Rectangle(PictureSize, _shapes.Count, IsFilled());
                        break;
                    case Shapes.Shapes.Circle:
                        shape = new Circle(PictureSize, _shapes.Count, IsFilled());
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
                    foreach (var sh in _shapes)
                    {
                        if (sh.Depth > depth) sh.Depth--;
                    }
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

        private bool IsFilled()
        {
            Console.WriteLine("Do you want to fill shape?");
            Console.WriteLine("Press T to confirm.");
            if (Console.ReadKey().Key == ConsoleKey.T) return true;
            return false;
        }

        public void Update()
        {
            try
            {
                var json = File.ReadAllText(Name + ".json");
                _shapes = JsonSerializer.Deserialize<List<Shape>>(json);
            }
            catch (Exception)
            {
                _shapes = new List<Shape>();
            }
        }
        public void Save()
        {
            var json = JsonSerializer.Serialize(_shapes);
            File.WriteAllText(Name + ".json", json);
        }
    }
}