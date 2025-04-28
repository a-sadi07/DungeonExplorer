using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        public string Name { get; }
        private string description;
        public ICollectible Item { get; private set; }
        public Monster Monster { get; private set; }

        public Room(string name, string description)
        {
            Name = name;
            this.description = description;
        }

        public void SetItem(ICollectible item) => Item = item;
        public void RemoveItem() => Item = null;

        public void SetMonster(Monster monster) => Monster = monster;
        public void RemoveMonster() => Monster = null;

        public string GetDescription() => description;

        public void DisplayItem()
        {
            if (Item != null)
                Console.WriteLine($"There is a {Item.Name} here.");
        }

        public void DisplayMonster()
        {
            if (Monster != null)
                Console.WriteLine($"A {Monster.Name} blocks your path!");
        }
    }

    public class GameMap
    {
        private Dictionary<string, Room> rooms;
        private string currentRoomKey;
  public IEnumerable<Monster> GetAllMonsters()
                {
                    return rooms.Values
                                .Where(r => r.Monster != null)
                                .Select(r => r.Monster);
                }
        public GameMap()
        {
            rooms = new Dictionary<string, Room>
            {
                { "inception", new Room("inception", "A mystry box on the table.") },
                { "hobbit", new Room("", "A dark and spooky room with full of weapon") },
                { "maze", new Room("maze", "A hungry Dragon waiting for his dinner") },
                { "snaghold", new Room("snaghold", "Kingdom of Goblin.") }
            };

            rooms["inception"].SetItem(new Potion("Healing Potion", 20));
            rooms["hobbit"].SetItem(new Weapon("Rusty Sword", 10));
            rooms["maze"].SetMonster(new Dragon("Red Dragon", 50, 20));
            rooms["snaghold"].SetMonster(new Goblin("Sneaky Goblin", 20, 5));

            currentRoomKey = "inception";
        }
          

        public Room GetCurrentRoom() => rooms[currentRoomKey];

        public bool MoveToRoom(string key)
        {
            if (rooms.ContainsKey(key))
            {
                currentRoomKey = key;
                return true;
            }
            return false;
        }

        public IEnumerable<string> GetRoomNames() => rooms.Keys;
    }
}
