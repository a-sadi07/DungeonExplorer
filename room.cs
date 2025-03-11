namespace DungeonExplorer
{
    public class Room
    {
        public string Description { get; private set; }
        public string Item { get; private set; }

        public Room(string description)
        {
            Description = description;
            Item = null;
        }

        public string GetDescription() => Description;

        public void AddItem(string item)
        {
            Item = item;
        }

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

        public void RemoveItem()
        {
            Item = null;
        }
    }
}
