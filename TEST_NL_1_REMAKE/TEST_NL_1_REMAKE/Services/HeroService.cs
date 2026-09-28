using System;
using System.Collections.Generic;
using System.Linq;
using TEST_NL_1_REMAKE.Models;

namespace TEST_NL_1_REMAKE.Services
{
    internal class HeroService
    {
        public void ShowAllHeroes(List<Hero> heroes) => heroes.ForEach(h => h.DisplayHero());
        public void ShowHighLevelHeroes(List<Hero> heroes) => ShowAllHeroes(heroes.Where(h => h.Level > 10).ToList());
        public void ShowHeroesSortedByHealth(List<Hero> heroes) => ShowAllHeroes(heroes.OrderByDescending(h => h.Health).ToList());
        public void ShowMaxLevelHero(List<Hero> heroes) => heroes.MaxBy(h => h.Level)?.DisplayHero();
        public void ShowHeroesGroupedByClass(List<Hero> heroes)
        {
            foreach (var group in heroes.GroupBy(h => h.HeroClass))
            {
                Console.WriteLine($"\n=== Class: {group.Key} ===");
                foreach (var h in group) Console.WriteLine($" - {h.Name} (Level {h.Level})");
            }
        }
        public void AddHero(List<Hero> heroes)
        {
            Console.Write("Name: "); string name = Console.ReadLine();
            Console.Write("Class: "); string heroClass = Console.ReadLine();
            Console.Write("Level: "); int.TryParse(Console.ReadLine(), out int level);
            Console.Write("Health: "); int.TryParse(Console.ReadLine(), out int health);

            heroes.Add(new Hero { Name = name, HeroClass = heroClass, Level = level, Health = health });
            Console.WriteLine("Hero added successfully!");
        }
    }
}