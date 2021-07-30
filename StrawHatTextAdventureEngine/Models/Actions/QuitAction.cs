using System;
using System.Drawing;
using Console = Colorful.Console;

namespace StrawHatTextAdventureEngine.Models.Actions
{
    public class QuitAction : IAction
    {
        public void Execute()
        {
            Console.WriteLine("");
            Console.WriteLine("Thank you for playing!  We hope to see you again soon!", Color.MediumPurple);

            Environment.Exit(0);
        }
    }
}
