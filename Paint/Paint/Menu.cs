using System;

namespace Paint
{
    public class Menu
    {
        public virtual void Start()
        {
            Console.WriteLine("Hello, in Console Paint");
            var scenes = new Scenes();
            while (true)
            {
                var command = GetInputCommand(new string[]
                    {"New scene", "Open scene", "Remove scene", "Help", "Exit"});
                switch (command)
                {
                    case 1:
                        scenes.NewScene();
                        break;
                    case 2:
                        var currentScene = scenes.OpenScene();
                        if (currentScene == default(Scene)) break;
                        var sceneMenu = new SceneMenu();
                        sceneMenu.Start();
                        break;
                    case 3:
                        //scenes.Remove(new Scene(""));
                        break;
                    case 4:
                        PrintHelp();
                        break;
                    case 5:
                        //Exit from application
                        return;

                }
            }
        }
        private static void PrintHelp()
        {

        }
        protected static int GetInputCommand(string[] commands)
        {
            Console.WriteLine("\n   Menu");
            for (int i = 0; i < commands.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {commands[i]}");
            }

            Console.WriteLine("Enter number of command in menu");
            int command;
            while (!int.TryParse(Console.ReadLine(), out command) || command < 1 || command > commands.Length)
            {
                Console.WriteLine("\nWrong command\n");
                Console.WriteLine("   Menu");
                for (int i = 0; i < commands.Length; i++)
                {
                    Console.WriteLine($"\t{i + 1}. {commands[i]}");
                }

                Console.WriteLine("Enter number of command in menu");
            }

            return command;
        }
    }
}