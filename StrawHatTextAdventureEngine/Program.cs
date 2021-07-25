using System;

namespace StrawHatTextAdventureEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Game test = new Game(new Services.Game.GameDataService(), new Services.Game.SaveGameDataService());

            test.MainLoop();
            
        }
    }
}
