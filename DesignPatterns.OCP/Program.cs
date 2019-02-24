using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID.OCP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Open Closed principile
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();
            Debug.WriteLine("Green products (old):");
            foreach (var p in pf.FilterByColor(products, Color.Green))
                Debug.WriteLine($" - {p.Name} is green");

            // ^^ BEFORE

            // vv AFTER
            var bf = new BetterFilter();
            Debug.WriteLine("Green products (new):");
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
                Debug.WriteLine($" - {p.Name} is green");

            Debug.WriteLine("Large products");
            foreach (var p in bf.Filter(products, new SizeSpecification(Size.Large)))
                Debug.WriteLine($" - {p.Name} is large");

            Debug.WriteLine("Large blue items");
            foreach (var p in bf.Filter(products,
                new AndSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large)))
            )
            {
                Debug.WriteLine($" - {p.Name} is big and blue");
            }
        }
    }
}
