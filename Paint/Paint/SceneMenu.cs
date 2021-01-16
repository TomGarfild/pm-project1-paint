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
            var commands = new string[]
                {"Draw shape", "Change shape", "Remove shape", "Arrange shapes", "Help", "Main menu"};
            while (true)
            {
                var command = GetInputCommand(commands);
                switch (command)
                {
                    case 1:
                        scene.Draw();
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        scene.Remove();
                        break;
                    case 4:
                        scene.Arrange();
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