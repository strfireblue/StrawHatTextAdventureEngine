using System;

namespace StrawHatTextAdventureEngine.Models.Actions
{
    public class PlayerMenuAction : IAction
    {
        private readonly Player.Player player;

        public PlayerMenuAction(Player.Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            Console.WriteLine("Not yet implemented.");
        }
    }
}
