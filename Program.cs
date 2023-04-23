using System;
using System.Collections.Generic;

namespace ShapeClass
{
    public class Shape
    {
        public string Color { get; set; }
        public bool Filled { get; set; }
        public Shape()
        {
            Color = "Green";
            Filled = true;
        }
        public virtual double GetArea()
        {
            return 0;
        }
       

    }
    public interface IColorable
    {
        void HowToColor();
    }
    public class Circle : Shape, IColorable
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public override string ToString()
        {
            return "Circle: radius = " + Radius;
        }
     
        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
        public void HowToColor()
        {
            Console.WriteLine("Color all four sides.");
        }
    }
    public class Rectangle : Shape, IColorable
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override string ToString()
        {
            return "Rectangle: width = " + Width + ", height = " + Height;
        }
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

      

        public override double GetArea()
        {
            return Width * Height;
        }
        public void HowToColor()
        {
            Console.WriteLine("Color all four sides.");
        }
    }
    public class Square : Shape, IColorable
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public void HowToColor()
        {
            Console.WriteLine("Color all four sides.");
        }

        public override double GetArea()
        {
            return Side * Side;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[3];
            shapes[0] = new Circle(2);
            shapes[1] = new Rectangle(3, 4);
            shapes[2] = new Square(5);

            foreach (Shape shape in shapes)
            {
                Console.WriteLine("Shape: " + shape.GetType().Name);

                if (shape is Circle)
                {
                    Circle circle = (Circle)shape;
                    Console.WriteLine("Radius: " + circle.Radius);
                }
                else if (shape is Rectangle)
                {
                    Rectangle rectangle = (Rectangle)shape;
                    Console.WriteLine("Width: " + rectangle.Width);
                    Console.WriteLine("Height: " + rectangle.Height);
                }
                else if (shape is Square)
                {
                    Square square = (Square)shape;
                    Console.WriteLine("Side: " + square.Side);
                }

                Console.WriteLine("Area: " + shape.GetArea());

                if (shape is IColorable)
                {
                    IColorable colorableShape = (IColorable)shape;
                    colorableShape.HowToColor();
                }

                Console.WriteLine();
            }

            Console.ReadKey();

        }
    }
}
