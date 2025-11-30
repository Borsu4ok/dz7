// File: Program_Prototype.cs
using System;
using System.Text;

namespace PrototypeFigure
{
    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    class Rectangle : IFigure
    {
        int width;
        int height;
        public Rectangle(int w, int h) { width = w; height = h; }
        public IFigure Clone() { return new Rectangle(this.width, this.height); }
        public void GetInfo() { Console.WriteLine("Прямокутник довжиною {0} и шириною {1}", height, width); }
    }

    class Circle : IFigure
    {
        int radius;
        public Circle(int r) { radius = r; }
        public IFigure Clone() { return new Circle(this.radius); }
        public void GetInfo() { Console.WriteLine("Круг радіусом {0}", radius); }
    }

    // Triangle implementation (new)
    class Triangle : IFigure
    {
        double a;
        double b;
        double c;

        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public IFigure Clone()
        {
            return new Triangle(this.a, this.b, this.c);
        }

        public void GetInfo()
        {
            Console.WriteLine("Трикутник зі сторонами a={0}, b={1}, c={2}", a, b, c);
        }
    }

    class Prototype
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IFigure figure = new Rectangle(10, 20);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            figure = new Circle(15);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            figure = new Triangle(3, 4, 5);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            Console.WriteLine("Press any key...");
            Console.Read();
        }
    }
}
