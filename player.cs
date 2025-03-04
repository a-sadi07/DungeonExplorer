using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory;

        // Constructor to initialize the player
        public Player(string name, int health)
        {
            Name = name;
            Health = health;
            inventory = new List<string>();
        }

        // Pick up an item and add it to inventory
        public void PickUpItem(string item)
        {
            inventory.Add(item);
            Console.WriteLine($"{Name} picked up a {item}.");
        }

        // Display player's status
        public void DisplayStatus()
        {
            Console.WriteLine($"\nPlayer: {Name}\nHealth: {Health}\nInventory: {InventoryContents()}");
        }

        // Return inventory contents as a formatted string
        private string InventoryContents()
        {
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Nothing";
        }
    }
}
