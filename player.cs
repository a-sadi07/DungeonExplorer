using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory;

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
            inventory = new List<string>();
        }

        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Player: {Name}, Health: {Health}, Inventory: {InventoryContents()}");
        }

        private string InventoryContents()
        {
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Nothing";
        }
    }
}
