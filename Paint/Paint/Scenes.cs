using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Paint
{
    public class Scenes
    {
        private List<Scene> scenes;

        public Scenes()
        {
            try
            {
                var json = File.ReadAllText("scenes.json");
                scenes = JsonSerializer.Deserialize<List<Scene>>(json);
            }
            catch (Exception)
            {
                scenes = new List<Scene>();
            }
        }
        public void NewScene()
        {

        }
        public Scene OpenScene()
        {
            int id;
            Console.WriteLine("Enter id of the scene that you want to open");
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("Your input is wrong. Please try again.");
            }

            try
            {
                return scenes.First();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"Sorry, but scene with id {id} doesn't exist.");
                return null;
            }
        }

        public void Remove(Scene scene)
        {
            scenes.Remove(scene);
        }
    }
}