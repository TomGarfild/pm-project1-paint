using System;
using System.Collections.Generic;
using System.Linq;

namespace Paint
{
    public class Scene
    {
        public string Name { get; }
        public int Id { get; }
        private readonly List<Shape> _shapes;
        public Scene(string name, int id)
        {
            Name = name;
            Id = id;
            _shapes = new List<Shape>();
        }

        public void Draw()
        {
            //Max depth is 10 (from 0 to 9)
            if (_shapes.Count == 10)
            {
                Console.WriteLine("Sorry, but you cannot draw new shape.");
            }
            else
            {
                //TODO make functional for drawing shapes
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
    }
}