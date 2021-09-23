using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class Equipment : IRepresentable
    {
        public string Name { get; set; }
        public string UseVerb { get; set; } // "Swing", "Drink", etc.
        public char Representation { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public int Damage { get; set; }
        public int Heal { get; set; }

        public Equipment(string type)
        {
            switch (type)
            {
                case "sword":
                    Name = "Sword";
                    UseVerb = "Swing";
                    Representation = '+';
                    Damage = 50;
                    Heal = 0;
                    break;

                case "axe":
                    Name = "Axe";
                    UseVerb = "Chop";
                    Representation = '9';
                    Damage = 60;
                    Heal = 0;
                    break;

                case "shovel":
                    Name = "Shovel";
                    UseVerb = "Swipe";
                    Representation = 'f';
                    Damage = 10;
                    Heal = 0;
                    break;

                case "potion":
                    Name = "Potion";
                    UseVerb = "Drink";
                    Representation = 'v';
                    Damage = 0;
                    Heal = 50;
                    break;

                default:
                    throw new ArgumentException("No such equipment!");
            }
        }
    }
}