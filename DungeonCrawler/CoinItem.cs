﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class CoinItem : IRepresentable
    {
        private int Value { get; set; }
        public char Representation { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public CoinItem(int value, char representation)
        {
            Value = value;
            Representation = representation;
        }

        public CoinItem()
        {
            Value = 1;
            Representation = '$';
        }
    }
}