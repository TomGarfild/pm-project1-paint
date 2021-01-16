using System;

namespace Paint
{
    public class SceneMenu : Menu
    {
        private Scene scene;
        public SceneMenu(Scene currentScene)
        {
            scene = currentScene;
        }
        public override void Start()
        {
            while (true)
            {
                var command = GetInputCommand(new string[]
                    {});
                switch (command)
                {
                }
            }
        }
    }
}