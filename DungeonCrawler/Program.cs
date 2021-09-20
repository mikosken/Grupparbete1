using System;

namespace DungeonCrawler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Initialize();
            GameEngine gm = new GameEngine();
            gm.MainLoop();

            // DeInitialize();
        }
    }
}