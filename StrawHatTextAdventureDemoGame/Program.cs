using StrawHatTextAdventureEngine;
using StrawHatTextAdventureEngine.Models.Game;
using StrawHatTextAdventureEngine.Models.Map;
using StrawHatTextAdventureEngine.Models.Player;
using System;
using System.Collections.Generic;

namespace StrawHatTextAdventureDemoGame
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create new Demo Game Engine
            GameData demoGameData = GetDemoGameData();

            GameEngine gameEngine = new GameEngine(demoGameData, new());

            gameEngine.StartGame();
        }


        private static GameData GetDemoGameData()
        {

            const string GAME_FLAGS_FIRST_ROOM_TIMES_ENTERED = "FIRST_ROOM_TIMES_ENTERED";


            // TESTING DATA
            Room firstRoom = new Room()
            {
                Name = "Plain Stone Room",
                Description = "The room before you is made of large slabs of stone, that glisten with moisture.  Light is being provided by some unseen source.  Deep down where you are the air is still and dank.  You're unsure how you got here, but it's now up to you to find your way out.  You lean against one of the slick walls, stomach burbling with hunger.  A simple doorway is your only way out that you can see.",
                ShortDescription = "The room is made of large slabs of stone, that glisten with moisture.  The air is still and dank.  A simple doorway is in front of you.",
                Exits = new List<Exit>()
                {
                    new Exit()
                    {
                        Name = "Doorway",
                        Key = "D",
                    }
                },
                DescriptionPrinting = () =>
                {

                    if (GameFlags.Flags.TryGetValue(GAME_FLAGS_FIRST_ROOM_TIMES_ENTERED, out object timesEntered))
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


            firstRoom.Exits[0].ExitUsed += (caller, args) =>
            {
                if (!GameFlags.Flags.ContainsKey(GAME_FLAGS_FIRST_ROOM_TIMES_ENTERED))
                    GameFlags.Flags.Add(GAME_FLAGS_FIRST_ROOM_TIMES_ENTERED, 1);

                int timesVisited = (int)GameFlags.Flags[GAME_FLAGS_FIRST_ROOM_TIMES_ENTERED];

                GameFlags.Flags[GAME_FLAGS_FIRST_ROOM_TIMES_ENTERED] = ++timesVisited;
            };


            Room secondRoom = new Room()
            {
                Name = "Corridor",
                Description = "A stone corridor lay beyond the doorway.  Even though it's mere steps away, the air here is noticeably less musty and you feel you can take deep breaths without suffocating.  The corridor runs off into the distance, whatever sourceless light not being strong enough to higlight the end fully, but you think there's an archway.",
                ShortDescription = "A stone corridor stretching off into the distance.  You can barely make out a stone archway at the end.",
                Exits = new List<Exit>()
                {
                    new Exit()
                    {
                        Name = "Back",
                        Key = "B",
                        Destination = firstRoom
                    }
                }
            };

            firstRoom.Exits[0].Destination = secondRoom;


            Room thirdRoom = new Room()
            {
                Name = "Musty Fountain",
                Description = "Before you is an ancient stone fountain that gives off a very dank smell.  It smells like mold has been building for years.  Water flows from a diamond shaped cutout above a stone pool that's wide enough to fit your entire body three times over.",
                ShortDescription = "An ancient stone fountain pours water into a stone basin, giving off a musty scent.  Water flows from a diamond shaped cutout in the wall.",
                Exits = new List<Exit>()
                {
                    new Exit()
                    {
                        Name = "Corridor",
                        Key = "C",
                        Destination = secondRoom
                    }
                }

            };

            secondRoom.Exits.Add(new Exit()
            {
                Name = "Stone Archway",
                Key = "S",
                Destination = thirdRoom
            });



            Player player = new Player()
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

            GameData gameData = new GameData()
            {
                Player = player,
                StartingRoom = firstRoom
            };

            return gameData;

        }


    }
}
