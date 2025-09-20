using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Intermidiate_Crouse
{
   
        public abstract class Shape
        {
            public string name { get; set; }

            public Shape(string Name)
            {
                name = Name;
            }
            public abstract double Area();

            public virtual void Draw()
            {
                Console.WriteLine($"Draw a Shape: {name}");
            }
        }

        public class Cricle : Shape
        {
            public double radis { get; set; }

            public Cricle(string name, double radis) : base(name)
            {
                this.radis = radis;
            }
            public override double Area()
            {
                return Math.PI * radis * radis;
            }
            public override void Draw()
            {
                Console.WriteLine($"Draw a Cricle Name: {name} and Radis: {radis}");
            }
        }

    public class Triangle : Shape
    {
        public double BaseLength { get; set; }
        public double heigth { get; set; }
        public Triangle(string name, double baselength, double heigth) : base(name)
        {
            BaseLength = baselength;
            this.heigth = heigth;
        }
        public override double Area()
        {
            return 0.5 * BaseLength * heigth;
        }
        public override void Draw()
        {
            Console.WriteLine($"Draw a Triangle Name: {name} and BaseLength: {BaseLength} and Heigth {heigth}");
        }
    }
    
}
