using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Intermidiate_Crouse
{
    public interface Branch1
    {
        string addressBranch1 { get; set; }
        void DisplayAddressBranch1();
    }


    public interface Branch2
    {
        string addressBranch2 { get; set; }
        void DisplayAddressBranch2();
    }


    public class TotalBranches : Branch1, Branch2
    {
        public string name { get; set; }
        public string addressBranch1 { get; set; }
        public string addressBranch2 { get; set; }

        public TotalBranches(string name)
        {
            this.name = name;
            addressBranch1 = "Gulberg Green Near Imtiaz Mall, Islamabad";
            addressBranch2 = "Khanapul Near PSO Petrol Pump Station, Islamabad";
        }

        public void DisplayAddressBranch1()
        {
            Console.WriteLine($"First Branch Name: {name} and Address: {addressBranch1}");
        }

        public void DisplayAddressBranch2()
        {
            Console.WriteLine($"Second Branch Name: {name} and Address: {addressBranch2}");
        }
    }
}
