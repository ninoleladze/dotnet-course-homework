using System;
using System.Collections.Generic;
using System.Text;
using TEST_NL_1.Models;

namespace TEST_NL_1.Services
{
    internal class HeroService
    {
        public void ShowAllHeroes(List<Hero> heroes)
        {
            for (int i = 0; i < heroes.Count; i++)
            {
                heroes[i].DisplayHero();
            }
        }

        public void ShowHighLevelHeroes(List<Hero> heroes)
        {
            List<Hero> filtered = heroes.Where(h => h.Level > 10).ToList();
            ShowAllHeroes(filtered);
        }

        public void ShowHeroesSortedByHealth(List<Hero> heroes)
        {
            List<Hero> sorted = heroes.OrderByDescending(h => h.Health).ToList();
            ShowAllHeroes(sorted);
        }

        public void ShowMaxLevelHero(List<Hero> heroes)
        {
            Hero topHero = heroes.MaxBy(h => h.Level);
            if (topHero != null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n[Yvelaze Maghali Donis Gmiri]");
                Console.ResetColor();
                topHero.DisplayHero();
            }
        }

        public void ShowHeroesGroupedByClass(List<Hero> heroes)
        {
            var grouped = heroes.GroupBy(h => h.HeroClass);
            foreach (var group in grouped)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\n=== Class: {group.Key} ===");
                Console.ResetColor();
                foreach (var hero in group)
                {
                    Console.WriteLine($" - {hero.Name} (Level {hero.Level}, HP {hero.Health})");
                }
            }
        }

 
        public void SearchByName(List<Hero> heroes)
        {
            Console.Write("Sheiyvanet gmiris saxeli (an natsili): ");
            string input = Console.ReadLine() ?? "";

            List<Hero> filtered = heroes.Where(x => x.Name.Contains(input, StringComparison.OrdinalIgnoreCase)).ToList();

            if (filtered.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Gmiri am saxelit ver moidzebna.");
                Console.ResetColor();
                return;
            }

            ShowAllHeroes(filtered);
        }

        public void AddHero(List<Hero> heroes)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n=== AXALI GMIRIS DAMATEBA ===");
            Console.ResetColor();

            Console.Write("Saxeli (Name): ");
            string name = Console.ReadLine() ?? "Unknown";

            Console.Write("Klasi (HeroClass - Warrior/Mage/Archer): ");
            string heroClass = Console.ReadLine() ?? "Warrior";

            Console.Write("Done (Level): ");
            int.TryParse(Console.ReadLine(), out int level);

            Console.Write("Sicocxle (Health): ");
            int.TryParse(Console.ReadLine(), out int health);

          
            Hero newHero = new Hero
            { 
                Name = name, 
                HeroClass = heroClass, 
                Level = level, 
                Health = health };
            heroes.Add(newHero);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n Gmiri '{name}' warmatebit daemata siahshi!");
            Console.ResetColor();
        }
    }
}
