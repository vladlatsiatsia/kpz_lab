using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3_Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string bookText = "ROMEO AND JULIET\n" +
                              "ACT V\n" +
                              " Scene I. Mantua. A Street.\n" +
                              "The vault is opened and Romeo enters the tomb to find Juliet.";

            string[] lines = bookText.Split('\n');
            var factory = new LightHTMLFactory();
            var body = new LightElementNode("body");

            long startMemory = GC.GetTotalMemory(true);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string tagName = "p";

                if (i == 0) tagName = "h1";
                else if (line.StartsWith(" ")) tagName = "blockquote";
                else if (line.Length < 20) tagName = "h2";

                var flyweight = factory.GetElement(tagName);
                var element = new LightElementInstance(flyweight);
                element.AddChild(new LightTextNode(line));
                body.AddChild(element);
            }

            long endMemory = GC.GetTotalMemory(true);

            Console.WriteLine("Результат верстки книги");
            Console.WriteLine(body.OuterHTML());

            Console.WriteLine("\nЛегковаговик");
            Console.WriteLine($"Унікальних об'єктів тегів у пам'яті: {factory.TotalElements}");
            Console.WriteLine($"Зайнято пам'яті для дерева: {endMemory - startMemory} байт");

            Console.ReadKey();
        }
    }

    public class LightHTMLElementFlyweight
    {
        public string TagName { get; }
        public LightHTMLElementFlyweight(string tagName) => TagName = tagName;
    }

    public class LightHTMLFactory
    {
        private Dictionary<string, LightHTMLElementFlyweight> _elements = new Dictionary<string, LightHTMLElementFlyweight>();

        public LightHTMLElementFlyweight GetElement(string tagName)
        {
            if (!_elements.ContainsKey(tagName))
                _elements[tagName] = new LightHTMLElementFlyweight(tagName);
            return _elements[tagName];
        }

        public int TotalElements => _elements.Count;
    }

    public abstract class LightNode
    {
        public abstract string OuterHTML();
    }

    public class LightTextNode : LightNode
    {
        private string _text;
        public LightTextNode(string text) => _text = text;
        public override string OuterHTML() => _text;
    }

    public class LightElementInstance : LightNode
    {
        private LightHTMLElementFlyweight _flyweight;
        private List<LightNode> _children = new List<LightNode>();

        public LightElementInstance(LightHTMLElementFlyweight flyweight) => _flyweight = flyweight;
        public void AddChild(LightNode node) => _children.Add(node);

        public override string OuterHTML()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<{_flyweight.TagName}>");
            foreach (var child in _children) sb.Append(child.OuterHTML());
            sb.Append($"</{_flyweight.TagName}>");
            return sb.ToString();
        }
    }

    public class LightElementNode : LightNode
    {
        private string _tagName;
        private List<LightNode> _children = new List<LightNode>();

        public LightElementNode(string tagName) => _tagName = tagName;
        public void AddChild(LightNode node) => _children.Add(node);

        public override string OuterHTML()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<{_tagName}>");
            foreach (var child in _children) sb.Append(child.OuterHTML());
            sb.Append($"</{_tagName}>");
            return sb.ToString();
        }
    }
}
