namespace DungeonExplorer
{
    public class Room
    {
        public string Description { get; private set; }
        public string Item { get; private set; }

        // Constructor initializes room description
        public Room(string description)
        {
            Description = description;
            Item = null; // Initially no item in the room
        }

        // Method to get the description of the room
        public string GetDescription()
        {
            return Description;
        }

        // Add an item to the room
        public void AddItem(string item)
        {
            Item = item;
        }

        // Display the item in the room, if there is one
        public void DisplayItem()
        {
            if (!string.IsNullOrEmpty(Item))
            {
                Console.WriteLine($"You see a {Item} in the room.");
            }
            else
            {
                Console.WriteLine("There's nothing of interest in this room.");
            }
        }

        // Remove the item from the room
        public void RemoveItem()
        {
            Item = null;
        }
    }
}
