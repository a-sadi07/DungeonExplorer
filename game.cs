using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Dictionary<string, Room> rooms;
        private Room currentRoom;

        public Game(string playerName)
        {
            player = new Player(playerName, 100);
            rooms = new Dictionary<string, Room>
            {
                { "room1", new Room("A dark and spooky room.") },
                { "room2", new Room("A room full of gold. Do you want to take some?") }
            };

            rooms["room1"].AddItem("Sword");
            rooms["room2"].AddItem("Golden Coin");

            currentRoom = rooms["room1"];
        }

        public void Start()
        {
            Console.WriteLine($"\nWelcome to Dungeon Explorer, {player.Name}!");
            DisplayCurrentRoomInfo();
            StartGameLoop();
        }

        private void StartGameLoop()
        {
            bool isPlaying = true;

            while (isPlaying)
            {
                Console.WriteLine("\nWhat action will you take? (collect, move, check status, quit)");
                
                // Added null check and validation for input
                string command = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine("Invalid command. Try again.");
                    continue;
                }

                switch (command)
                {
                    case "collect":
                        PickUpItemInRoom();
                        break;
                    case "move":
                        MoveToAnotherRoom();
                        break;
                    case "check status":
                        player.DisplayStatus();
                        break;
                    case "quit":
                        Console.WriteLine("Thanks for playing! Goodbye!");
                        isPlaying = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command. Try again.");
                        break;
                }
            }
        }

        private void DisplayCurrentRoomInfo()
        {
            Console.WriteLine($"\n{currentRoom.GetDescription()}");
            currentRoom.DisplayItem();
        }

        private void PickUpItemInRoom()
        {
            if (!string.IsNullOrEmpty(currentRoom.Item))
            {
                string item = currentRoom.Item;
                player.PickUpItem(item);
                currentRoom.RemoveItem();

                // Check if the item collected is the sword
                if (item.Equals("Sword", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Well done! You collected the Sword.");
                }
                else
                {
                    Console.WriteLine($"You collected the {item}.");
                }
            }
            else
            {
                Console.WriteLine("There's nothing to collect in this room.");
            }
        }

        private void MoveToAnotherRoom()
        {
            Console.WriteLine("Which place would you like to explore? [Room1 or Room2]");
            
            // Added null check and validation for room input
            string roomChoice = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(roomChoice) || !rooms.ContainsKey(roomChoice))
            {
                Console.WriteLine("Invalid room choice. Try again.");
            }
            else
            {
                currentRoom = rooms[roomChoice];
                DisplayCurrentRoomInfo();
            }
        }
    }
}
