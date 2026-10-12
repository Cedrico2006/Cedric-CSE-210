using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        Square s1 = new Square("red",2);
        Rectangle s2 = new Rectangle("red",2,4);
        Circle s3 = new Circle("red",2);

        shapes.Add(s1);
        shapes.Add(s2);
        shapes.Add(s3);

        foreach (Shape i in shapes)
        {
            string color = i.GetColor();
            double area = i.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}