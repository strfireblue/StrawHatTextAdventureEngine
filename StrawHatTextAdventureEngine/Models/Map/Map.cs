using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrawHatTextAdventureEngine.Models.Map
{
    public class Map
    {

        public List<Room> Rooms { get; set; }


        /// <summary>
        /// Get a string array representing the ASCII art drawing of the Map.
        /// </summary>
        /// <param name="showAllRooms">Show all rooms of the map, even if the Player hasn't seen them yet?  Defaults to False.</param>
        /// <returns></returns>
        public string[][] DrawMap(bool showAllRooms = false)
        {
            throw new NotImplementedException();
        }

    }
}
