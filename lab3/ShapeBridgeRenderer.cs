using System;
using System.Text;

namespace Lab3_Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IRenderer vector = new VectorRenderer();
            IRenderer raster = new RasterRenderer();

            Shape circle = new Circle(vector);
            circle.Draw();

            Shape square = new Square(raster);
            square.Draw();

            Shape triangle = new Triangle(raster);
            triangle.Draw();

            Shape vectorTriangle = new Triangle(vector);
            vectorTriangle.Draw();

            Console.ReadKey();
        }
    }

    public interface IRenderer
    {
        void RenderShape(string shapeName);
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderShape(string name) => Console.WriteLine($"Drawing {name} as vectors");
    }

    public class RasterRenderer : IRenderer
    {
        public void RenderShape(string name) => Console.WriteLine($"Drawing {name} as pixels");
    }

    public abstract class Shape
    {
        protected IRenderer _renderer;
        protected Shape(IRenderer renderer) => _renderer = renderer;
        public abstract void Draw();
    }

    public class Circle : Shape
    {
        public Circle(IRenderer renderer) : base(renderer) { }
        public override void Draw() => _renderer.RenderShape("Circle");
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer) { }
        public override void Draw() => _renderer.RenderShape("Square");
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer) { }
        public override void Draw() => _renderer.RenderShape("Triangle");
    }
}
