using System;
using System.Collections.Generic;
using System.Text;
using TEST_NL_1.Models;

namespace TEST_NL_1.Data
{
    internal class GameData
    {
        public List<Hero> Heroes = new List<Hero>
        {
            new Hero { Name = "Aragorn", HeroClass = "Warrior", Level = 14, Health = 220 },
            new Hero { Name = "Gandalf", HeroClass = "Mage", Level = 20, Health = 180 },
            new Hero { Name = "Legolas", HeroClass = "Archer", Level = 12, Health = 150 },
            new Hero { Name = "Gimli", HeroClass = "Warrior", Level = 11, Health = 240 },
            new Hero { Name = "Frodo", HeroClass = "Rogue", Level = 5, Health = 90 },
            new Hero { Name = "Boromir", HeroClass = "Warrior", Level = 13, Health = 210 }
        };

        public List<Weapon> Weapons = new List<Weapon>
        {
            new Weapon { Name = "Excalibur", Damage = 85, Price = 1200, Type = "Sword" },
            new Weapon { Name = "Elven Bow", Damage = 45, Price = 600, Type = "Bow" },
            new Weapon { Name = "Wizard Staff", Damage = 70, Price = 1500, Type = "Staff" },
            new Weapon { Name = "Iron Dagger", Damage = 15, Price = 50, Type = "Dagger" },
            new Weapon { Name = "Battle Axe", Damage = 60, Price = 800, Type = "Axe" },
            new Weapon { Name = "Longsword", Damage = 55, Price = 400, Type = "Sword" }
        };

        public List<Potion> Potions = new List<Potion>
        {
            new Potion { Name = "Health Potion", Effect = "Heal +50", Price = 40, Quantity = 12 },
            new Potion { Name = "Mana Potion", Effect = "Mana +30", Price = 50, Quantity = 5 },
            new Potion { Name = "Elixir of Life", Effect = "Full Heal", Price = 300, Quantity = 1 },
            new Potion { Name = "Poison", Effect = "Damage -20", Price = 20, Quantity = 8 },
            new Potion { Name = "Stamina Potion", Effect = "Stamina +40", Price = 35, Quantity = 15 },
            new Potion { Name = "Antidote", Effect = "Cure Poison", Price = 60, Quantity = 3 }
        };

        public List<Monster> Monsters = new List<Monster>
        {
            new Monster { Name = "Dragon", Health = 500, Danger = 10, GoldReward = 1000 },
            new Monster { Name = "Goblin", Health = 30, Danger = 2, GoldReward = 20 },
            new Monster { Name = "Orc", Health = 150, Danger = 6, GoldReward = 150 },
            new Monster { Name = "Troll", Health = 350, Danger = 8, GoldReward = 400 },
            new Monster { Name = "Slime", Health = 15, Danger = 1, GoldReward = 5 },
            new Monster { Name = "Lich", Health = 280, Danger = 9, GoldReward = 750 }
        };

        public List<Quest> Quests = new List<Quest>
        {
            new Quest { Title = "Save the Village", Reward = 300, IsCompleted = true, Difficulty = "Medium" },
            new Quest { Title = "Slay the Dragon", Reward = 2000, IsCompleted = false, Difficulty = "Hard" },
            new Quest { Title = "Find the Ring", Reward = 500, IsCompleted = true, Difficulty = "Medium" },
            new Quest { Title = "Deliver Letter", Reward = 50, IsCompleted = true, Difficulty = "Easy" },
            new Quest { Title = "Kill 10 Goblins", Reward = 100, IsCompleted = false, Difficulty = "Easy" },
            new Quest { Title = "Clear Dungeon", Reward = 800, IsCompleted = false, Difficulty = "Hard" }
        };

        public List<Merchant> Merchants = new List<Merchant>
        {
            new Merchant { Name = "Old Tom", City = "Riverwood", Gold = 1500, ItemCount = 24 },
            new Merchant { Name = "Belethor", City = "Whiterun", Gold = 750, ItemCount = 50 },
            new Merchant { Name = "Gollum", City = "Cave", Gold = 10, ItemCount = 1 },
            new Merchant { Name = "Elven Trader", City = "Rivendell", Gold = 3000, ItemCount = 100 },
            new Merchant { Name = "Shady Guy", City = "Riverwood", Gold = 200, ItemCount = 5 },
            new Merchant { Name = "Anoriath", City = "Whiterun", Gold = 1200, ItemCount = 30 }
        };
    }
}
