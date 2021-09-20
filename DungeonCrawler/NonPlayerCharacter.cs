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

        public override void NextAction()
        {
            throw new NotImplementedException();
        }

        public void OnDeath()
        {
            // Drop loot and remove NPC here.
            throw new NotImplementedException();
        }
    }
}