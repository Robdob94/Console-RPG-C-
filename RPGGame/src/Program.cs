using System;

namespace RPGGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the RPG Game!");
            Console.WriteLine("=======================");

            // Create characters
            Character wizard = new Wizard("Gandalf", 100, 20);
            Character dragon = new Dragon("Smaug", 150, 25);
            Character witch = new Witch("Morgana", 90, 25);
            NPC shopkeeper = new NPC("Merchant", 50, 5);

            // Create equipment
            Equipment magicWand = new Equipment("Magic Wand", 0, 10);
            Equipment dragonArmor = new Equipment("Dragon Armor", 20, 0);
            Equipment witchHat = new Equipment("Witch Hat", 10, 15);
            Equipment healingStaff = new Equipment("Healing Staff", 15, 5);

            // Add shop items
            shopkeeper.AddShopItem(magicWand);
            shopkeeper.AddShopItem(dragonArmor);
            shopkeeper.AddShopItem(witchHat);
            shopkeeper.AddShopItem(healingStaff);

            // Give shopkeeper a quest
            shopkeeper.GiveQuest("Defeat the dragon and bring back its scale");

            // Equip items to characters
            wizard.Equip(magicWand);
            dragon.Equip(dragonArmor);
            witch.Equip(witchHat);

            Console.WriteLine("\nGame started! The adventure begins...");
            Console.WriteLine($"Characters: {wizard.Name}, {witch.Name}, {dragon.Name}");
            Console.WriteLine($"NPC: {shopkeeper.Name}");

            // Game loop for user input actions
            while (true)
            {
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Battle Menu");
                Console.WriteLine("2. Shop Menu");
                Console.WriteLine("3. Witch's Potion Menu");
                Console.WriteLine("4. Talk to NPC");
                Console.WriteLine("5. Show character status");
                Console.WriteLine("6. Exit game");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowBattleMenu(wizard, witch, dragon);
                        break;
                    case "2":
                        ShowShopMenu(shopkeeper, wizard, witch);
                        break;
                    case "3":
                        ShowWitchMenu(witch);
                        break;
                    case "4":
                        shopkeeper.Talk();
                        if (shopkeeper.HasQuest && !shopkeeper.QuestCompleted && !dragon.IsAlive())
                        {
                            shopkeeper.CompleteQuest();
                        }
                        break;
                    case "5":
                        ShowStatus(wizard);
                        ShowStatus(witch);
                        ShowStatus(dragon);
                        ShowStatus(shopkeeper);
                        break;
                    case "6":
                        Console.WriteLine("Thanks for playing!");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }

                // Check if dragon is defeated
                if (!dragon.IsAlive() && !shopkeeper.QuestCompleted)
                {
                    Console.WriteLine("\nThe dragon has been defeated! Return to the merchant to complete the quest.");
                }
            }
        }

        static void ShowBattleMenu(Character wizard, Character witch, Character dragon)
        {
            while (true)
            {
                Console.WriteLine("\nBattle Menu:");
                Console.WriteLine("1. Wizard attacks Dragon");
                Console.WriteLine("2. Witch attacks Dragon");
                Console.WriteLine("3. Dragon attacks Wizard");
                Console.WriteLine("4. Dragon attacks Witch");
                Console.WriteLine("5. Wizard heals");
                Console.WriteLine("6. Witch heals");
                Console.WriteLine("7. Return to main menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        wizard.Attack(dragon);
                        break;
                    case "2":
                        witch.Attack(dragon);
                        break;
                    case "3":
                        dragon.Attack(wizard);
                        break;
                    case "4":
                        dragon.Attack(witch);
                        break;
                    case "5":
                        if (wizard is Wizard w)
                        {
                            w.Heal(20);
                        }
                        break;
                    case "6":
                        if (witch is Witch w2)
                        {
                            w2.Heal(20);
                        }
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }

                if (!dragon.IsAlive() || !wizard.IsAlive() || !witch.IsAlive())
                {
                    break;
                }
            }
        }

        static void ShowShopMenu(NPC shopkeeper, Character wizard, Character witch)
        {
            while (true)
            {
                Console.WriteLine("\nShop Menu:");
                Console.WriteLine("1. View items");
                Console.WriteLine("2. Buy item");
                Console.WriteLine("3. Return to main menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        shopkeeper.ShowShopItems();
                        break;
                    case "2":
                        Console.WriteLine("Enter item number to buy (1-4):");
                        if (int.TryParse(Console.ReadLine(), out int itemNumber) && itemNumber >= 1 && itemNumber <= 4)
                        {
                            var item = shopkeeper.ShopItems[itemNumber - 1];
                            Console.WriteLine($"Choose character to equip {item.Name}:");
                            Console.WriteLine("1. Wizard");
                            Console.WriteLine("2. Witch");
                            if (int.TryParse(Console.ReadLine(), out int charChoice))
                            {
                                if (charChoice == 1)
                                    wizard.Equip(item);
                                else if (charChoice == 2)
                                    witch.Equip(item);
                            }
                        }
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }

        static void ShowWitchMenu(Character witch)
        {
            if (witch is Witch w)
            {
                while (true)
                {
                    Console.WriteLine("\nWitch's Potion Menu:");
                    Console.WriteLine("1. Brew Health Potion");
                    Console.WriteLine("2. Brew Mana Potion");
                    Console.WriteLine("3. Brew Strength Potion");
                    Console.WriteLine("4. Use Health Potion");
                    Console.WriteLine("5. Use Mana Potion");
                    Console.WriteLine("6. Use Strength Potion");
                    Console.WriteLine("7. Show potions");
                    Console.WriteLine("8. Return to main menu");

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            w.BrewPotion("Health Potion");
                            break;
                        case "2":
                            w.BrewPotion("Mana Potion");
                            break;
                        case "3":
                            w.BrewPotion("Strength Potion");
                            break;
                        case "4":
                            w.UsePotion("Health Potion");
                            break;
                        case "5":
                            w.UsePotion("Mana Potion");
                            break;
                        case "6":
                            w.UsePotion("Strength Potion");
                            break;
                        case "7":
                            w.ShowPotions();
                            break;
                        case "8":
                            return;
                        default:
                            Console.WriteLine("Invalid input. Please try again.");
                            break;
                    }
                }
            }
        }

        static void ShowStatus(Character character)
        {
            Console.WriteLine($"\n{character.Name}'s Status:");
            Console.WriteLine($"Health: {character.Health}");
            Console.WriteLine($"Attack Power: {character.AttackPower}");
            if (character.EquippedItem != null)
            {
                Console.WriteLine($"Equipped: {character.EquippedItem.Name}");
            }
        }
    }
}
