namespace RPGGame
{
    // Wizard class inheriting from Character
    public class Wizard : Character
    {
        public Wizard(string name, int hp, int ap) : base(name, hp, ap) { }

        // Override attack method for Wizard
        public override void Attack(Character target)
        {
            Console.WriteLine($"{Name} casts a spell on {target.Name}!");
            target.TakeDamage(AP);
            GainXP(5);
        }
    }
}
