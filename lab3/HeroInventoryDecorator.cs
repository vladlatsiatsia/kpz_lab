using System;
using System.Text;

namespace Lab3_Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;



            IHero knight = new Knight();
            Console.WriteLine($"\nСтворено: {knight.GetDescription()} (Базова сила: {knight.GetStats()})");

            knight = new ArmorDecorator(knight, "Важкі лати", 30);
            knight = new WeaponDecorator(knight, "Довгий меч", 15);
            knight = new ArtifactDecorator(knight, "Щит Віри", 20);
            knight = new ArtifactDecorator(knight, "Амулет стійкості", 10);

            Console.WriteLine("\nПерсонаж після екіпірування:");
            Console.WriteLine($"Опис: {knight.GetDescription()}");
            Console.WriteLine($"Загальна сила: {knight.GetStats()}");

            Console.WriteLine("\nТест інших класів ");
            IHero mage = new Mage();
            mage = new WeaponDecorator(mage, "Посох хаосу", 25);
            Console.WriteLine($"{mage.GetDescription()} | Сила: {mage.GetStats()}");

            Console.ReadKey();
        }
    }

    public interface IHero
    {
        string GetDescription();
        int GetStats();
    }

    public class Warrior : IHero
    {
        public string GetDescription() => "Warrior";
        public int GetStats() => 50;
    }

    public class Mage : IHero
    {
        public string GetDescription() => "Mage";
        public int GetStats() => 30;
    }

    public class Palladin : IHero
    {
        public string GetDescription() => "Palladin";
        public int GetStats() => 45;
    }

    public class Knight : IHero
    {
        public string GetDescription() => "Knight";
        public int GetStats() => 55;
    }

    public abstract class InventoryDecorator : IHero
    {
        protected IHero _hero;
        public InventoryDecorator(IHero hero) => _hero = hero;
        public virtual string GetDescription() => _hero.GetDescription();
        public virtual int GetStats() => _hero.GetStats();
    }

    public class WeaponDecorator : InventoryDecorator
    {
        private string _name;
        private int _bonus;
        public WeaponDecorator(IHero hero, string name, int bonus) : base(hero)
        {
            _name = name;
            _bonus = bonus;
        }
        public override string GetDescription() => base.GetDescription() + $", зі зброєю [{_name}]";
        public override int GetStats() => base.GetStats() + _bonus;
    }

    public class ArmorDecorator : InventoryDecorator
    {
        private string _name;
        private int _bonus;
        public ArmorDecorator(IHero hero, string name, int bonus) : base(hero)
        {
            _name = name;
            _bonus = bonus;
        }
        public override string GetDescription() => base.GetDescription() + $", в одязі [{_name}]";
        public override int GetStats() => base.GetStats() + _bonus;
    }

    public class ArtifactDecorator : InventoryDecorator
    {
        private string _name;
        private int _bonus;
        public ArtifactDecorator(IHero hero, string name, int bonus) : base(hero)
        {
            _name = name;
            _bonus = bonus;
        }
        public override string GetDescription() => base.GetDescription() + $", з артефактом [{_name}]";
        public override int GetStats() => base.GetStats() + _bonus;
    }
}
