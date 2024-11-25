using System;

namespace RPGGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create characters
            Character wizard = new Wizard("Aristo", 100, 20);
            Character dragon = new Dragon("Attor", 150, 25);

            // Create equipment
            Equipment magicWand = new Equipment("Magic Wand", 0, 10);
            Equipment dragonArmor = new Equipment("Dragon Armor", 20, 0);

            // Equip items to characters
            wizard.Equip(magicWand);
            dragon.Equip(dragonArmor);

            // Game loop for user input actions
            while (wizard.IsAlive() && dragon.IsAlive())
            {
                Console.WriteLine("\nChoose an action: 1. Wizard attacks Dragon 2. Dragon attacks Wizard");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    wizard.Attack(dragon);
                }
                else if (input == "2")
                {
                    dragon.Attack(wizard);
                }

                // Check if either character is no longer alive
                if (!wizard.IsAlive() || !dragon.IsAlive())
                {
                    break;
                }
            }

            // End of the game
            Console.WriteLine("Game Over");
        }
    }
}
