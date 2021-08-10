using System;

namespace StrawHatTextAdventureEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine test = new GameEngine(new Services.Game.GameDataService(), new Services.Game.SaveGameDataService());

            test.MainLoop();
            
        }
    }
}
