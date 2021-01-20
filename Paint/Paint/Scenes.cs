using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Paint
{
    public class Scenes
    {
        private readonly List<Scene> _scenes;
        private static int _lastId;
        public Scenes()
        {
            try
            {
                var json = File.ReadAllText("scenes.json");
                _scenes = JsonSerializer.Deserialize<List<Scene>>(json);
                _lastId = _scenes.Last().Id + 1;
            }
            catch (Exception)
            {
                _scenes = new List<Scene>();
                _lastId = 1;
            }
        }
        public Scene NewScene()
        {
            Console.WriteLine("Enter name of this scene");
            var name = GetName();
            var scene = new Scene(name, _lastId++);
            _scenes.Add(scene);
            Console.WriteLine("New scene was created successfully.\nYou will be redirected to menu of this scene.");
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
                var scene = _scenes.First(s => s.Id == id);
                scene.Update();
                return scene;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"Sorry, but scene with id {id} doesn't exist.");
                return null;
            }
        }

        public bool Remove()
        {
            int id;
            Console.WriteLine("Enter id of the scene that you want to remove");
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("Your input is wrong. Please try again.");
            }

            if (_scenes.Exists(s => s.Id == id))
            {
                Console.WriteLine($"Are you sure about removing scene with id {id}?");
                Console.Write("Press y to confirm ");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.WriteLine();
                    _scenes.Remove(_scenes.First(s => s.Id == id));
                    Console.WriteLine($"Scene with id {id} was successfully removed.");
                    //update last id
                    _lastId = _scenes.Last().Id + 1;
                    return true;
                }
            }
            else
            {
                Console.WriteLine($"Sorry, but scene with id {id} doesn't exist.");
            }

            return false;
        }
        public void ShowAll()
        {
            if (_scenes.Count == 0)
            {
                Console.WriteLine("You have not created any scene, yet.");
            }
            else
            {
                _scenes.ForEach(s => Console.WriteLine($"Id: {s.Id}; Name: {s.Name}"));
            }
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(_scenes);
            File.WriteAllText("scenes.json", json);
        }

        private string GetName()
        {
            var name = Console.ReadLine()?.Trim();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Sorry, name cannot be empty. Try again.");
                name = Console.ReadLine()?.Trim();
            }
            while (_scenes.Exists(s => s.Name == name))
            {
                Console.WriteLine("Sorry, but scene with such name already exists. Try again.");
                name = Console.ReadLine()?.Trim();
                while (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Sorry, name cannot be empty. Try again.");
                    name = Console.ReadLine()?.Trim();
                }
            }

            return name;
        }
    }
}