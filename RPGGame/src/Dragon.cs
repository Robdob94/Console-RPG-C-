namespace RPGGame
{
    // Equipment class to represent items that can be equipped
    public class Equipment
    {
        public string Name { get; set; } // Name of the equipment
        public int BonusHP { get; set; } // Bonus health points provided by the equipment
        public int BonusAP { get; set; } // Bonus attack points provided by the equipment

        public Equipment(string name, int bonusHP, int bonusAP)
        {
            Name = name;
            BonusHP = bonusHP;
            BonusAP = bonusAP;
        }
    }

    public class Dragon : Character
    {
        private bool IsEnraged { get; set; }
        private const int EnrageThreshold = 30; // Percentage of health

        public Dragon(string name, int health, int attackPower)
            : base(name, health, attackPower)
        {
            IsEnraged = false;
        }

        public override void Attack(Character target)
        {
            // Check if dragon should become enraged
            if (!IsEnraged && (Health * 100 / MaxHealth) <= EnrageThreshold)
            {
                IsEnraged = true;
                AttackPower *= 2;
                System.Console.WriteLine($"{Name} becomes enraged! Attack power doubled!");
            }

            int damage = AttackPower;
            if (IsEnraged)
            {
                damage = (int)(damage * 1.5); // 50% more damage when enraged
            }

            target.TakeDamage(damage);
            System.Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            System.Console.WriteLine($"{Name} has {Health} health remaining.");
        }
    }
}
