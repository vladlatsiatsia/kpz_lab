using System;
using System.Collections.Generic;

namespace SubscriptionSystem
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Система створення підписок");

            List<SubscriptionCreator> creators = new List<SubscriptionCreator>
            {
                new WebSite(),
                new MobileApp(),
                new ManagerCall()
            };

            foreach (var creator in creators)
            {
                ISubscription subscription = creator.CreateSubscription();
                Console.Write($"Створено через {creator.GetType().Name}: ");
                subscription.PrintDetails();
            }
        }
    }

  
    public interface ISubscription
    {
        decimal MonthlyPrice { get; }
        int MinSubscriptionPeriodMonths { get; }
        List<string> Channels { get; }
        void PrintDetails();
    }

    public class DomesticSubscription : ISubscription
    {
        public decimal MonthlyPrice => 10.0m;
        public int MinSubscriptionPeriodMonths => 1;
        public List<string> Channels => new List<string> { "News", "Local", "Weather" };

        public void PrintDetails() =>
            Console.WriteLine($"[Domestic] Ціна: {MonthlyPrice}$, Мін. період: {MinSubscriptionPeriodMonths} міс., Канали: {string.Join(", ", Channels)}");
    }

    public class EducationalSubscription : ISubscription
    {
        public decimal MonthlyPrice => 15.0m;
        public int MinSubscriptionPeriodMonths => 3;
        public List<string> Channels => new List<string> { "Science", "History", "Documentary" };

        public void PrintDetails() =>
            Console.WriteLine($"[Educational] Ціна: {MonthlyPrice}$, Мін. період: {MinSubscriptionPeriodMonths} міс., Канали: {string.Join(", ", Channels)}");
    }

    public class PremiumSubscription : ISubscription
    {
        public decimal MonthlyPrice => 30.0m;
        public int MinSubscriptionPeriodMonths => 1;
        public List<string> Channels => new List<string> { "All Channels", "4K Movies", "Sports", "Music" };

        public void PrintDetails() =>
            Console.WriteLine($"[Premium] Ціна: {MonthlyPrice}$, Мін. період: {MinSubscriptionPeriodMonths} міс., Канали: {string.Join(", ", Channels)}");
    }

    public abstract class SubscriptionCreator
    {
        public abstract ISubscription CreateSubscription();
    }

    public class WebSite : SubscriptionCreator
    {
        public override ISubscription CreateSubscription() => new DomesticSubscription();
    }

    public class MobileApp : SubscriptionCreator
    {
        public override ISubscription CreateSubscription() => new PremiumSubscription();
    }

    public class ManagerCall : SubscriptionCreator
    {
        public override ISubscription CreateSubscription() => new EducationalSubscription();
    }
}  
