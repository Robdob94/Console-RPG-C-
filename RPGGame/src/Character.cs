using System;
using System.Collections.Generic;

namespace RPGGame
{
    // Abstract base class for all characters
    public abstract class Character
    {
        public string Name { get; set; } // Character's name
        public int BaseHP { get; set; } // Base health points
        public int BaseAP { get; set; } // Base attack points
        public int HP => BaseHP + (EquippedItem?.BonusHP ?? 0); // Total HP, including equipment bonus
        public int AP => BaseAP + (EquippedItem?.BonusAP ?? 0); // Total AP, including equipment bonus
        public Equipment EquippedItem { get; set; } // Equipped item
        public List<string> Inventory { get; set; } // List of items in inventory
        public int XP { get; set; } // Experience points
        public int Level { get; set; } // Character level

        public Character(string name, int baseHP, int baseAP)
        {
            Name = name;
            BaseHP = baseHP;
            BaseAP = baseAP;
            XP = 0;
            Level = 1;
            Inventory = new List<string>();
        }

        // Abstract method for attacking another character
        public abstract void Attack(Character target);

        // Method to take damage and reduce HP
        public void TakeDamage(int damage)
        {
            BaseHP -= damage;
            if (BaseHP < 0) BaseHP = 0;
            Console.WriteLine($"{Name} takes {damage} damage and now has {BaseHP} HP.");
        }

        // Method to check if the character is still alive
        public bool IsAlive()
        {
            return BaseHP > 0;
        }

        // Method to use an item from the inventory
        public void UseItem(string item)
        {
            if (Inventory.Contains(item))
            {
                Console.WriteLine($"{Name} uses {item}!");
                if (item == "Health Potion")
                {
                    BaseHP += 20;
                    Console.WriteLine($"{Name} restores 20 HP and now has {BaseHP} HP.");
                }
                Inventory.Remove(item);
            }
            else
            {
                Console.WriteLine($"{Name} does not have {item}.");
            }
        }

        // Method to gain experience points
        public void GainXP(int xp)
        {
            XP += xp;
            Console.WriteLine($"{Name} gains {xp} XP.");
            if (XP >= Level * 10)
            {
                LevelUp();
            }
        }

        // Method to level up and increase stats
        public void LevelUp()
        {
            Level++;
            BaseHP += 10;
            BaseAP += 5;
            Console.WriteLine($"{Name} leveled up to Level {Level}! HP: {BaseHP}, AP: {BaseAP}");
        }

        // Method to equip an item
        public void Equip(Equipment item)
        {
            EquippedItem = item;
            Console.WriteLine($"{Name} equipped {item.Name}. HP: {HP}, AP: {AP}");
        }
    }
}
