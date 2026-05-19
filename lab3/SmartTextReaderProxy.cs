using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab3_Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string testFile = "data.txt";
            string restrictedFile = "admin_secrets.txt";

            File.WriteAllText(testFile, "Рядок один\nРядок два\nСимволи");
            File.WriteAllText(restrictedFile, "Секретні дані");

            ISmartTextReader reader = new SmartTextReader();

            Console.WriteLine("Логуючий проксі");
            ISmartTextReader checker = new SmartTextChecker(reader);
            checker.ReadText(testFile);

            Console.WriteLine("\nОбмеження доступу (Дозволено)");
            ISmartTextReader locker = new SmartTextReaderLocker(reader, @"secrets");
            locker.ReadText(testFile);

            Console.WriteLine("\nОбмеження доступу (Заборонено)");
            locker.ReadText(restrictedFile);

            Console.ReadKey();
        }
    }

    public interface ISmartTextReader
    {
        char[][] ReadText(string path);
    }

    public class SmartTextReader : ISmartTextReader
    {
        public char[][] ReadText(string path)
        {
            string[] lines = File.ReadAllLines(path);
            char[][] result = new char[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                result[i] = lines[i].ToCharArray();
            }
            return result;
        }
    }

    public class SmartTextChecker : ISmartTextReader
    {
        private readonly ISmartTextReader _reader;

        public SmartTextChecker(ISmartTextReader reader)
        {
            _reader = reader;
        }

        public char[][] ReadText(string path)
        {
            Console.WriteLine($"Opening file: {path}");
            char[][] data = _reader.ReadText(path);
            Console.WriteLine($"File {path} read successfully.");

            int totalChars = 0;
            foreach (var line in data) totalChars += line.Length;

            Console.WriteLine($"Rows count: {data.Length}");
            Console.WriteLine($"Total characters: {totalChars}");
            Console.WriteLine($"Closing file: {path}");

            return data;
        }
    }

    public class SmartTextReaderLocker : ISmartTextReader
    {
        private readonly ISmartTextReader _reader;
        private readonly Regex _regex;

        public SmartTextReaderLocker(ISmartTextReader reader, string pattern)
        {
            _reader = reader;
            _regex = new Regex(pattern);
        }

        public char[][] ReadText(string path)
        {
            if (_regex.IsMatch(path))
            {
                Console.WriteLine("Access denied!");
                return null;
            }
            return _reader.ReadText(path);
        }
    }
}
