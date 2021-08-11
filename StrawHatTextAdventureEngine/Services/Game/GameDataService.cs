using System;
using StrawHatTextAdventureEngine.Models.Game;
using StrawHatTextAdventureEngine.Models.Map;

namespace StrawHatTextAdventureEngine.Services.Game
{
    public class GameDataService
    {

        public GameData LoadGameData(string pathToGameData)
        {

            return new GameData()
            {
                Player = new Models.Player.Player(),
                StartingRoom = new Room()
                {
                    Name = "TEST ROOM",
                    Description = "TEST ROOM",
                    ShortDescription = "TEST ROOM"
                }
            };
        }

    }
}
