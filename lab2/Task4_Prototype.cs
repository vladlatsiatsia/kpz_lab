using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypeTask
{
    class task4
    {
        static void Main(string[] args)
        {
            
            Console.OutputEncoding = Encoding.UTF8;

            
            Virus grandparent = new Virus(10.5, 50, "Вірус-Дід", "Штам А");

            Virus parent = new Virus(5.2, 20, "Вірус-Батько", "Штам А");
            grandparent.Children.Add(parent);

            
            Virus child = new Virus(2.1, 5, "Вірус-Онук", "Штам А");
            parent.Children.Add(child);

            Console.WriteLine("Оригінальне сімейство");
            grandparent.PrintInfo(0);

           
            Virus clonedGrandparent = grandparent.Clone();

            Console.WriteLine("\nКлоноване сімейство");
            clonedGrandparent.PrintInfo(0);

          
            Console.WriteLine("\nПеревірка на незалежність");
            clonedGrandparent.Name = "КЛОН-Дід";
            clonedGrandparent.Children[0].Name = "КЛОН-Батько"; 

            Console.WriteLine($"Оригінал (дід): {grandparent.Name}, Син: {grandparent.Children[0].Name}");
            Console.WriteLine($"Клон (дід): {clonedGrandparent.Name}, Син: {clonedGrandparent.Children[0].Name}");
        }
    }

    public class Virus
    {
        public double Weight { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public List<Virus> Children { get; set; }

        public Virus(double weight, int age, string name, string species)
        {
            Weight = weight;
            Age = age;
            Name = name;
            Species = species;
            Children = new List<Virus>();
        }

      
        public Virus Clone()
        {
        
            Virus clone = new Virus(this.Weight, this.Age, this.Name, this.Species);

            
            foreach (var child in this.Children)
            {
                clone.Children.Add(child.Clone());
            }

            return clone;
        }

        
        public void PrintInfo(int indent)
        {
            string spaces = new string(' ', indent * 4);
            Console.WriteLine($"{spaces}Вірус: {Name} (Вік: {Age}, Вага: {Weight})");
            foreach (var child in Children)
            {
                child.PrintInfo(indent + 1);
            }
        }
    }
}
