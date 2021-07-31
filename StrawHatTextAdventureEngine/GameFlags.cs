using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrawHatTextAdventureEngine
{
    /// <summary>
    /// Tentatively a global class that has flags that can be used in the game.  For example to determine if a door was shut or not, if a checkpoint was cleared, etc.
    /// Have to determine if this is the best way to do it, or if there's a much better way to manage (there must be).
    /// </summary>
    public static class GameFlags
    {

        public static Dictionary<string, object> Flags = new Dictionary<string, object>();


        public static void IncrementGlobalActionsCounter()
        {
            // Increment global actions taken counter
            if (!GameFlags.Flags.ContainsKey(Constants.GAME_FLAGS_TOTAL_ACTIONS_TAKEN))
                GameFlags.Flags.Add(Constants.GAME_FLAGS_TOTAL_ACTIONS_TAKEN, 1);
            else
            {
                int totalActionsTaken = (int)GameFlags.Flags[Constants.GAME_FLAGS_TOTAL_ACTIONS_TAKEN];
                GameFlags.Flags[Constants.GAME_FLAGS_TOTAL_ACTIONS_TAKEN] = totalActionsTaken + 1;
            }
        }

    }
}
