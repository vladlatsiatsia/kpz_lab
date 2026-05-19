using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4_Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var editor = new TextEditor();
            var history = new EditorHistory();

            editor.SetText("Початкови текст.");
            history.Push(editor.Save());

            editor.SetText("Додано новий рядок.");
            history.Push(editor.Save());

            editor.SetText("Останні правки.");

            Console.WriteLine("Поточний стан ");
            editor.Print();

            Console.WriteLine("\nСкасування (Undo 1) ");
            editor.Restore(history.Pop());
            editor.Print();

            Console.WriteLine("\nСкасування (Undo 2)");
            editor.Restore(history.Pop());
            editor.Print();

            Console.ReadKey();
        }
    }

    public class TextDocument
    {
        public string Content { get; }
        public DateTime SaveTime { get; }

        public TextDocument(string content)
        {
            Content = content;
            SaveTime = DateTime.Now;
        }
    }

    public class TextEditor
    {
        private string _textContent;

        public void SetText(string text) => _textContent = text;

        public TextDocument Save()
        {
            return new TextDocument(_textContent);
        }

        public void Restore(TextDocument memento)
        {
            if (memento != null)
            {
                _textContent = memento.Content;
            }
        }

        public void Print() => Console.WriteLine($"Вміст: {_textContent}");
    }

    public class EditorHistory
    {
        private Stack<TextDocument> _history = new Stack<TextDocument>();

        public void Push(TextDocument memento) => _history.Push(memento);

        public TextDocument Pop()
        {
            if (_history.Count > 0) return _history.Pop();
            return null;
        }
    }
}
