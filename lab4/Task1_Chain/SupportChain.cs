using System;

namespace Lab4_Chain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

         
            Handler level4 = new TechExpertHandler();
            Handler level3 = new SeniorSupportHandler(level4);
            Handler level2 = new JuniorSupportHandler(level3);
            Handler start = new ReceptionHandler(level2);

            bool solved = false;
            while (!solved)
            {
                Console.WriteLine("\nСистема підтримки користувачів ");
                solved = start.HandleRequest();
                if (!solved) Console.WriteLine("На жаль, ми не змогли допомогти. Спробуйте ще раз.");
            }
            Console.ReadKey();
        }
    }

    public abstract class Handler
    {
        protected Handler _next;
        public Handler(Handler next = null) => _next = next;
        public abstract bool HandleRequest();
    }

   
    public class ReceptionHandler : Handler
    {
        public ReceptionHandler(Handler next) : base(next) { }
        public override bool HandleRequest()
        {
            Console.WriteLine("1. У вас загальне питання по сервісу? (так/ні)");
            if (Console.ReadLine().ToLower() == "так")
            {
                Console.WriteLine("Відповідь: Наш сервіс працює 24/7. Дякуємо!");
                return true;
            }
            return _next?.HandleRequest() ?? false;
        }
    }


    public class JuniorSupportHandler : Handler
    {
        public JuniorSupportHandler(Handler next) : base(next) { }
        public override bool HandleRequest()
        {
            Console.WriteLine("2. У вас проблема з входом в акаунт? (так/ні)");
            if (Console.ReadLine().ToLower() == "так")
            {
                Console.WriteLine("Відповідь: Натисніть 'Забули пароль' на формі входу.");
                return true;
            }
            return _next?.HandleRequest() ?? false;
        }
    }


    public class SeniorSupportHandler : Handler
    {
        public SeniorSupportHandler(Handler next) : base(next) { }
        public override bool HandleRequest()
        {
            Console.WriteLine("3. У вас помилка при оплаті замовлення? (так/ні)");
            if (Console.ReadLine().ToLower() == "так")
            {
                Console.WriteLine("Відповідь: Перевірте ліміт вашої картки або зверніться в банк.");
                return true;
            }
            return _next?.HandleRequest() ?? false;
        }
    }


    public class TechExpertHandler : Handler
    {
        public override bool HandleRequest()
        {
            Console.WriteLine("4. У вас технічний баг у коді програми? (так/ні)");
            if (Console.ReadLine().ToLower() == "так")
            {
                Console.WriteLine("Відповідь: Запит передано розробникам. Очікуйте на пошту.");
                return true;
            }
            return false;
        }
    }
} (ЛАБА 4 ЗАВДАННЯ 1
