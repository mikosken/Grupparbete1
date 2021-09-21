using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class PlayerCharacter : Character
    {
        private List<Equipment> Inventory;
        public int EquippedSlot { get; set; }

        public const int MaxInventorySize = 5;

        private int coinPurse = 0;

        public PlayerCharacter(int x, int y, DungeonMap map, char representation) : base(x, y, map)
        {
            Representation = representation;
            Inventory = new List<Equipment>();

            EquippedSlot = 0;
            Inventory.Add(new Equipment("sword"));
            Inventory.Add(new Equipment("sword"));
            Inventory.Add(new Equipment("sword"));
        }

        public override (int x, int y) Move(char direction)
        {
            var nextPosition = map.GetMoveTargetCoordinates(PositionX, PositionY, direction);

            var dynamic = map.GetDynamic(nextPosition.x, nextPosition.y);

            if (dynamic != null)
            {
                if (dynamic is NonPlayerCharacter)
                {
                    int damage = 10; // default damage (fists)

                    if (Inventory[EquippedSlot] != null)
                        damage = Inventory[EquippedSlot].Damage;

                    if (damage != 0)
                    {
                        ((NonPlayerCharacter)dynamic).Damage(damage);
                        return (PositionX, PositionY);
                    }
                }
            }

            (int newX, int newY) = map.Move(PositionX, PositionY, nextPosition.x, nextPosition.y);

            return (newX, newY);
        }

        public void AddCoins(int coins)
        {
        }

        public void SubtractCoins(int coins)
        {
            throw new NotImplementedException();
        }

        public override void NextAction()
        {
        }

        public string GetInventoryString()
        {
            var stringBuilder = new StringBuilder();

            const int Spacing = 8;

            for (int i = 0; i < MaxInventorySize; i++)
            {
                string name = new string(' ', Spacing);

                if (i < Inventory.Count)
                {
                    var item = Inventory[i];

                    if (item != null)
                    {
                        name = item.Name + name;
                        name = name.Substring(0, Spacing);
                    }
                }

                stringBuilder.Append($"{i + 1}.{name} ");
            }

            return stringBuilder.ToString();
        }
    }
}