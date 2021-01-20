using System;

namespace Paint
{
    public class Menu
    {
        public virtual void Start()
        {
            Console.WriteLine("Hello, in Console Paint");
            var scenes = new Scenes();
            var commands = new string[]
                {"New scene", "Open scene", "Existing scenes", "Remove scene", "Help", "Exit"};
            while (true)
            {
                var command = GetInputCommand(commands, "Main");
                switch (command)
                {
                    case 1:
                    case 2:
                        Scene currentScene;
                        if (command == 1)
                        {
                            currentScene = scenes.NewScene();
                            scenes.Save();
                        }
                        else
                        {
                            currentScene = scenes.OpenScene();
                            if (currentScene == default(Scene)) break;
                        }
                        var sceneMenu = new SceneMenu(currentScene);
                        sceneMenu.Start();
                        break;
                    case 3:
                        scenes.ShowAll();
                        break;
                    case 4:
                        if (scenes.Remove()) scenes.Save();
                        break;
                    case 5:
                        var meaning = new string[]
                        {
                            "Create new scene with unique name, that you choose, and auto-generated unique Id. Also, redirect to menu of this scene.",
                            "Open scene by Id that was created early. And redirect to menu of this scene if it exists.",
                            "Display existing scenes' names and ids.",
                            "Remove scene by Id. Do nothing if such scene doesn't exist.",
                            "Display information about commands.",
                            "Exit from application."
                        };
                        PrintHelp(commands, meaning);
                        break;
                    case 6:
                        //Exit from application
                        return;

                }
            }
        }
        protected static void PrintHelp(string[] commands, string[] meaning)
        {
            Console.WriteLine("\n   Help");
            for (int i = 0; i < commands.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {commands[i]} - {meaning[i]}");
            }
        }
        protected static int GetInputCommand(string[] commands, string menuName)
        {
            Console.WriteLine($"\n{menuName} menu");
            for (int i = 0; i < commands.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {commands[i]}");
            }

            Console.WriteLine("Enter number of command in menu");
            int command;
            while (!int.TryParse(Console.ReadLine(), out command) || command < 1 || command > commands.Length)
            {
                Console.WriteLine("Wrong command");
                Console.WriteLine($"\n{menuName} menu");
                for (int i = 0; i < commands.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {commands[i]}");
                }

                Console.WriteLine("Enter number of command in menu");
            }

            return command;
        }
    }
}