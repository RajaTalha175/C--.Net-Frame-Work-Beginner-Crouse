using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Advance_Crouse
{
   
   /// Simple Delegates
    public class HelloWorld<T>
    {
        public T item;

        public T Get()
        {
            return item;
        }

        public void Add(T item)
        {
            this.item = item;
        }
    }

    public class Program
    {
        // Delegate declare
        public delegate int Operation(int a, int b);

        // Methods that match the delegate signature
        public static int Add(int x, int y) => x + y;
        public static int Multiply(int x, int y) => x * y;

       
    }
    //////  Delegate with Constraints
}
