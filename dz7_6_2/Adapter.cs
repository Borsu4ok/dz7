// File: Program_Adapter.cs
using System;

namespace AdapterExample
{
    // Existing incompatible interface
    class OldPrinter
    {
        public void PrintOldStyle(string text)
        {
            Console.WriteLine("OldPrinter prints: " + text);
        }
    }

    // Target interface expected by client
    interface INewPrinter
    {
        void Print(string text);
    }

    // Adapter
    class PrinterAdapter : INewPrinter
    {
        private OldPrinter oldPrinter;

        public PrinterAdapter(OldPrinter oldPrinter)
        {
            this.oldPrinter = oldPrinter;
        }

        public void Print(string text)
        {
            // adapt call
            oldPrinter.PrintOldStyle(text);
        }
    }

    class Program
    {
        static void Main()
        {
            OldPrinter old = new OldPrinter();
            INewPrinter adapter = new PrinterAdapter(old);

            // client uses INewPrinter
            adapter.Print("Hello via adapter");

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
