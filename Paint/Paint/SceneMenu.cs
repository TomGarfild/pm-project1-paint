using System;

namespace Paint
{
    public class SceneMenu : Menu
    {
        private readonly Scene _scene;
        public SceneMenu(Scene currentScene)
        {
            _scene = currentScene;
        }
        public override void Start()
        {
            var commands = new string[]
                {"Draw shape","Remove shape", "Arrange shapes", "Filter", "Help", "Main menu"};
            var hasChanged = true;
            while (true)
            {
                if (hasChanged)
                {
                    _scene.Save();
                    _scene.DrawScene();
                }
                hasChanged = true;
                var command = GetInputCommand(commands, _scene.Name);
                switch (command)
                {
                    case 1:
                        _scene.Draw();
                        break;
                    case 2:
                        _scene.Remove();
                        break;
                    case 3:
                        _scene.Arrange(new string[] { "swap shapes", "right", "left", "up", "down" });
                        break;
                    case 4:
                        _scene.Filter(new string[]{"square", "perimeter"});
                        break;
                    case 5:
                        hasChanged = false;
                        var meaning = new string[]
                        {
                            "Draw shape with your parameters.",
                            "Remove shape by its depth index.",
                            "Move shapes in the current scene.",
                            "Filter shapes by some parameters.",
                            "Display information about commands.",
                            "Return to main menu."
                        };
                        PrintHelp(commands, meaning);
                        break;
                    case 6:
                        //Return to main menu
                        return;
                }
            }
        }
    }
}