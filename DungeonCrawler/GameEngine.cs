using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class GameEngine
    {
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }
        public DungeonMap WorldMap;
        public PlayerCharacter Player;

        public GameEngine()
        {
            //UpdateWindowSize();
            WindowWidth = 100;
            WindowHeight = 50;
            Console.WindowWidth = WindowWidth;
            Console.WindowHeight = WindowHeight;

            WorldMap = new DungeonMap(WindowWidth, WindowHeight - 3);
            Player = new PlayerCharacter(2, 2, WorldMap, '@');

            WorldMap.PlaceDynamic(2, 2, Player);

            // place equipment on map TEST
            Equipment sword = new Equipment("sword");
            WorldMap.PlaceDynamic(87, 45, sword);

            Equipment potion = new Equipment("potion");
            WorldMap.PlaceDynamic(85, 45, potion);
            WorldMap.PlaceDynamic(11, 26, potion);
            WorldMap.PlaceDynamic(14, 20, potion);
            WorldMap.PlaceDynamic(45, 39, potion);
            WorldMap.PlaceDynamic(44, 12, potion);
            WorldMap.PlaceDynamic(96, 3, potion);

            Equipment axe = new Equipment("axe");
            WorldMap.PlaceDynamic(84, 27, axe);

            CoinItem coin = new CoinItem(75, '£');
            WorldMap.PlaceDynamic(95, 45, coin);
        }

        public void MainLoop()
        {
            ConsoleKeyInfo input;
            input = new ConsoleKeyInfo();

            while (input.Key != ConsoleKey.Escape)
            {
                //Console.WindowHeight = WindowHeight;
                //Console.WindowWidth = WindowWidth;
                // Check victory condition.
                //if (IsVictory()) DrawVictoryScreen();
                // Check Game Over conditions.
                //if (IsGameOver()) DrawGameOver();

                // Do enemy actions.

                // Do player actions.
                if (!Player.HandleInput(input.KeyChar))
                {
                    Player.Move(input.KeyChar);
                }
                WorldMap.NextTurn(input);
                WorldMap.DrawMap();

                Console.WriteLine(Player.GetInventoryString());
                Console.WriteLine(Player.GetStatusString());

                // Determine possible actions for player.
                // Write possible actions to console.
                // Get input.
                input = Console.ReadKey(true);
            }
        }

        /// <summary>
        /// Uppdates the size of the console window.
        /// </summary>
        private void UpdateWindowSize()
        {
            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;
        }

        // World Map object.

        // Interface text.

        /// <summary>
        /// Draws new data to console window.
        /// </summary>
        public void DrawWindow()
        {
            WorldMap.DrawMap();
        }

        public bool IsVictory()
        {
            throw new NotImplementedException();

            return false;
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();

            return false;
        }

        public void DrawGameOver()
        {
            throw new NotImplementedException();
        }

        public void DrawVictoryScreen()
        {
            throw new NotImplementedException();
        }
    }
}