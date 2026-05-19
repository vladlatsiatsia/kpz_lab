using System;

namespace AbstractFactoryTask
{
  
    class task2
    {
        static void Main(string[] args)
        {
            
            IDeviceFactory factory = new IProneFactory();
            Console.WriteLine("Фабрика IProne:");
            Console.WriteLine(factory.CreateLaptop().GetModel());
            Console.WriteLine(factory.CreateSmartphone().GetModel());

            
            factory = new KiaomiFactory();
            Console.WriteLine("\nФабрика Kiaomi:");
            Console.WriteLine(factory.CreateNetbook().GetModel());
            Console.WriteLine(factory.CreateEBook().GetModel());

           
            factory = new BalaxyFactory();
            Console.WriteLine("\nФабрика Balaxy:");
            Console.WriteLine(factory.CreateSmartphone().GetModel());
        }
    }

  
    public interface ILaptop { string GetModel(); }
    public interface INetbook { string GetModel(); }
    public interface IEBook { string GetModel(); }
    public interface ISmartphone { string GetModel(); }

 
    public interface IDeviceFactory
    {
        ILaptop CreateLaptop();
        INetbook CreateNetbook();
        IEBook CreateEBook();
        ISmartphone CreateSmartphone();
    }

    public class IProneLaptop : ILaptop { public string GetModel() => "IProne Laptop"; }
    public class IProneNetbook : INetbook { public string GetModel() => "IProne Netbook"; }
    public class IProneEBook : IEBook { public string GetModel() => "IProne EBook"; }
    public class IProneSmartphone : ISmartphone { public string GetModel() => "IProne Smartphone"; }

    public class IProneFactory : IDeviceFactory
    {
        public ILaptop CreateLaptop() => new IProneLaptop();
        public INetbook CreateNetbook() => new IProneNetbook();
        public IEBook CreateEBook() => new IProneEBook();
        public ISmartphone CreateSmartphone() => new IProneSmartphone();
    }

   
    public class KiaomiLaptop : ILaptop { public string GetModel() => "Kiaomi Laptop"; }
    public class KiaomiNetbook : INetbook { public string GetModel() => "Kiaomi Netbook"; }
    public class KiaomiEBook : IEBook { public string GetModel() => "Kiaomi EBook"; }
    public class KiaomiSmartphone : ISmartphone { public string GetModel() => "Kiaomi Smartphone"; }

    public class KiaomiFactory : IDeviceFactory
    {
        public ILaptop CreateLaptop() => new KiaomiLaptop();
        public INetbook CreateNetbook() => new KiaomiNetbook();
        public IEBook CreateEBook() => new KiaomiEBook();
        public ISmartphone CreateSmartphone() => new KiaomiSmartphone();
    }

    
    public class BalaxyLaptop : ILaptop { public string GetModel() => "Balaxy Laptop"; }
    public class BalaxyNetbook : INetbook { public string GetModel() => "Balaxy Netbook"; }
    public class BalaxyEBook : IEBook { public string GetModel() => "Balaxy EBook"; }
    public class BalaxySmartphone : ISmartphone { public string GetModel() => "Balaxy Smartphone"; }

    public class BalaxyFactory : IDeviceFactory
    {
        public ILaptop CreateLaptop() => new BalaxyLaptop();
        public INetbook CreateNetbook() => new BalaxyNetbook();
        public IEBook CreateEBook() => new BalaxyEBook();
        public ISmartphone CreateSmartphone() => new BalaxySmartphone();
    }
}
