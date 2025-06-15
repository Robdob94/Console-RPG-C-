using System;
using System.Collections.Generic;

namespace RPGGame
{
    public class Witch : Character
    {
        private int Mana { get; set; }
        private const int MaxMana = 120;
        private const int ManaPerSpell = 15;
        private List<string> Potions { get; set; }

        public Witch(string name, int health, int attackPower) 
            : base(name, health, attackPower)
        {
            Mana = MaxMana;
            Potions = new List<string>();
        }

        public override void Attack(Character target)
        {
            if (Mana >= ManaPerSpell)
            {
                // Random spell effect
                Random random = new Random();
                int spellType = random.Next(1, 4);
                int damage = 0;

                switch (spellType)
                {
                    case 1: // Fire spell
                        damage = AttackPower * 2;
                        Console.WriteLine($"{Name} casts a fire spell at {target.Name}!");
                        break;
                    case 2: // Ice spell
                        damage = AttackPower;
                        target.AttackPower = (int)(target.AttackPower * 0.8); // Reduce target's attack power
                        Console.WriteLine($"{Name} casts an ice spell, freezing {target.Name}!");
                        break;
                    case 3: // Poison spell
                        damage = AttackPower / 2;
                        target.TakeDamage(damage); // Initial damage
                        Console.WriteLine($"{Name} casts a poison spell on {target.Name}!");
                        // Poison effect will continue for 3 turns
                        for (int i = 0; i < 3; i++)
                        {
                            target.TakeDamage(5);
                        }
                        break;
                }

                target.TakeDamage(damage);
                Mana -= ManaPerSpell;
                Console.WriteLine($"{Name} used {damage} damage! Mana remaining: {Mana}");
            }
            else
            {
                // Basic attack if out of mana
                target.TakeDamage(AttackPower / 2);
                Console.WriteLine($"{Name} performs a basic attack on {target.Name} for {AttackPower / 2} damage!");
            }
        }

        public void BrewPotion(string potionType)
        {
            if (Mana >= ManaPerSpell)
            {
                Potions.Add(potionType);
                Mana -= ManaPerSpell;
                Console.WriteLine($"{Name} brewed a {potionType}! Mana remaining: {Mana}");
            }
            else
            {
                Console.WriteLine($"{Name} doesn't have enough mana to brew a potion!");
            }
        }

        public void UsePotion(string potionType)
        {
            if (Potions.Contains(potionType))
            {
                switch (potionType)
                {
                    case "Health Potion":
                        Heal(30);
                        break;
                    case "Mana Potion":
                        Mana = Math.Min(Mana + 30, MaxMana);
                        Console.WriteLine($"{Name} restored 30 mana. Current mana: {Mana}");
                        break;
                    case "Strength Potion":
                        AttackPower += 10;
                        Console.WriteLine($"{Name}'s attack power increased by 10!");
                        break;
                }
                Potions.Remove(potionType);
            }
            else
            {
                Console.WriteLine($"{Name} doesn't have a {potionType}!");
            }
        }

        public override void Heal(int amount)
        {
            if (Mana >= ManaPerSpell)
            {
                base.Heal(amount * 2); // Witches heal for double the amount
                Mana -= ManaPerSpell;
                Console.WriteLine($"{Name} casts a healing spell and restores {amount * 2} health! Mana remaining: {Mana}");
            }
            else
            {
                Console.WriteLine($"{Name} doesn't have enough mana to heal!");
            }
        }

        public void ShowPotions()
        {
            if (Potions.Count == 0)
            {
                Console.WriteLine($"{Name} has no potions.");
                return;
            }

            Console.WriteLine($"\n{Name}'s Potions:");
            foreach (var potion in Potions)
            {
                Console.WriteLine($"- {potion}");
            }
        }
    }
}
