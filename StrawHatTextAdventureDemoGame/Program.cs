using System;

namespace StrawHatTextAdventureDemoGame
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create new Demo Game Engine
            Game demoGame = new Game(new StrawHatTextAdventureEngine.Services.Game.GameDataService(), new StrawHatTextAdventureEngine.Services.Game.SaveGameDataService());

            demoGame.MainLoop();

        }
    }
}
