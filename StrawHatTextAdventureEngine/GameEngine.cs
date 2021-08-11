using System;
using System.Collections.Generic;
using System.Linq;
using StrawHatTextAdventureEngine.Services.Game;
using StrawHatTextAdventureEngine.Screens;
using StrawHatTextAdventureEngine.Models.Game;
using StrawHatTextAdventureEngine.Models.Player;

namespace StrawHatTextAdventureEngine
{
    public class GameEngine
    {
        private readonly GameDataService gameDataService;
        private readonly SaveGameDataService saveGameDataService;

        private GameData GameData;


        public GameEngine(GameDataService gameDataService, SaveGameDataService saveGameDataService)
        {
            this.gameDataService = gameDataService;
            this.saveGameDataService = saveGameDataService;
        }


        public GameEngine(GameData gameData, SaveGameDataService saveGameDataService)
        {
            this.GameData = gameData;
            this.saveGameDataService = saveGameDataService;
        }


        /// <summary>
        /// Start the Game by starting the Main game Loop.
        /// </summary>
        public void StartGame()
        {

            if (GameData == null)
                GameData = gameDataService.LoadGameData("");

            MainLoop();
        }



        private void MainLoop()
        {
            Player player = GameData.Player;

            // TODO: Will probably end up with some global flags class
            bool quit = false;

            

            player.CurrentRoom = GameData.StartingRoom;

            ScreenGenerator screenGenerator = new ScreenGenerator();

            while (!quit)
            {

                // Generate the Screen for current room
                var screenActions = screenGenerator.GenerateScreen(player);

                InputHandler inputHandler = new InputHandler();

                var keyInput = Console.ReadKey(true);

                inputHandler.HandleInput(keyInput, screenActions);

            }


        }

    }
}
