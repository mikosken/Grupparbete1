using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class NonPlayerCharacter : Character
    {
        private IRepresentable loot;

        public NonPlayerCharacter(int x, int y, DungeonMap map, char representation) : base(x, y, map)
        {
            Representation = representation;

            // Randomize loot?
            loot = new CoinItem();
        }

        public override void NextAction() {
            var random = new Random();

            var directions = new char[] { 'w', 's', 'a', 'd' };

            map.Move(PositionX, PositionY, directions[random.Next(0, directions.Length)]);
        }

    }
}