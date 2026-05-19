using System;
using System.IO;
using System.Text;

namespace Lab3_Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Тест Консольного Логера");
            ILogger consoleLogger = new Logger();
            consoleLogger.Log("Повідомлення успішно виведено.");
            consoleLogger.Warn("Увага! Перевірте налаштування.");
            consoleLogger.Error("Помилка! Доступ заборонено.");

            Console.WriteLine();

        
            Console.WriteLine("Тест Файлового Логера (Адаптер) ");
            FileWriter writer = new FileWriter("log.txt");
            ILogger fileLogger = new FileLoggerAdapter(writer);

            Console.WriteLine("[Запис у файл...] Повідомлення успішно записано у файл log.txt.");
            fileLogger.Log("все ок.");

            Console.WriteLine("[Запис у файл...] Попередження записано у файл log.txt.");
            fileLogger.Warn("є попередження.");

            Console.WriteLine("[Запис у файл...] Помилка записана у файл log.txt.");
            fileLogger.Error("сталася помилка.");

            Console.WriteLine("\nРоботу завершено. Перевірте файл log.txt.");
            Console.ReadKey();
        }
    }

    public interface ILogger
    {
        void Log(string message);
        void Error(string message);
        void Warn(string message);
    }

    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[LOG]: {message}");
            Console.ResetColor();
        }

        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR]: {message}");
            Console.ResetColor();
        }

        public void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"[WARN]: {message}");
            Console.ResetColor();
        }
    }

    public class FileWriter
    {
        private string _path;
        public FileWriter(string path) => _path = path;
        public void Write(string text) => File.AppendAllText(_path, text);
        public void WriteLine(string text) => File.AppendAllText(_path, text + Environment.NewLine);
    }

    public class FileLoggerAdapter : ILogger
    {
        private readonly FileWriter _fileWriter;
        public FileLoggerAdapter(FileWriter fileWriter) => _fileWriter = fileWriter;

        public void Log(string message) => _fileWriter.WriteLine($"[LOG] {DateTime.Now}: {message}");
        public void Error(string message) => _fileWriter.WriteLine($"[ERROR] {DateTime.Now}: {message}");
        public void Warn(string message) => _fileWriter.WriteLine($"[WARN] {DateTime.Now}: {message}");
    }
} 
