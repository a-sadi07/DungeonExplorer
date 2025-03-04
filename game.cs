using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Dictionary<string, Room> rooms;
        private Room currentRoom;

        // Constructor initializes player and rooms
        public Game(string playerName)
        {
            player = new Player(playerName, 100);

            // Creating rooms and adding items
            rooms = new Dictionary<string, Room>
            {
                { "room1", new Room("A dark and spooky room.") },
                { "room2", new Room("A room filled with treasures.") }
            };

            // Assign items to rooms
            rooms["room1"].AddItem("Sword");
            rooms["room2"].AddItem("Golden Coin");

            // Set the starting room
            currentRoom = rooms["room1"];
        }

        // Start the game
        public void Start()
        {
            Console.WriteLine($"\nWelcome to Dungeon, {player.Name}!");
            DisplayCurrentRoomInfo();
            StartGameLoop();
        }

        // Main game loop
        private void StartGameLoop()
        {
            bool isPlaying = true;

            while (isPlaying)
            {
                Console.WriteLine("\nWhat would you like to do? (pick up, move, status, quit)");
                string command = Console.ReadLine().Trim().ToLower();

                switch (command)
                {
                    case "pick up":
                        PickUpItemInRoom();
                        break;
                    case "move":
                        MoveToAnotherRoom();
                        break;
                    case "status":
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

        // Display the current room's description and items
        private void DisplayCurrentRoomInfo()
        {
            Console.WriteLine($"\n{currentRoom.GetDescription()}");
            currentRoom.DisplayItem();
        }

        // Allow player to pick up an item in the current room
        private void PickUpItemInRoom()
        {
            if (!string.IsNullOrEmpty(currentRoom.Item))
            {
                string item = currentRoom.Item;
                player.PickUpItem(item);
                currentRoom.RemoveItem();
            }
            else
            {
                Console.WriteLine("There's nothing to pick up in this room.");
            }
        }

        // Allow the player to move between rooms
        private void MoveToAnotherRoom()
        {
            Console.WriteLine("Where would you like to go? (room1, room2)");
            string roomChoice = Console.ReadLine().Trim().ToLower();

            if (rooms.ContainsKey(roomChoice))
            {
                currentRoom = rooms[roomChoice];
                DisplayCurrentRoomInfo();
            }
            else
            {
                Console.WriteLine("Invalid room choice. Try again.");
            }
        }
    }
}
