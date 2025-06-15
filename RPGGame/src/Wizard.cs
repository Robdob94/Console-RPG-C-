namespace RPGGame
{
    public class Wizard : Character
    {
        private int Mana { get; set; }
        private const int MaxMana = 100;
        private const int ManaPerSpell = 20;

        public Wizard(string name, int health, int attackPower) 
            : base(name, health, attackPower)
        {
            Mana = MaxMana;
        }

        public override void Attack(Character target)
        {
            if (Mana >= ManaPerSpell)
            {
                int damage = AttackPower * 2; // Wizards deal double damage with spells
                target.TakeDamage(damage);
                Mana -= ManaPerSpell;
                System.Console.WriteLine($"{Name} casts a spell at {target.Name} for {damage} damage! Mana remaining: {Mana}");
            }
            else
            {
                // If out of mana, do a basic attack
                target.TakeDamage(AttackPower / 2);
                System.Console.WriteLine($"{Name} performs a basic attack on {target.Name} for {AttackPower / 2} damage!");
            }
        }

        public void RestoreMana(int amount)
        {
            Mana += amount;
            if (Mana > MaxMana)
            {
                Mana = MaxMana;
            }
            System.Console.WriteLine($"{Name} restored {amount} mana. Current mana: {Mana}");
        }

        public override void Heal(int amount)
        {
            if (Mana >= ManaPerSpell)
            {
                base.Heal(amount * 2); // Wizards heal for double the amount
                Mana -= ManaPerSpell;
                System.Console.WriteLine($"{Name} casts a healing spell and restores {amount * 2} health! Mana remaining: {Mana}");
            }
            else
            {
                System.Console.WriteLine($"{Name} doesn't have enough mana to heal!");
            }
        }
    }
}
