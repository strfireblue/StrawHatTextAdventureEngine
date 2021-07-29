using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;
using StrawHatTextAdventureEngine.Services.Game;
using StrawHatTextAdventureEngine.Screens;

namespace StrawHatTextAdventureEngine
{
    public class Game
    {
        private readonly GameDataService gameDataService;
        private readonly SaveGameDataService saveGameDataService;

        public Game(Services.Game.GameDataService gameDataService, SaveGameDataService saveGameDataService)
        {
            this.gameDataService = gameDataService;
            this.saveGameDataService = saveGameDataService;
        }


        public void MainLoop()
        {


            // TESTING DATA
            Models.Map.Room firstRoom = new Models.Map.Room()
            {
                Name = "Plain Stone Room",
                Description = "The room before you is made of large slabs of stone, that glisten with moisture.  Light is being provided by some unseen source.  Deep down where you are the air is still and dank.  You're unsure how you got here, but it's now up to you to find your way out.  You lean against one of the slick walls, stomach burbling with hunger.  A simple doorway is your only way out that you can see.",
                ShortDescription = "The room is made of large slabs of stone, that glisten with moisture.  The air is still and dank.  A simple doorway is in front of you.",
                Exits = new List<Models.Map.Exit>()
                {
                    new Models.Map.Exit()
                    {
                        Name = "Doorway",
                        Key = "D",
                        
                        


                        //Enter = () =>
                        //{
                        //    if (!GameFlags.Flags.ContainsKey("FIRST_ROOM_TIMES_ENTERED"))
                        //        GameFlags.Flags.Add("FIRST_ROOM_TIMES_ENTERED", 1);

                        //    int timesVisited = (int)GameFlags.Flags["FIRST_ROOM_TIMES_ENTERED"];

                        //    GameFlags.Flags["FIRST_ROOM_TIMES_ENTERED"] = ++timesVisited;
                        //}
                    }
                },
                DescriptionPrintEvent = () =>
                {

                    object timesEntered;

                    if (GameFlags.Flags.TryGetValue("FIRST_ROOM_TIMES_ENTERED", out timesEntered))
                    {

                        if ((int)timesEntered > 3)
                        {
                            return "Wow you must really like this room, you've been here a lot.  ";
                        }
                        else
                            return "";
                    }
                    else
                        return "";

                }

            };


            firstRoom.Exits[0].RoomEntered += (caller, args) =>
            {
                if (!GameFlags.Flags.ContainsKey("FIRST_ROOM_TIMES_ENTERED"))
                    GameFlags.Flags.Add("FIRST_ROOM_TIMES_ENTERED", 1);

                int timesVisited = (int)GameFlags.Flags["FIRST_ROOM_TIMES_ENTERED"];

                GameFlags.Flags["FIRST_ROOM_TIMES_ENTERED"] = ++timesVisited;
            };


            Models.Map.Room secondRoom = new Models.Map.Room()
            {
                Name = "Corridor",
                Description = "A stone corridor lay beyond the doorway.  Even though it's mere steps away, the air here is noticeably less musty and you feel you can take deep breaths without suffocating.  The corridor runs off into the distance, whatever sourceless light not being strong enough to higlight the end fully, but you think there's an archway.",
                ShortDescription = "A stone corridor stretching off into the distance.  You can barely make out a stone archway at the end.",
                Exits = new List<Models.Map.Exit>()
                {
                    new Models.Map.Exit()
                    {
                        Name = "Stone Archway",
                        Key = "S",
                        Destination = firstRoom
                    }
                }
            };

            firstRoom.Exits[0].Destination = secondRoom;

            Models.Player.Player player = new Models.Player.Player()
            {
                Name = "Buster Scruggs",
                HP = 10,
                MaxHP = 10,
                MP = 10,
                MaxMP = 10,
                Age = 17,
                Dexterity = 5,
                Intelligence = 5,
                Strength = 7
            };



            // TODO: Will probably end up with some global flags class
            bool quit = false;

            player.CurrentRoom = firstRoom;

            Screens.ScreenGenerator screenGenerator = new Screens.ScreenGenerator();

            while (!quit)
            {

                Models.Map.Room currentRoom = player.CurrentRoom;


                // Generate the Screen for current room
                var screenActions = screenGenerator.GenerateScreen(player);

                InputHandler inputHandler = new InputHandler();

                var keyInput = Console.ReadKey(true);

                inputHandler.HandleInput(keyInput, player, screenActions);

                

                //if (keyInput.Key == ConsoleKey.Escape)
                //{
                //    quit = true;
                //    Console.WriteLine("");
                //    Console.WriteLine("Thank you for playing!  We hope to see you again soon!", Color.MediumPurple);
                //}
                //else if (keyInput.Key.ToString() == currentRoom.Exits[0].Key)
                //{

                //    // TODO: The issue with events is that only the Exit class can call them, and this cuts to my design and now I have to think about what I really want to do and how I really want to create each screen
                //    //currentRoom.Exits[0].RoomEntered?.Invoke(this, EventArgs.Empty);

                    

                //    player.CurrentRoom = currentRoom.Exits[0].Destination;
                //}
                //else if (keyInput.Key == ConsoleKey.Tab)
                //{
                //    Console.WriteLine("Menu is not accessible right now.", Color.IndianRed);
                //}
                //else
                //{
                //    Console.WriteLine("Invalid command.", Color.IndianRed);
                //}



            }


        }

    }
}
