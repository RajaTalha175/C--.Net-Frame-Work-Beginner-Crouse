using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Advance_Crouse
{
    public  class AdvanceCrouseIntro
    {
        public string Title { get; set; }
        public int Price { get; set; }


        public IEnumerable<AdvanceCrouseIntro> BooksDisplay()
        {
            return new List<AdvanceCrouseIntro>
            {
                 new AdvanceCrouseIntro { Title = "English", Price = 10 },
            new AdvanceCrouseIntro { Title = "Urdu", Price = 20 },
            new AdvanceCrouseIntro { Title = "Science", Price = 30 },
            new AdvanceCrouseIntro { Title = "Islamiyat", Price = 40 },
            new AdvanceCrouseIntro { Title = "Biology", Price = 50 }
            };
        }
    }

    ////// use class for Async and await Example

    public class MultiTasking
    {
     

}
}
