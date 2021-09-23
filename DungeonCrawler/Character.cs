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

        public int CoinPurse { get; set; }

        protected DungeonMap map;

        public Character(int x, int y, DungeonMap map)
        {
            PositionX = x;
            PositionY = y;
            this.map = map;
            Health = 100;
            MaxHealth = 100;
        }

        public Character(int x, int y, DungeonMap map, int health, int maxHealth)
        {
            PositionX = x;
            PositionY = y;
            this.map = map;
            Health = health;
            MaxHealth = maxHealth;
        }

        public virtual (int x, int y) Move(char direction)
        {
            (int newX, int newY) = map.Move(PositionX, PositionY, direction);

            return (newX, newY);
        }

        public abstract void NextAction();

        public void Damage(int damage)
        {
            Health -= damage;

            if (Health < 0)
                Health = 0;

            if (Health == 0)
            {
                // dö
                OnDeath();
            }
        }

        public void Heal(int hp)
        {
            throw new NotImplementedException();
        }

        public virtual void OnDeath()
        {
            map.RemoveDynamic(PositionX, PositionY);
        }

        public void AddCoins(int coins)
        {
            CoinPurse += coins;
        }

        public void SubtractCoins(int coins)
        {
            throw new NotImplementedException();
        }
    }
}