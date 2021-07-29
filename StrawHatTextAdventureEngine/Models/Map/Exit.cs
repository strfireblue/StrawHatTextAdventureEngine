using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrawHatTextAdventureEngine.Models.Map
{
    public class Exit
    {

        public string Name { get; set; }

        public string Key { get; set; }

        public Room Destination { get; set; }

        public event EventHandler ExitUsed;

        


        public Action ExitCallback { get; set; }


        public void MoveToDestination(Player.Player player)
        {
            player.CurrentRoom = Destination;

            ExitUsed?.Invoke(this, EventArgs.Empty);
        }


    }
}
