using System;

namespace DungeonExplorer
{
    public class Room
    {
        public string Description { get; private set; }
        public string Item { get; private set; }

        // Constructor initializes the room description
        public Room(string description)
        {
            Description = description;
            Item = null; // No item initially
        }

        // Get the room's description
        public string GetDescription()
        {
            return Description;
        }

        // Add an item to the room
        public void AddItem(string item)
        {
            Item = item;
        }

        // Display the item in the room
        public void DisplayItem()
        {
            Console.WriteLine(!string.IsNullOrEmpty(Item) ? $"You see a {Item} in the room." : "There's nothing of interest here.");
        }

        // Remove the item from the room
        public void RemoveItem()
        {
            Item = null;
        }
    }
}
