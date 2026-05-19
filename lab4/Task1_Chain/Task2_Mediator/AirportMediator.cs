using System;
using System.Collections.Generic;

namespace Lab4_Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            var commandCentre = new CommandCentre();


            var runway1 = new Runway(commandCentre);
            var aircraft1 = new Aircraft("Boeing 747", commandCentre);
            var aircraft2 = new Aircraft("Airbus A320", commandCentre);

            Console.WriteLine("Смуга зайнята ");
            runway1.IsFree = false; // Смуга зайнята
            aircraft1.RequestLanding();

            Console.WriteLine("\nСмуга вільна ");
            runway1.IsFree = true; 
            aircraft1.RequestLanding();

            Console.WriteLine("\n Другий літак");
            aircraft2.RequestLanding();

            Console.ReadKey();
        }
    }

    public interface IMediator
    {
        void RegisterAircraft(Aircraft aircraft);
        void RegisterRunway(Runway runway);
        bool CanLand(Aircraft aircraft);
    }


    public class CommandCentre : IMediator
    {
        private List<Aircraft> _aircrafts = new List<Aircraft>();
        private List<Runway> _runways = new List<Runway>();

        public void RegisterAircraft(Aircraft aircraft) => _aircrafts.Add(aircraft);
        public void RegisterRunway(Runway runway) => _runways.Add(runway);

        public bool CanLand(Aircraft aircraft)
        {
   
            foreach (var runway in _runways)
            {
                if (runway.IsFree) return true;
            }
            return false;
        }
    }


    public class Aircraft
    {
        private IMediator _mediator;
        public string Name { get; }

        public Aircraft(string name, IMediator mediator)
        {
            Name = name;
            _mediator = mediator;
            _mediator.RegisterAircraft(this); 
        }

        public void RequestLanding()
        {
            Console.WriteLine($"{Name}: Запитую дозвіл на посадку у диспетчера...");
            if (_mediator.CanLand(this))
            {
                Console.WriteLine($"Диспетчер: Дозвіл для {Name} НАДАНО.");
            }
            else
            {
                Console.WriteLine($"Диспетчер: Дозвіл для {Name} ВІДХИЛЕНО. Смуги зайняті.");
            }
        }
    }

    
    public class Runway
    {
        private IMediator _mediator;
        public bool IsFree { get; set; }

        public Runway(IMediator mediator)
        {
            _mediator = mediator;
            _mediator.RegisterRunway(this); 
        }
    }
}
