using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Dictionary<string, Room> rooms;
        private Room currentRoom;

        // Constructor to initialize player and rooms
        public Game(string playerName)
        {
            player = new Player(playerName, 100);

            // Creating rooms and adding items
            rooms = new Dictionary<string, Room>();
            var room1 = new Room("A dark and spooky room.");
            var room2 = new Room("A room filled with treasures.");
            room1.AddItem("Sword");
            room2.AddItem("Golden Coin");

            // Adding rooms to the game world
            rooms.Add("room1", room1);
            rooms.Add("room2", room2);

            // Start in the first room
            currentRoom = room1;
        }

        // Start the game with a welcome message
        public void Start()
        {
            Console.WriteLine($"Welcome to Dungeon Explorer, {player.Name}!");
            StartGameLoop();
        }

        // Main game loop for player actions
        public void StartGameLoop()
        {
            bool isPlaying = true;

            while (isPlaying)
            {
                // Show room info and ask for player action
                Console.WriteLine("\nWhat would you like to do? (pick up, move, status, quit)");
                string command = Console.ReadLine().ToLower();

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
                        Console.WriteLine("Thanks for playing!");
                        isPlaying = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command. Try again.");
                        break;
                }
            }
        }

        // Show the description of the current room and any items in it
        private void DisplayCurrentRoomInfo()
        {
            Console.WriteLine(currentRoom.GetDescription());
            currentRoom.DisplayItem();
        }

        // Handle picking up items in the room
        private void PickUpItemInRoom()
        {
            if (!string.IsNullOrEmpty(currentRoom.Item))
            {
                player.PickUpItem(currentRoom.Item);
                currentRoom.RemoveItem();
                Console.WriteLine($"You picked up the {currentRoom.Item}.");
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
            string roomChoice = Console.ReadLine().ToLower();

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
