using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrawHatTextAdventureEngine.Models.Map
{
    public class Room
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public List<Items.Item> Items { get; set; }

        public List<Exit> Exits { get; set; }

        private bool _Visited = false;


        public string GetDescription(bool useLongDescription = false)
        {

            if (useLongDescription)
                return Description;

            if (_Visited)
            {
                return ShortDescription;
            }
            else
            {
                _Visited = true;
                return Description;
            }
        }

        


    }
}
