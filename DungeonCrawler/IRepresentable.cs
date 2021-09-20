using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal interface IRepresentable
    {
        public char Representation { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}