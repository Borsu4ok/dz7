// File: Program_Decorator.cs
using System;

namespace DecoratorExample
{
    // Component interface
    interface IChristmasTree
    {
        void Display(); // show tree description
    }

    // Concrete component
    class SimpleTree : IChristmasTree
    {
        public void Display()
        {
            Console.WriteLine("Simple Christmas tree");
        }
    }

    // Base decorator
    abstract class TreeDecorator : IChristmasTree
    {
        protected IChristmasTree tree;

        public TreeDecorator(IChristmasTree tree)
        {
            this.tree = tree;
        }

        public virtual void Display()
        {
            tree.Display();
        }
    }

    // Ornament decorator (adds fields)
    class OrnamentDecorator : TreeDecorator
    {
        private string ornament;

        public OrnamentDecorator(IChristmasTree tree, string ornament) : base(tree)
        {
            this.ornament = ornament;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine(" + Ornament: " + ornament);
        }
    }

    // Garland decorator (adds method to "shine")
    class GarlandDecorator : TreeDecorator
    {
        private bool isShining;

        public GarlandDecorator(IChristmasTree tree) : base(tree)
        {
            this.isShining = false;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine(" + Garland: " + (isShining ? "shining" : "not shining"));
        }

        // Method to switch on/off lights
        public void Shine(bool on)
        {
            isShining = on;
            Console.WriteLine("Garland switched " + (on ? "on" : "off"));
        }
    }

    class Decorator
    {
        static void Main(string[] args)
        {
            // base tree
            IChristmasTree tree = new SimpleTree();
            tree.Display();
            Console.WriteLine();

            // tree with ornaments
            tree = new OrnamentDecorator(tree, "Red balls");
            tree.Display();
            Console.WriteLine();

            // decorate with garland
            GarlandDecorator garlanded = new GarlandDecorator(tree);
            garlanded.Display();
            Console.WriteLine();

            // turn lights on
            garlanded.Shine(true);
            garlanded.Display();

            // combine multiple ornaments
            IChristmasTree fancy = new OrnamentDecorator(new OrnamentDecorator(new GarlandDecorator(new SimpleTree()), "Gold stars"), "Blue ribbons");
            // to use Shine we need to keep reference to GarlandDecorator:
            GarlandDecorator g = new GarlandDecorator(new SimpleTree());
            IChristmasTree decorated = new OrnamentDecorator(g, "Glass balls");
            g.Shine(true);
            decorated.Display();

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
