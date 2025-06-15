namespace RPGGame
{
    public class Equipment
    {
        public string Name { get; set; }
        public int BonusHP { get; set; }
        public int BonusAP { get; set; }

        public Equipment(string name, int bonusHP, int bonusAP)
        {
            Name = name;
            BonusHP = bonusHP;
            BonusAP = bonusAP;
        }
    }
}
