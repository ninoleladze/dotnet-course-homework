using System.Collections.Generic;
using TEST_NL_1_REMAKE.Models;

namespace TEST_NL_1_REMAKE.Data
{
    internal class GameData
    {
        public List<Hero> Heroes = new List<Hero>
        {
            new Hero { Name = "Aragorn", HeroClass = "Warrior", Level = 14, Health = 220 },
            new Hero { Name = "Gandalf", HeroClass = "Mage", Level = 20, Health = 180 },
            new Hero { Name = "Legolas", HeroClass = "Archer", Level = 12, Health = 150 },
            new Hero { Name = "Gimli", HeroClass = "Warrior", Level = 11, Health = 240 },
            new Hero { Name = "Frodo", HeroClass = "Rogue", Level = 5, Health = 90 }
        };

        public List<Weapon> Weapons = new List<Weapon>
        {
            new Weapon { Name = "Excalibur", Damage = 85, Price = 1200, Type = "Sword" },
            new Weapon { Name = "Elven Bow", Damage = 45, Price = 600, Type = "Bow" },
            new Weapon { Name = "Wizard Staff", Damage = 70, Price = 1500, Type = "Staff" }
        };

        public List<Potion> Potions = new List<Potion>
        {
            new Potion { Name = "Health Potion", Effect = "Heal +50", Price = 40, Quantity = 12 },
            new Potion { Name = "Mana Potion", Effect = "Mana +30", Price = 50, Quantity = 5 },
            new Potion { Name = "Elixir of Life", Effect = "Full Heal", Price = 300, Quantity = 1 }
        };

        public List<Monster> Monsters = new List<Monster>
        {
            new Monster { Name = "Dragon", Health = 500, Danger = 10, GoldReward = 1000 },
            new Monster { Name = "Goblin", Health = 30, Danger = 2, GoldReward = 20 },
            new Monster { Name = "Orc", Health = 150, Danger = 6, GoldReward = 150 }
        };

        public List<Quest> Quests = new List<Quest>
        {
            new Quest { Title = "Save the Village", Reward = 300, IsCompleted = true, Difficulty = "Medium" },
            new Quest { Title = "Slay the Dragon", Reward = 2000, IsCompleted = false, Difficulty = "Hard" },
            new Quest { Title = "Deliver Letter", Reward = 50, IsCompleted = true, Difficulty = "Easy" }
        };

        public List<Merchant> Merchants = new List<Merchant>
        {
            new Merchant { Name = "Old Tom", City = "Riverwood", Gold = 1500, ItemCount = 24 },
            new Merchant { Name = "Belethor", City = "Whiterun", Gold = 750, ItemCount = 50 },
            new Merchant { Name = "Elven Trader", City = "Rivendell", Gold = 3000, ItemCount = 100 }
        };
    }
}