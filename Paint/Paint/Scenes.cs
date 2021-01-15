using System;
using System.Collections.Generic;
using System.IO;
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

        public void Add(Scene scene)
        {
            scenes.Add(scene);
        }
    }
}