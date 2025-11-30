// File: Program_FactoryMethod.cs
using System;

namespace FactoryMethodExample
{
    // Product interface
    interface IProduct
    {
        void Use();
    }

    class ConcreteProductA : IProduct
    {
        public void Use() { Console.WriteLine("Using product A"); }
    }

    class ConcreteProductB : IProduct
    {
        public void Use() { Console.WriteLine("Using product B"); }
    }

    // Creator
    abstract class Creator
    {
        public abstract IProduct CreateProduct();
        public void SomeOperation()
        {
            var product = CreateProduct();
            Console.WriteLine("Creator: Working with created product:");
            product.Use();
        }
    }

    class ConcreteCreatorA : Creator
    {
        public override IProduct CreateProduct()
        {
            return new ConcreteProductA();
        }
    }

    class ConcreteCreatorB : Creator
    {
        public override IProduct CreateProduct()
        {
            return new ConcreteProductB();
        }
    }

    class Program
    {
        static void Main()
        {
            Creator creator = new ConcreteCreatorA();
            creator.SomeOperation();

            creator = new ConcreteCreatorB();
            creator.SomeOperation();

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
