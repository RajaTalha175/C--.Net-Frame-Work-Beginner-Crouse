using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Advance_Crouse
{
   public  static class ExtensionClass {
        public static int WordCount(this string str) {
            var count = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return count.Length;

        }
    }
}
