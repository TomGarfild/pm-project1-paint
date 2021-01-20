using System;

namespace Paint
{
    class Program
    {
        
        static void Main()
        {
            Console.SetWindowSize(ConsoleSize.Width, ConsoleSize.Height);
            var menu = new Menu();
            try
            {
                menu.Start();
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
}
