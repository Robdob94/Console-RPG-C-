using System;
using System.Collections.Generic;

namespace RPGGame
{
    // Abstract base class for all characters
    public abstract class Character
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int MaxHealth { get; protected set; }
        public int AttackPower { get; protected set; }
        public Equipment EquippedItem { get; protected set; }
        public List<string> Inventory { get; set; } // List of items in inventory
        public int XP { get; set; } // Experience points
        public int Level { get; set; } // Character level

        protected Character(string name, int health, int attackPower)
        {
            Name = name;
            MaxHealth = health;
            Health = health;
            AttackPower = attackPower;
            EquippedItem = null;
            XP = 0;
            Level = 1;
            Inventory = new List<string>();
        }

        // Abstract method for attacking another character
        public abstract void Attack(Character target);

        // Method to take damage and reduce HP
        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }

        // Method to check if the character is still alive
        public bool IsAlive()
        {
            return Health > 0;
        }

        // Method to use an item from the inventory
        public void UseItem(string item)
        {
            if (Inventory.Contains(item))
            {
                Console.WriteLine($"{Name} uses {item}!");
                if (item == "Health Potion")
                {
                    Health += 20;
                    Console.WriteLine($"{Name} restores 20 HP and now has {Health} HP.");
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
            MaxHealth += 10;
            AttackPower += 5;
            Console.WriteLine($"{Name} leveled up to Level {Level}! HP: {Health}, AP: {AttackPower}");
        }

        // Method to equip an item
        public virtual void Equip(Equipment equipment)
        {
            if (EquippedItem != null)
            {
                MaxHealth -= EquippedItem.BonusHP;
                AttackPower -= EquippedItem.BonusAP;
            }

            EquippedItem = equipment;
            MaxHealth += equipment.BonusHP;
            AttackPower += equipment.BonusAP;
            
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }

        public virtual void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }
    }
}
