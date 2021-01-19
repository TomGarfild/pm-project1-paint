using System;

namespace Paint
{
    class Program
    {
        private const int Height = 40;
        private const int Width = Height*3;
        static void Main()
        {
            Console.SetWindowSize(Width, Height);
            var menu = new Menu();
            menu.Start(Width, Height);
        }
    }
}
