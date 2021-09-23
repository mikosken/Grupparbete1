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
            WorldMap.PlaceDynamic(96, 3, axe);

            CoinItem coin = new CoinItem(75, '£');
            WorldMap.PlaceDynamic(95, 45, coin);

            var random = new Random();
            for (int i = 0; i < 30; i++)
            {
                int x = random.Next(1, WorldMap.MapWidth - 1);
                int y = random.Next(1, WorldMap.MapHeight - 1);
                if (WorldMap.CanMoveTo(x, y))
                {
                    WorldMap.dynamicMap[x, y] = new NonPlayerCharacter(x, y, WorldMap, random.Next(10) < 3 ? random.Next(10) < 5 ? "goblin" : "skeleton" : "bat");
                }
            }
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
                if (IsVictory())
                {
                    DrawVictoryScreen();
                    break;
                }
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
            if (Player.CoinPurse >= 100) return true;

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
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("A WINNER IS YOU!");
            Console.WriteLine("YOU FOUND ENOUGH COINS TO RETIRE IN LUXURY!");
        }

        public int DrawStartScreen()
        {
            Console.WriteLine();
            Console.WriteLine("You are a brave adventurer searching for loot so that you may retire in luxury.");
            Console.WriteLine();
            Console.WriteLine("You have entered an ancient dungeon filled with monsters that drop coins when");
            Console.WriteLine("they are defeated.");
            Console.WriteLine("And somewhere inside is a treasure chest with enough gold to set you for life,");
            Console.WriteLine("if the monsters won't sate your lust for gold.");
            Console.WriteLine();
            Console.WriteLine("Symbols:");
            Console.WriteLine("@: A fearless adventurer, this is you.");
            Console.WriteLine();
            Console.WriteLine("b: Bat, an enemy on the weaker side.");
            Console.WriteLine("g: Goblin, a fearsome foe!");
            Console.WriteLine("s: Skeleton, can occasionally deal even more damage than a goblin so take care.");
            Console.WriteLine();
            Console.WriteLine("£: A great treasure of gold coins.");
            Console.WriteLine("$: Dropped gold coins.");
            Console.WriteLine("+: Sword, quite useful.");
            Console.WriteLine("!: Axe, a powerful weapon.");
            Console.WriteLine(">: Shovel, weak as a weapon but useful when nothing else is available.");
            Console.WriteLine("X: Potion, use this to heal your wounds.");
            Console.WriteLine();
            Console.WriteLine("Use w/a/s/d-keys to move around. Select equipment with 1-5. Use selected potion with 'u'.");

            ConsoleKeyInfo input;
            input = new ConsoleKeyInfo();

            while (input.Key != ConsoleKey.Spacebar)
            {
                // Implement possible menu-choices here.
                Console.WriteLine();
                Console.WriteLine("Press space to continue.");
                input = Console.ReadKey(true);
            }

            return 0;
        }
    }
}