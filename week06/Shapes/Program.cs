using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Shapes Area Calculator\n");
        
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));
        shapes.Add(new Square("Yellow", 2.5));
        shapes.Add(new Rectangle("Purple", 3, 3));

        Console.WriteLine("Shape Collection:");
        Console.WriteLine("-----------------");
        
        foreach (Shape shape in shapes)
        {
            string shapeType = shape.GetType().Name;
            Console.WriteLine($"{shapeType,-10} | Color: {shape.GetColor(),-7} | Area: {shape.GetArea()}"); 
        }

        Console.WriteLine("\nProgram completed successfully.");
    }
}