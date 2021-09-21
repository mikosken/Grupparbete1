using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class PlayerCharacter : Character
    {
        private List<object> Inventory;
        private int coinPurse = 0;

        public PlayerCharacter(int x, int y, DungeonMap map, char representation) : base(x, y, map)
        {
            Representation = representation;
            Inventory = new List<object>();
        }

        public void AddCoins(int coins)
        {
            inventory
        }

        public void SubtractCoins(int coins)
        {
            throw new NotImplementedException();
        }

        override public void NextAction()
        {
            throw new NotImplementedException();
        }
    }
}