using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class DungeonMap
    {
        public int MapWidth { get; set; }
        public int MapHeight { get; set; }
        public string MapRepresentation { get; set; }

        private MapTile[,] staticMap; // Walls, floors, etc.
        private IRepresentable[,] dynamicMap; // Stuff that move or change, player, monsters, items, etc.

        public bool PlaceDynamic(int x, int y, IRepresentable representable)
        {
            if (IsInBounds(x, y) && dynamicMap[x, y] == null)
            {
                dynamicMap[x, y] = representable;
                return true;
            }
            return false;
        }

        public DungeonMap(int mapWidth, int mapHeight)
        {
            MapWidth = mapWidth;
            MapHeight = mapHeight;

            staticMap = new MapTile[MapWidth, MapHeight];
            dynamicMap = new IRepresentable[MapWidth, MapHeight];

            DefaultMap();
        }

        public void DrawMap()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(GetRepresentation());
        }

        public string GetRepresentation()
        {
            StringBuilder sb = new StringBuilder();

            for (int j = 0; j < MapHeight; j++)
            {
                for (int i = 0; i < MapWidth; i++)
                {
                    if (dynamicMap[i, j] != null)
                    {
                        sb.Append(dynamicMap[i, j].Representation);
                    }
                    else
                    {
                        sb.Append(staticMap[i, j].Representation);
                    }
                }
                if (j < MapHeight - 1) sb.Append('\n');
            }
            return sb.ToString();
        }

        public bool Move(int fromX, int fromY, int toX, int toY)
        {
            if (!IsInBounds(fromX, fromY) ||
                !IsInBounds(toX, toY) ||
                dynamicMap[fromX, fromY] == null ||
                dynamicMap[toX, toY] != null ||
                !staticMap[toX, toY].Walkable
                ) return false;

            dynamicMap[toX, toY] = dynamicMap[fromX, fromY];
            dynamicMap[toX, toY].PositionX = toX;
            dynamicMap[toX, toY].PositionY = toY;
            dynamicMap[fromX, fromY] = null;
            return true;
        }


        /// <summary>
        /// Controls for the main character.
        /// </summary>
        public bool Move(int fromX, int fromY, char direction)
        {
            //u, d, l, r
            int toX = fromX;
            int toY = fromY;
            switch (direction)
            {
                case 'w':
                    toX = fromX;
                    toY = fromY - 1;
                    break;

                case 's':
                    toX = fromX;
                    toY = fromY + 1;
                    break;

                case 'a':
                    toX = fromX - 1;
                    toY = fromY;
                    break;

                case 'd':
                    toX = fromX + 1;
                    toY = fromY;
                    break;

                default:
                    return false;
            }
            return Move(fromX, fromY, toX, toY);
        }

        /// <summary>
        /// Iplementing where the Characters can go.
        /// </summary>
        public bool CanMoveTo(int x, int y)
        {
            return IsInBounds(x, y) && staticMap[x, y].Walkable && dynamicMap[x, y] == null;
        }

        public void DefaultMap()
        {
            BuildStaticRect(0, 0, MapWidth, MapHeight, new MapTile("wall"), new MapTile("wall"));
            BuildStaticRect(0, 0, MapWidth, MapHeight, new MapTile("wall"), new MapTile("floor"));
            BuildStaticRect(5, 5, 5, 5, new MapTile("wall"), new MapTile("floor"));

            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(1, MapWidth - 1);
                int y = random.Next(1, MapHeight - 1);
                if (CanMoveTo(x, y))
                {
                    dynamicMap[x, y] = new NonPlayerCharacter(x, y, this, 'e');
                }
            }
        }

        public bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < MapWidth && y >= 0 && y < MapHeight;
        }

        public bool BuildStaticRect(int x, int y, int width, int height, MapTile borderTile, MapTile fillTile)
        {
            // Are we outside the bounds of the map?
            // If so, return false.
            if (!IsInBounds(x, y) || !IsInBounds(x + width - 1, y + height - 1))
                return false;
            // Else, place tiles in staticMap.
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (j == 0 || j == height - 1 || i == 0 || i == width - 1)
                    {
                        // Place border tile.
                        staticMap[x + i, y + j] = (MapTile)borderTile.Clone();
                    }
                    else
                    {
                        // Place fill tile.
                        staticMap[x + i, y + j] = (MapTile)fillTile.Clone();
                    }
                }
            }
            return true;
        }
    }
}