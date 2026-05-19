[16.05.2026 11:52] Мікроволновка: using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Director director = new Director();

            
            HeroBuilder heroBuilder = new HeroBuilder("Геральт");
            director.ConstructHero(heroBuilder); 

         
            heroBuilder.AddInventory("Медальйон Вовка");

            Character hero = heroBuilder.Build();
            Console.WriteLine(" ГЕРОЙ");
            hero.ShowDetails();

            
            EnemyBuilder enemyBuilder = new EnemyBuilder("Ередін");
            director.ConstructEnemy(enemyBuilder); 

            Character enemy = enemyBuilder.Build();
            Console.WriteLine("\n ВОРОГ");
            enemy.ShowDetails();
        }
    }

   
    public class Character
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Stature { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Outfit { get; set; } 
        public List<string> Inventory { get; set; } = new List<string>();
        public List<string> Deeds { get; set; } = new List<string>();

        public void ShowDetails()
        {
            Console.WriteLine($"Персонаж: {Name}");
            Console.WriteLine($"Зріст: {Height}, Статура: {Stature}");
            Console.WriteLine($"Зовнішність: {HairColor} волосся, {EyeColor} очі, Одяг: {Outfit}");
            Console.WriteLine($"Інвентар: {string.Join(", ", Inventory)}");
            Console.WriteLine($"Дії: {string.Join(", ", Deeds)}");
        }
    }

  
    public interface ICharacterBuilder
    {
        ICharacterBuilder SetHeight(string h);
        ICharacterBuilder SetStature(string s);
        ICharacterBuilder SetHairColor(string h);
        ICharacterBuilder SetEyeColor(string e);
        ICharacterBuilder SetOutfit(string outfit); 
        ICharacterBuilder AddInventory(string item);
        Character Build();
    }
    public class HeroBuilder : ICharacterBuilder
    {
        private Character _character;
        public HeroBuilder(string name) { _character = new Character { Name = name }; }

        public HeroBuilder SetHeight(string h) { _character.Height = h; return this; }
        public HeroBuilder SetStature(string s) { _character.Stature = s; return this; }
        public HeroBuilder SetHairColor(string h) { _character.HairColor = h; return this; }
        public HeroBuilder SetEyeColor(string e) { _character.EyeColor = e; return this; }
        public HeroBuilder SetOutfit(string o) { _character.Outfit = o; return this; }
        public HeroBuilder AddInventory(string i) { _character.Inventory.Add(i); return this; }
        public HeroBuilder AddGoodDeed(string deed) { _character.Deeds.Add("Добро: " + deed); return this; }

        public Character Build() => _character;

        ICharacterBuilder ICharacterBuilder.SetHeight(string h) => SetHeight(h);
        ICharacterBuilder ICharacterBuilder.SetStature(string s) => SetStature(s);
        ICharacterBuilder ICharacterBuilder.SetHairColor(string h) => SetHairColor(h);
        ICharacterBuilder ICharacterBuilder.SetEyeColor(string e) => SetEyeColor(e);
        ICharacterBuilder ICharacterBuilder.SetOutfit(string o) => SetOutfit(o);
        ICharacterBuilder ICharacterBuilder.AddInventory(string i) => AddInventory(i);
    }

    public class EnemyBuilder : ICharacterBuilder
    {
        private Character _character;
        public EnemyBuilder(string name) { _character = new Character { Name = name }; }
[16.05.2026 11:52] Мікроволновка: public EnemyBuilder SetHeight(string h) { _character.Height = h; return this; }
        public EnemyBuilder SetStature(string s) { _character.Stature = s; return this; }
        public EnemyBuilder SetHairColor(string h) { _character.HairColor = h; return this; }
        public EnemyBuilder SetEyeColor(string e) { _character.EyeColor = e; return this; }
        public EnemyBuilder SetOutfit(string o) { _character.Outfit = o; return this; }
        public EnemyBuilder AddInventory(string i) { _character.Inventory.Add(i); return this; }
        public EnemyBuilder AddEvilDeed(string deed) { _character.Deeds.Add("Зло: " + deed); return this; }

        public Character Build() => _character;

        ICharacterBuilder ICharacterBuilder.SetHeight(string h) => SetHeight(h);
        ICharacterBuilder ICharacterBuilder.SetStature(string s) => SetStature(s);
        ICharacterBuilder ICharacterBuilder.SetHairColor(string h) => SetHairColor(h);
        ICharacterBuilder ICharacterBuilder.SetEyeColor(string e) => SetEyeColor(e);
        ICharacterBuilder ICharacterBuilder.SetOutfit(string o) => SetOutfit(o);
        ICharacterBuilder ICharacterBuilder.AddInventory(string i) => AddInventory(i);
    }

    public class Director
    {
        public void ConstructHero(HeroBuilder builder)
        {
            builder.SetHeight("185см")
                   .SetStature("Атлетична")
                   .SetHairColor("Біле")
                   .SetEyeColor("Жовті")
                   .SetOutfit("Шкіряна броня")
                   .AddInventory("Срібний меч")
                   .AddGoodDeed("Врятував світ");
        }

        public void ConstructEnemy(EnemyBuilder builder)
        {
            builder.SetHeight("210см")
                   .SetStature("Могутня")
                   .SetHairColor("Відсутнє")
                   .SetEyeColor("Червоні")
                   .SetOutfit("Темні лати")
                   .AddInventory("Морозний меч")
                   .AddEvilDeed("Викрав Цірі");
        }
    }
}
