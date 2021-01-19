using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Paint.Shapes
{
    public class Shape
    {
        [JsonPropertyName("depth")]
        public int Depth { get; set; }
        [JsonPropertyName("picture")]
        public List<List<char>> Picture { get; set; }
        [JsonIgnore]
        public double Perimeter { get; set; }
        [JsonIgnore]
        public double Square { get; set; }
        protected Shape()
        {
        }
        protected Shape(int pictureSize, int depth)
        {
            Depth = depth;
            //Picture should be in proportion width:height - 2:1
            Picture = new List<List<char>>();
            for (int i = 0; i < pictureSize; i++)
            {
                Picture.Add(new List<char>());
                for (int j = 0; j < pictureSize * 2; j++)
                {
                    Picture[i].Add('\0');
                }
            }
        }
        protected int GetShapeKind(string[] types, string shapeName)
        {
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {types[i]}");
            }
            Console.Write($"Enter number of the type of your {shapeName}: ");
            if (int.TryParse(Console.ReadLine(), out var key)
                && key >= 1 && key <= types.Length) return key;
            return 1;
        }
    }
}