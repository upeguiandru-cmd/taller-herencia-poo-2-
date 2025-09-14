using System;
using System.Globalization;

namespace Geometry
{
    public abstract class GeometricFigure
    {
        public string Name { get; protected set; }
        protected GeometricFigure(string name) => Name = name;
        public abstract double GetArea();
        public abstract double GetPerimeter();

        public override string ToString()
        {
            var area = GetArea().ToString("N5", CultureInfo.InvariantCulture);
            var per = GetPerimeter().ToString("N5", CultureInfo.InvariantCulture);
            return $"{Name.PadRight(13)} => Area......: {area,12} Perimeter: {per,12}";
        }
    }

    public class Square : GeometricFigure
    {
        protected double _a;
        public double A
        {
            get => _a;
            set { if (value <= 0) throw new ArgumentException("A must be > 0"); _a = value; }
        }
        public Square(string name, double a) : base(name) => A = a;
        public override double GetArea() => A * A;
        public override double GetPerimeter() => 4 * A;
    }

    public class Rectangle : Square
    {
        protected double _b;
        public double B
        {
            get => _b;
            set { if (value <= 0) throw new ArgumentException("B must be > 0"); _b = value; }
        }
        public Rectangle(string name, double a, double b) : base(name, a) => B = b;
        public override double GetArea() => A * B;
        public override double GetPerimeter() => 2 * (A + B);
    }

    public class Parallelogram : Rectangle
    {
        protected double _h;
        public double H
        {
            get => _h;
            set { if (value <= 0) throw new ArgumentException("H must be > 0"); _h = value; }
        }
        public Parallelogram(string name, double a, double b, double h) : base(name, a, b) => H = h;
        public override double GetArea() => B * H;
        // Perimeter = 2*(A+B) (inherited from Rectangle override)
    }

    public class Triangle : Rectangle
    {
        protected double _c;
        protected double _h;
        public double C
        {
            get => _c;
            set { if (value <= 0) throw new ArgumentException("C must be > 0"); _c = value; }
        }
        public double H
        {
            get => _h;
            set { if (value <= 0) throw new ArgumentException("H must be > 0"); _h = value; }
        }
        public Triangle(string name, double a, double b, double c, double h) : base(name, a, b)
        {
            C = c; H = h;
        }
        public override double GetArea() => (B * H) / 2.0;
        public override double GetPerimeter() => A + B + C;
    }

    public class Trapeze : Triangle
    {
        protected double _d;
        public double D
        {
            get => _d;
            set { if (value <= 0) throw new ArgumentException("D must be > 0"); _d = value; }
        }
        public Trapeze(string name, double a, double b, double c, double d, double h)
            : base(name, a, b, c, h) => D = d;
        public override double GetArea() => ((B + D) * H) / 2.0;
        public override double GetPerimeter() => A + B + C + D;
    }

    public class Rhombus : Square
    {
        protected double _d1;
        protected double _d2;
        public double D1
        {
            get => _d1;
            set { if (value <= 0) throw new ArgumentException("D1 must be > 0"); _d1 = value; }
        }
        public double D2
        {
            get => _d2;
            set { if (value <= 0) throw new ArgumentException("D2 must be > 0"); _d2 = value; }
        }
        public Rhombus(string name, double a, double d1, double d2) : base(name, a) { D1 = d1; D2 = d2; }
        public override double GetArea() => (D1 * D2) / 2.0;
        public override double GetPerimeter() => 4 * A;
    }

    public class Kite : Rhombus
    {
        protected double _b;
        public double B
        {
            get => _b;
            set { if (value <= 0) throw new ArgumentException("B must be > 0"); _b = value; }
        }
        public Kite(string name, double a, double d1, double d2, double b) : base(name, a, d1, d2) => B = b;
        public override double GetArea() => (D1 * D2) / 2.0;
        public override double GetPerimeter() => 2 * (A + B);
    }

    public class Circle : GeometricFigure
    {
        protected double _r;
        public double R
        {
            get => _r;
            set { if (value <= 0) throw new ArgumentException("R must be > 0"); _r = value; }
        }
        public Circle(string name, double r) : base(name) => R = r;
        public override double GetArea() => Math.PI * R * R;
        public override double GetPerimeter() => 2 * Math.PI * R;
    }
}
