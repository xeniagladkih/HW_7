// Уявімо нам потрібно розрахувати вартість комп'ютера.
// Комп'ютер у свою чергу складаєтья з корпуса та перефирійних пристроїв.
// Корпус - з жорсткого диску та материнської плати.
// Материнська плата - з CPU та RAM.
// Перефирійні пристрої - з мишки та клавіатури.
// Таким чином, маємо деяку деревовидну структуру.
// Реалізуємо за допомогою паттерну Composite.

using System;
namespace CompositeDesignPattern
{
    //Creating an interface to calculate the price of a component
    public interface IComponent
    {
        void DisplayPrice();
    }

    //Creating Leaf class
    public class Leaf : IComponent
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public Leaf(string name, int price)
        {
            this.Price = price;
            this.Name = name;
        }

        public void DisplayPrice()
        {
            Console.WriteLine(Name + " : " + Price);
        }
    }

    //Creating Composite class
    public class Composite : IComponent
    {
        public string Name { get; set; }
        List<IComponent> components = new List<IComponent>();
        public Composite(string name)
        {
            this.Name = name;
        }
        public void AddComponent(IComponent component)
        {
            components.Add(component);
        }

        public void DisplayPrice()
        {
            Console.WriteLine(Name);
            foreach (var item in components)
            {
                item.DisplayPrice();
            }
        }
    }

    //Client program
    public class Program
    {
        static void Main(string[] args)
        {
            //Creating Leaf Objects

            IComponent hardDisk = new Leaf("Hard Disk", 2000);
            IComponent ram = new Leaf("RAM", 3000);
            IComponent cpu = new Leaf("CPU", 2000);
            IComponent mouse = new Leaf("Mouse", 2000);
            IComponent keyboard = new Leaf("Keyboard", 2000);

            //Creating composite objects

            Composite motherBoard = new Composite("Peripherals");
            Composite cabinet = new Composite("Cabinet");
            Composite peripherals = new Composite("Peripherals");
            Composite computer = new Composite("Computer");

            //Creating tree structure
            //Ading CPU and RAM in Mother board

            motherBoard.AddComponent(cpu);
            motherBoard.AddComponent(ram);

            //Ading mother board and hard disk in Cabinet

            cabinet.AddComponent(motherBoard);
            cabinet.AddComponent(hardDisk);

            //Ading mouse and keyborad in peripherals

            peripherals.AddComponent(mouse);
            peripherals.AddComponent(keyboard);

            //Ading cabinet and peripherals in computer

            computer.AddComponent(cabinet);
            computer.AddComponent(peripherals);

            //To display the Price of Computer

            computer.DisplayPrice();
            Console.WriteLine();

            //To display the Price of Keyboard

            keyboard.DisplayPrice();
            Console.WriteLine();

            //To display the Price of Cabinet

            cabinet.DisplayPrice();
            Console.Read();
        }
    }
}


