using System;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new game with a player named "Adventurer"
            Game game = new Game("Adventurer");

            // Start the game
            game.Start();

            // Wait for the user to press a key before exiting
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
