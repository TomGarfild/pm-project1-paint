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
        public override void Start(int width, int height)
        {
            var commands = new string[]
                {"Draw shape", "Change shape", "Remove shape", "Arrange shapes", "Help", "Main menu"};
            while (true)
            {
                _scene.DrawScene(width, height);
                var command = GetInputCommand(commands, _scene.Name);
                switch (command)
                {
                    case 1:
                        _scene.Draw();
                        break;
                    case 2:
                        _scene.Change();
                        break;
                    case 3:
                        _scene.Remove();
                        break;
                    case 4:
                        _scene.Arrange();
                        break;
                    case 5:
                        var meaning = new string[]
                        {
                            "Draw shape with your parameters.",
                            "Change parameters of chosen shape.",
                            "Remove shape by its depth index.",
                            "Move shapes in the current scene.",
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