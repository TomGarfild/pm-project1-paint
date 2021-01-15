using System;

namespace Paint
{
    public class SceneMenu : Menu
    {
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