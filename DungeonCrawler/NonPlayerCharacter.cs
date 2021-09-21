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

        public (int x, int y) FindPlayerCoordinates()
        {
            int w = map.dynamicMap.GetLength(0); // width
            int h = map.dynamicMap.GetLength(1); // height

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (map.dynamicMap[x, y] != null && map.dynamicMap[x, y].GetType() == typeof(PlayerCharacter))
                    {
                        return (x, y);
                    }
                }
            }

            return (-1, -1);
        }

        public int PlayerDistance()
        {
            int distance = -1;
            (int playerX, int playerY) = FindPlayerCoordinates();
            if (playerX >= 0 && playerY >= 0)
            {
                distance = (int)Math.Sqrt(Math.Abs(Math.Pow(playerY - PositionY, 2) + Math.Pow(playerX - PositionX, 2)));
            }
            return distance;
        }

        public char PlayerDirection()
        {
            (int playerX, int playerY) = FindPlayerCoordinates();
            if (playerX < 0 && playerY < 0)
            {
                return 'x'; // Error.
            }

            int deltaX = playerX - PositionX;
            int deltaY = playerY - PositionY;

            if (Math.Abs(deltaX) >= Math.Abs(deltaY))
            {
                // Move horizontally.
                if (deltaX <= 0)
                {
                    return 'a'; //Left.
                }
                else
                {
                    return 'd'; //Right.
                }
            }
            else
            {
                // Move vertically.
                if (deltaY <= 0)
                {
                    return 'w'; //Up.
                }
                else
                {
                    return 's'; //Down.
                }
            }
        }

        public override void NextAction()
        {
            int damage = 35;

            var random = new Random();
            var directions = new char[] { 'w', 's', 'a', 'd' };

            int playerDist = PlayerDistance();
            char playerDir = PlayerDirection();

            var nextPosition = map.GetMoveTargetCoordinates(PositionX, PositionY, playerDir);

            var dynamic = map.GetDynamic(nextPosition.x, nextPosition.y);

            if (dynamic != null)
            {
                if (dynamic is PlayerCharacter)
                {
                    ((PlayerCharacter)dynamic).Damage(damage);
                    return;
                }
            }

            if (playerDist != -1 && playerDist <= 5)
            {
                // If the player is close, move towards player.
                Move(playerDir);
            }
            else
            {
                Move(directions[random.Next(0, directions.Length)]);
            }
        }
    }
}