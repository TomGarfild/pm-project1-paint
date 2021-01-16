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
        public Scene NewScene()
        {
            Console.WriteLine("Enter name of this scene");
            var name = Console.ReadLine();
            while (scenes.Exists(s => s.Name == name))
            {
                Console.WriteLine("Sorry, but scene with such name already exists. Try again.");
                name = Console.ReadLine();
            }
            var scene = new Scene(name);
            scenes.Add(scene);
            return scene;
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

        public void Remove()
        {
            int id;
            Console.WriteLine("Enter id of the scene that you want to remove");
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("Your input is wrong. Please try again.");
            }
            try
            {
                scenes.Remove(scenes.First(s => s.Id == id));
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"Sorry, but scene with id {id} doesn't exist.");
            }
        }
        public void ShowAll()
        {
            if (scenes.Count == 0)
            {
                Console.WriteLine("You have not created any scene, yet.");
            }
            else
            {
                scenes.ForEach(s => Console.WriteLine($"Id: {s.Id}; Name: {s.Name}"));
            }
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(scenes);
            File.WriteAllText("scenes.json", json);
        }
    }
}