using System;
using System.Collections.Generic;

namespace StrawHatTextAdventureEngine.Models.Player
{

    /// <summary>
    /// Represents the player in the game.  Keeps track of all vital statistics and location information.
    /// </summary>
    public class Player
    {

        public string Name { get; set; }

        public int Age { get; set; }

        public int MaxHP { get; set; }

        public int MaxMP { get; set; }

        private int _HP;
        public int HP
        {
            get
            {
                return _HP;
            }
            set
            {
                if (value > MaxHP)
                    _HP = MaxHP;
                else
                    _HP = value;
            }
        }


        private int _MP;
        public int MP
        {
            get
            {
                return _MP;
            }
            set
            {
                if (value > MaxMP)
                    _MP = MaxMP;
                else
                    _MP = value;
            }
        }

        public int Intelligence { get; set; } = 0;

        public int Strength { get; set; } = 0;

        public int Dexterity { get; set; } = 0;



    }
}
