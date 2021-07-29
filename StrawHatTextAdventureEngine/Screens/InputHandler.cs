using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;
using StrawHatTextAdventureEngine.Models.Player;
using StrawHatTextAdventureEngine.Models.Actions;

namespace StrawHatTextAdventureEngine.Screens
{
    public class InputHandler
    {

        public void HandleInput(ConsoleKeyInfo keyPressed, Dictionary<string, IAction> actions)
        {

            string keyPressedStr = keyPressed.Key.ToString();


            if (actions.ContainsKey(keyPressedStr))
            {
                actions[keyPressedStr].Execute();
            }

            // TODO: Move these into their own IActions
            else if (keyPressed.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("");
                Console.WriteLine("Thank you for playing!  We hope to see you again soon!", Color.MediumPurple);
            }
            else if (keyPressed.Key == ConsoleKey.Tab)
            {
                Console.WriteLine("Menu is not accessible right now.", Color.IndianRed);
            }
            else
            {
                Console.WriteLine("Invalid command.", Color.IndianRed);
            }



        }

    }
}
