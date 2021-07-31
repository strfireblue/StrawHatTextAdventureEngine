using System;
using System.Collections.Generic;

namespace StrawHatTextAdventureEngine.Models.Map
{

    /// <summary>
    /// Represents a single area in the game world, generally a Room/Corridor/etc.
    /// </summary>
    public class Room
    {

        /// <summary>
        /// Name or title of the room to be displayed to the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Long description of the room.  This is generally displayed on the first visit, whereas the ShortDescription might be shown after two or more visits, to condense information.
        /// </summary>
        /// <seealso cref="ShortDescription"/>
        public string Description { get; set; }

        /// <summary>
        /// Short description of the room.  This is generally a shorter version of the Description shown to the player on subsequent visits.  This description should not contain any new information, but rather a summary of the longer description.
        /// </summary>
        /// <seealso cref="Description"/>
        public string ShortDescription { get; set; }


        /// <summary>
        /// Items that the room holds, that the player may pick up or interact with.
        /// </summary>
        /// <seealso cref="Models.Items.Item"/>
        public List<Items.Item> Items { get; set; }

        /// <summary>
        /// Exits that the player may choose to take to leave this Room and enter another Room.
        /// </summary>
        /// <seealso cref="Exit"/>
        public List<Exit> Exits { get; set; }


        private bool _Visited = false;

        /// <summary>
        /// Whether the Room has been visited or not yet, defined as the Player having entered the room via an Exit.
        /// </summary>
        public bool Visited
        {
            get
            {
                return _Visited;
            }

            set
            {
                _Visited = value;
                
                if (_Visited)
                    RoomVisited.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// An event that can APPEND text to the Description or ShortDescription.
        /// </summary>
        public Func<string> DescriptionPrinting { get; set; }

        /// <summary>
        /// An event that can perform an action when the player visits the room.  When Visited is changed to True, this event fires.  If Visited is set to False, even if it's already False, this event does not fire.
        /// </summary>
        /// <seealso cref="Visited"/>
        public event EventHandler RoomVisited;

        /// <summary>
        /// Generate the full description of the room, given whether the player has visited before, taking into account any description-modifying events.
        /// </summary>
        /// <param name="useLongDescription">Override the Visited check and return the full length Description even if the ShortDescription would have been shown.</param>
        /// <returns>The description of the room to show to the player.</returns>
        /// <seealso cref="Visited"/>
        /// <seealso cref="Description"/>
        /// <seealso cref="ShortDescription"/>
        public string GetDescription(bool useLongDescription = false)
        {

            string extraText = "";

            if (DescriptionPrinting != null)
                extraText = DescriptionPrinting();


            if (useLongDescription)
                return Description + "  " + extraText;

            if (_Visited)
            {
                return ShortDescription + "  " + extraText;
            }
            else
            {
                _Visited = true;
                return Description + "  " + extraText;
            }

        }




    }
}
