using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorDesignPattern;

namespace DecoratorDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ITree christmasTree1 = new ChristmasTree();
            christmasTree1.create();
            Console.WriteLine(christmasTree1 + "\n");
            LedLightsDecorator chTreeWithLedLights = new LedLightsDecorator(christmasTree1);
            chTreeWithLedLights.create();
            Console.WriteLine();
            GoldGarlandDecorator chTreeWithGoldGarland = new GoldGarlandDecorator(christmasTree1);
            chTreeWithGoldGarland.create();
            Console.ReadKey();
        }
    }

    public interface ITree
    {
        ITree create();
    }

    public class ChristmasTree : ITree
    {
        public string? whiteBalls { get; set; }
        public string? redBalls { get; set; }
        public string? goldBalls { get; set; }
        public string? gingerbreads { get; set; }
        public string? snowflakes { get; set; }
        public string? lights { get; set; }
        public override string ToString()
        {
            return "Christmas tree\n         *\n      " + whiteBalls + "\n      ***********      \n   " + lights + lights + "  \n    ****************\n " + lights + "" + snowflakes + " " + lights + "\n ****************************\n" + lights + lights + lights + lights + "";
        }
        public ITree create()
        {
            whiteBalls = "white balls";
            snowflakes = "snowflakes";
            return this;
        }
    }

    public abstract class ChristmasTreeDecorator : ITree
    {
        protected ITree christmasTree;
        public ChristmasTreeDecorator(ITree christmasTree)
        {
            this.christmasTree = christmasTree;
        }
        public virtual ITree create()
        {
            return christmasTree.create();
        }
    }

    public class LedLightsDecorator : ChristmasTreeDecorator
    {
        public LedLightsDecorator(ITree christmasTree) : base(christmasTree)
        {
        }
        public override ITree create()
        {
            christmasTree.create();
            Shine(christmasTree);
            return christmasTree;
        }
        public void Shine(ITree christmasTree)
        {
            if (christmasTree is ChristmasTree)
            {
                ChristmasTree ChristmasTree = (ChristmasTree)christmasTree;
                ChristmasTree.lights = "✨ ✨ ✨ ✨ ";
                Console.WriteLine("One, two, three -  shine the ..." + christmasTree);
            }
        }
    }
    class GoldGarlandDecorator : ChristmasTreeDecorator
    {
        public GoldGarlandDecorator(ITree christmasTree) : base(christmasTree)
        {
        }
        public override ITree create()
        {
            christmasTree.create();
            Shine(christmasTree);
            return christmasTree;
        }
        public void Shine(ITree christmasTree)
        {
            if (christmasTree is ChristmasTree)
            {
                ChristmasTree ChristmasTree = (ChristmasTree)christmasTree;
                ChristmasTree.lights = "⭐ ⭐ ⭐ ⭐ ";
                Console.WriteLine("One, two, three -  shine the ..." + christmasTree);
            }
        }
    }
}
