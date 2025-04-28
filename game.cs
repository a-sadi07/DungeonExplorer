using System;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private GameMap map;

        public Game(string playerName)
        {
            player = new Player(playerName, 100);
            map = new GameMap();
        }

        public void Start()
        {
            Console.WriteLine($"\nWelcome {player.Name}, to the Dungeon Explorer!");
            Console.WriteLine("Your journey begins...");
            StartGameLoop();
        }
            private void CheckStrongestDragon()
{
    var dragons = map.GetAllMonsters()
                     .OfType<Dragon>()
                     .OrderByDescending(d => d.Health + d.Damage)
                     .ToList();

    if (dragons.Count == 0)
    {
        Console.WriteLine("There are no dragons in the dungeon.");
    }
    else
    {
        var strongest = dragons.First();
        Console.WriteLine($"The strongest dragon is {strongest.Name} with {strongest.Health} HP and {strongest.Damage} damage.");
    }
}


        private void StartGameLoop()
        {
            
            bool isPlaying = true;

            while (isPlaying && player.Health > 0)
            {
                Room currentRoom = map.GetCurrentRoom();
                Console.WriteLine($"\n{currentRoom.GetDescription()}");
                currentRoom.DisplayItem();
                currentRoom.DisplayMonster();

                Console.WriteLine("\nChoose an action: move, collect, attack, use, status, quit");
                string command = Console.ReadLine()?.Trim().ToLower();

                switch (command)
                {
                    case "move":
                        Console.WriteLine("Available rooms: " + string.Join(", ", map.GetRoomNames()));
                        Console.WriteLine("Enter room name:");
                        string target = Console.ReadLine()?.Trim().ToLower();
                        if (!map.MoveToRoom(target)) Console.WriteLine("Invalid room name!");
                        break;
                    case "collect":
                        if (currentRoom.Item != null)
                        {
                            player.Inventory.Add(currentRoom.Item);
                            Console.WriteLine($"You collected a {currentRoom.Item.Name}.");
                            currentRoom.RemoveItem();
                        }
                        else Console.WriteLine("No items to collect.");
                        break;
                    case "attack":
                        if (currentRoom.Monster != null)
                        {
                            player.Attack(currentRoom.Monster);
                            if (currentRoom.Monster.Health <= 0)
                            {
                                Console.WriteLine($"You defeated the {currentRoom.Monster.Name}!");
                                currentRoom.RemoveMonster();
                            }
                            else
                            {
                                currentRoom.Monster.Attack(player);
                                if (player.Health <= 0) Console.WriteLine("You have fallen in battle...");
                            }
                        }
                        else Console.WriteLine("No monster to attack.");
                        break;
                    case "use":
                        Console.WriteLine("Enter item name to use:");
                        string itemName = Console.ReadLine();
                        player.UseItem(itemName);
                        break;
                    case "status":
                        player.DisplayStatus();
                        break;
                    case "quit":
                        isPlaying = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command. Try: move, collect, attack, use, status, quit.");
                        break;
                        case "strongest":
                            CheckStrongestDragon();
                        break;
                }
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("\nGAME OVER. Better luck next time!");
            }
            
        }
    }
}
