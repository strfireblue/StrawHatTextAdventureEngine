using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrawHatTextAdventureEngine.Services.Game;

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
                Name = "First Room",
                Description = "The room before you is made of large slabs of stone, that glisten with moisture.  Deep down where you are the air is still and dank.  Light is being provided by some unseen source.",
                ShortDescription = "The First Room glistens in holy wonder.",
                Exits = new List<Models.Map.Exit>()
                {
                    new Models.Map.Exit()
                    {
                        Name = "Doorway",
                        Key = "D",
                        
                        EnterCallback = () =>
                        {
                            if (!GameFlags.Flags.ContainsKey("FIRST_ROOM_TIMES_ENTERED"))
                                GameFlags.Flags.Add("FIRST_ROOM_TIMES_ENTERED", 1);

                            int timesVisited = (int)GameFlags.Flags["FIRST_ROOM_TIMES_ENTERED"];

                            GameFlags.Flags["FIRST_ROOM_TIMES_ENTERED"] = ++timesVisited;
                        }
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


            Models.Map.Room secondRoom = new Models.Map.Room()
            {
                Name = "Second Room",
                Description = "This is the Second Room.  The author got tired of dictating what should be before your very eyes.",
                ShortDescription = "The Second Room is even chillier than the first.",
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

            // TODO: Probably wouldn't do this
            Models.Map.Room currentRoom = firstRoom;

            while (!quit)
            {

                // Generate the room data

                // TODO: Need a class for this to vary between this and possibl eaudio output, etc.  Some color console writer, too.
                Console.WriteLine(currentRoom.GetDescription());

                Console.WriteLine("");
                Console.WriteLine("Exits: ");


                StringBuilder exitString = new StringBuilder();

                foreach (var exit in currentRoom.Exits)
                {
                    exitString.AppendLine($"({exit.Key}) {exit.Name} ");
                }

                exitString.Remove(exitString.Length - 2, 2);

                Console.Write(exitString.ToString());

                Console.WriteLine("");
                Console.WriteLine("");

                // Generate menu items

                var keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.Escape)
                    quit = true;
                else if (keyInput.Key.ToString() == currentRoom.Exits[0].Key)
                {

                    currentRoom.Exits[0].EnterCallback?.Invoke();

                    currentRoom = currentRoom.Exits[0].Destination;
                }

                // Wait for input

                // Handle input


            }


        }

    }
}
