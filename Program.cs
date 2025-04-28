using System;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) name = "Adventurer";

            Game game = new Game(name);
            game.Start();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
