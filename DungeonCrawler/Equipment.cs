using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    class Equipment : IRepresentable
    {
        string Name { get; set; }
        string UseVerb { get; set; } // "Swing", "Drink", etc.
        public char Representation { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}
