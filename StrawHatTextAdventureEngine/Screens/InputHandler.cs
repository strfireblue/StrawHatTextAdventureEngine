using StrawHatTextAdventureEngine.Models.Actions;
using StrawHatTextAdventureEngine.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrawHatTextAdventureEngine.Screens
{
    public class InputHandler
    {

        public void HandleInput(ConsoleKeyInfo keyPressed, Player player, Dictionary<string, IAction> actions)
        {

            string keyPressedStr = keyPressed.Key.ToString();


            if (actions.ContainsKey(keyPressedStr))
            {
                actions[keyPressedStr].Execute();
            }



            //switch (keyPressed)
            //{
            //    case ConsoleKey.Tab:
            //        // MENU
            //        break;


            //    default:
            //        break;
            //}



        }

    }
}
