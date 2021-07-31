using System;

namespace StrawHatTextAdventureEngine.Models.Map
{

    /// <summary>
    /// An Exit may be used to move from one Room to another Room.  An Exit always has a Destination, being another Room.
    /// </summary>
    /// <seealso cref="Room"/>
    public class Exit
    {

        /// <summary>
        /// The name of the Exit.  This is the full text description.  Example: North, South, East, West, Up, Down, Doorway, Shining Passageway
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Key the user must select in order to use this Exit.  Example: N, S, E, W, U, D, S, Q, etc.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The Room that this Exit leads to.  When the player uses this Exit, the Player's current room will be set to the Destination Room.
        /// </summary>
        /// <seealso cref="Room"/>
        public Room Destination { get; set; }

        /// <summary>
        /// Event that fires when this Exit is used.  This event fires and AFTER that event the player's current room is set to the Destination.
        /// </summary>
        public event EventHandler ExitUsed;


        /// <summary>
        /// Move the player to the Destination, invoking any Exit events necessary BEFORE moving the player.
        /// </summary>
        /// <param name="player">The Player to move.</param>
        public void MoveToDestination(Player.Player player)
        {
            ExitUsed?.Invoke(this, EventArgs.Empty);

            player.CurrentRoom = Destination;
        }


    }
}
