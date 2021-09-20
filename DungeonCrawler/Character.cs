using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal abstract class Character : IRepresentable
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public string Name { get; set; }
        public char Representation { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        protected DungeonMap map;

        public Character(int x, int y, DungeonMap map)
        {
            PositionX = x;
            PositionY = y;
            this.map = map;
        }

        public void Move(char direction)
        {
            map.Move(PositionX, PositionY, direction);
        }

        abstract public void NextAction();

        public void Damage(int damage)
        {
            throw new NotImplementedException();
        }

        public void Heal(int hp)
        {
            throw new NotImplementedException();
        }
    }
}