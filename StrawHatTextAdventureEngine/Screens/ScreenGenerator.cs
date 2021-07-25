using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrawHatTextAdventureEngine.Models.Map;

namespace StrawHatTextAdventureEngine.Screens
{
    public class ScreenGenerator
    {

        public void GenerateScreen(Room room, bool clearScreen = false)
        {

            // Print:

            // Room Title
            // Room desc, long or short
            // Standard Command set
            // Room exits
            // Room actions


            if (clearScreen)
                Console.Clear();
            else
            {
                Console.WriteLine("");
                Console.WriteLine("");
            }
                

            Console.WriteLine(room.Name);
            Console.WriteLine(room.GetDescription());
            Console.WriteLine("");
            Console.WriteLine("Commands: (Tab) Menu   (Esc)  Quit");

            room.Exits.ForEach((exit) => Console.WriteLine(GetExitLine(exit)));

            // TODO: Print room actions (actions don't exist yet)


        }


        private string GetExitLine(Exit exit)
        {
            return $"({exit.Key}) {exit.Name}";
        }

    }
}
