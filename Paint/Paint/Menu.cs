using System;

namespace Paint
{
    public class Menu
    {
        public void Start()
        {
            Console.WriteLine("Hello, in Console Paint");
            while (true)
            {
                var command = GetInputCommand(new string[]
                    {"Scenes", "Draw", "Arrange shapes", "Help", "Exit"});
                switch (command)
                {
                    case 1:
                        var scenes = new Scene();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        //Exit from application
                        return;

                }
            }
        }
        private static int GetInputCommand(string[] commands)
        {
            Console.WriteLine("   Menu");
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