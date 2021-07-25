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

        public Func<string> DescriptionPrintEvent { get; set; }

        public string GetDescription(bool useLongDescription = false)
        {

            string extraText = "";

            if (DescriptionPrintEvent != null)
                extraText = DescriptionPrintEvent();


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
