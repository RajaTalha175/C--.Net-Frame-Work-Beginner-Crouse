using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Intermidiate_Crouse
{
    public class HelloWorld
    {
        private String[] arrArrays = { "1", "2", "1", "3", "1" };
        private String[] arrbooks = { "urdu", "English", "Science", "Math", "Computer" };

        /// Dictonry Use Indexes:
        public Dictionary<int, String> books;

        public string this[int index]
        {
            get { return arrArrays[index]; }
            set { arrArrays[index] = value; }
        }
        public string[] Arrays
        {
            get { return arrArrays; }
        }
        public HelloWorld()
        {

            books = new Dictionary<int, string>
        {
            {1, "Urdu"},
            {2, "English"},
            {3, "Science"},
            {4, "Math"},
            {5, "Computer"}
        };

        }
    }
}
