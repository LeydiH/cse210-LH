
namespace Learning05
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Square("Red", 5));
            shapes.Add(new Rectangle("Blue", 5, 10));
            shapes.Add(new Circle("Green", 5));

            foreach (var shape in shapes)
            {
                Console.WriteLine("Color: " + shape.GetColor());
                Console.WriteLine("Area: " + shape.GetArea());
                Console.WriteLine();
            }
        }
    }

    class Shape
    {
        protected string _color;
        public string GetColor() { return _color; }
        public void SetColor(string value) { _color = value; }

        public Shape(string color)
        {
            _color = color;
        }

        public virtual double GetArea()
        {
            return 0;
        }
    }

    class Square : Shape
    {
        private double _side;

        public Square(string color, double side) : base(color)
        {
            _side = side;
        }

        public override double GetArea()
        {
            return _side * _side;
        }
    }

    class Rectangle : Shape
    {
        private double _width;
        private double _height;

        public Rectangle(string color, double width, double height) : base(color)
        {
            _width = width;
            _height = height;
        }

        public override double GetArea()
        {
            return _width * _height;
        }
    }

    class Circle : Shape
    {
        private double _radius;

        public Circle(string color, double radius) : base(color)
        {
            _radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * _radius * _radius;
        }
    }
}
