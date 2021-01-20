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
                        Console.ForegroundColor = ConsoleColor.Green;
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
                        var depth = selected.Min();
                        Console.ForegroundColor = _shapes[depth].Color;
                        Console.Write(depth);
                    }
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
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
                Console.Write ("Press y to confirm ");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.WriteLine();
                    _shapes.Remove(_shapes.FirstOrDefault(sh => sh.Depth == depth));
                    Console.WriteLine($"Shape {depth} was successfully removed from current scene.");
                    foreach (var sh in _shapes)
                    {
                        if (sh.Depth > depth) sh.Depth--;
                    }
                }
            }
        }

        public void Arrange(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {options[i]}");
            }
            Console.Write($"Enter number how do you want to arrange shapes: ");
            if (int.TryParse(Console.ReadLine(), out var index)
                && index >= 1 && index <= options.Length)
            {
                if (index == 1)
                {
                    var depth = new int[2];
                    for (int i = 0; i < 2; i++)
                    {
                        Console.Write($"Enter depth of {i+1} shape: ");
                        if (!int.TryParse(Console.ReadLine(), out depth[i]) || depth[i] < 0 || depth[i] >= _shapes.Count())
                        {
                            Console.WriteLine("Such depth doesn't exist.");
                            return;
                        }
                    }

                    Swap(_shapes, depth[0], depth[1]);
                }
                else
                {
                    Console.Write("Enter distance to move: ");
                    if (int.TryParse(Console.ReadLine(), out var distance) && distance > 0)
                    {

                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry, but such command doesn't exist.");
            }
        }

        public void Filter(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {options[i]}");
            }
            Console.Write($"Enter number of the filter: ");
            if (int.TryParse(Console.ReadLine(), out var index)
                && index >= 1 && index <= options.Length)
            {
                _shapes = index == 1 ? _shapes.OrderBy(sh => sh.Square).ToList()
                                        : _shapes.OrderBy(sh => sh.Perimeter).ToList();
                var i = 0;
                foreach (var sh in _shapes)
                {
                    sh.Depth = i++;
                }
                Console.WriteLine($"Shapes were filtered by {options[index-1]}.");
            }
            else
            {
                Console.WriteLine("Shapes were not filtered.");
            }
        }
        private new static Shapes.Shapes GetType()
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

        private static bool IsFilled()
        {
            Console.WriteLine("Do you want to fill shape?");
            Console.Write("Press y to confirm ");
            var key = Console.ReadKey().Key;
            Console.WriteLine();
            return key == ConsoleKey.Y;
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

        private static void Swap(IList<Shape> list, int i, int j)
        {
            var temp = list[i].Depth;
            list[i].Depth = list[j].Depth;
            list[j].Depth = temp;
        }
    }
}