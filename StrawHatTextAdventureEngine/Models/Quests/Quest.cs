using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrawHatTextAdventureEngine.Models.Quests
{
    public class Quest
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Goal> Goals { get; set; }

    }
}
