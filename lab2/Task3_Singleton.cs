using System;
using System.Text;

namespace SingletonTask
{
    class task3
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Намагаємося отримати екземпляри:");

            Authenticator auth1 = Authenticator.Instance;
            Authenticator auth2 = Authenticator.Instance;

            
            if (Object.ReferenceEquals(auth1, auth2))
            {
                Console.WriteLine("Успіх! auth1 та auth2 — це один і той самий об'єкт.");
            }
            else
            {
                Console.WriteLine("Помилка! Це різні об'єкти.");
            }

            auth1.Login("Admin");
            auth2.Login("User");
        }
    }

  
    public sealed class Authenticator
    {
        
        private static readonly Lazy<Authenticator> _instance =
            new Lazy<Authenticator>(() => new Authenticator());

       
        private Authenticator()
        {
            Console.WriteLine("Створюється екземпляр Authenticator...");
        }

        
        public static Authenticator Instance => _instance.Value;

        public void Login(string user)
        {
           
            Console.WriteLine($"Користувач {user} увійшов в систему через екземпляр {GetHashCode()}");
        }
    }
}
