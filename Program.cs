using System;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt user for their name
            Console.WriteLine("Please enter your name:");
            string playerName = Console.ReadLine().Trim();

            // If no name is entered, set a default name
            if (string.IsNullOrEmpty(playerName))
            {
                playerName = "Sparring Warrior";
            }

            // Create a new game with the player's name
            Game game = new Game(playerName);
            game.Start();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
