using System;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name, Adventurer: ");
            string playerName = Console.ReadLine().Trim();

            // Ensure the player enters a valid name
            while (string.IsNullOrEmpty(playerName))
            {
                Console.Write("Name cannot be empty. Please enter your name: ");
                playerName = Console.ReadLine().Trim();
            }

            // Start the game
            Game game = new Game(playerName);
            game.Start();

            // Wait before exiting
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
