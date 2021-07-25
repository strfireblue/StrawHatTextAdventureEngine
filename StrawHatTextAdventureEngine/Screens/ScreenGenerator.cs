using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using StrawHatTextAdventureEngine.Models.Map;
using Console = Colorful.Console;

namespace StrawHatTextAdventureEngine.Screens
{
    public class ScreenGenerator
    {

        private readonly Color COLOR_ROOM_TITLE = Color.SteelBlue;
        private readonly Color COLOR_DESCRIPTION = Color.White;
        private readonly Color COLOR_STANDARD_MENU = Color.Gray;
        private readonly Color COLOR_EXITS = Color.ForestGreen;


        /// <summary>
        /// Renders the game screen, including room title, description, and available actions the player can take.
        /// </summary>
        /// <param name="room">The Room the player is currently in.</param>
        /// <param name="clearScreen">Whether to clear the screen before writing new text.  Default is false.</param>
        public void GenerateScreen(Room room, bool clearScreen = false)
        {
            if (clearScreen)
                Console.Clear();
            else
            {
                Console.WriteLine("");
                Console.WriteLine("");
            }


            Console.WriteLine(room.Name, COLOR_ROOM_TITLE);

            Console.WriteLine(room.GetDescription(), COLOR_DESCRIPTION);
            Console.WriteLine("");
            Console.WriteLine("Commands: (Tab) Menu   (Esc)  Quit", COLOR_STANDARD_MENU);

            room.Exits.ForEach((exit) => Console.WriteLine(GetExitLine(exit), COLOR_EXITS));

            // TODO: Print room actions (actions don't exist yet)


        }


        private string GetExitLine(Exit exit)
        {
            return $"({exit.Key}) {exit.Name}";
        }

    }
}
