using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    class Equipment : IRepresentable
    {
        public string Name { get; set; }
        public string UseVerb { get; set; } // "Swing", "Drink", etc.
        public char Representation { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public int Damage { get; set; }
        public int Heal { get; set; }

        public Equipment(string type) {
            switch (type) {
                case "sword":
                    Name = "Sword";
                    UseVerb = "Swing";
                    Representation = '+';
                    Damage = 50;
                    Heal = 0;
                    break;
            }

        }
    }
}
