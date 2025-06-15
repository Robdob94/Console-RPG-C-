using System;
using System.Collections.Generic;

namespace RPGGame
{
    public class NPC : Character
    {
        public string Quest { get; private set; }
        public bool HasQuest { get; private set; }
        public bool QuestCompleted { get; private set; }
        public List<Equipment> ShopItems { get; private set; }

        public NPC(string name, int health, int attackPower) 
            : base(name, health, attackPower)
        {
            HasQuest = false;
            QuestCompleted = false;
            ShopItems = new List<Equipment>();
        }

        public void GiveQuest(string questDescription)
        {
            Quest = questDescription;
            HasQuest = true;
            Console.WriteLine($"{Name} has a quest for you: {Quest}");
        }

        public void CompleteQuest()
        {
            if (HasQuest && !QuestCompleted)
            {
                QuestCompleted = true;
                Console.WriteLine($"Quest completed! {Name} is pleased with your work.");
            }
        }

        public void AddShopItem(Equipment item)
        {
            ShopItems.Add(item);
        }

        public void ShowShopItems()
        {
            if (ShopItems.Count == 0)
            {
                Console.WriteLine($"{Name} has no items for sale.");
                return;
            }

            Console.WriteLine($"\n{Name}'s Shop:");
            for (int i = 0; i < ShopItems.Count; i++)
            {
                var item = ShopItems[i];
                Console.WriteLine($"{i + 1}. {item.Name} - HP Bonus: {item.BonusHP}, AP Bonus: {item.BonusAP}");
            }
        }

        public override void Attack(Character target)
        {
            // NPCs are generally peaceful and don't attack
            Console.WriteLine($"{Name} is a peaceful NPC and refuses to attack.");
        }

        public void Talk()
        {
            if (HasQuest && !QuestCompleted)
            {
                Console.WriteLine($"{Name}: \"Please help me with my quest: {Quest}\"");
            }
            else if (QuestCompleted)
            {
                Console.WriteLine($"{Name}: \"Thank you for completing my quest!\"");
            }
            else
            {
                Console.WriteLine($"{Name}: \"Hello traveler! How can I help you today?\"");
            }
        }
    }
}
