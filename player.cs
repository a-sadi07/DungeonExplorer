using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory;

        // Constructor to initialize the player's name, health, and inventory
        public Player(string name, int health)
        {
            Name = name;
            Health = health;
            inventory = new List<string>();
        }

        // Method to pick up items and add them to the player's inventory
        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }

        // Method to display the player's current status (name, health, and inventory)
        public void DisplayStatus()
        {
            Console.WriteLine($"Player: {Name}, Health: {Health}, Inventory: {InventoryContents()}");
        }

        // Returns the player's inventory contents as a comma-separated string
        public string InventoryContents()
        {
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Nothing";
        }
    }
}
