using System;
using StrawHatTextAdventureEngine.Models.Map;

namespace StrawHatTextAdventureEngine.Models.Actions
{
    public class ExitRoomAction : IAction
    {

        private readonly Exit exit;
        private readonly Player.Player player;

        public ExitRoomAction(Exit exit, Player.Player player)
        {
            this.exit = exit;
            this.player = player;
        }

        public void Execute()
        {
            exit.MoveToDestination(player);
        }
    }
}
