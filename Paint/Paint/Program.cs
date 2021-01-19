using System;

namespace Paint
{
    class Program
    {
        
        static void Main()
        {
            Console.SetWindowSize(PictureSize.Width, PictureSize.Height);
            var menu = new Menu();
            menu.Start();
        }
    }
}
