using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdvanced
{
    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();


        public Author(string name,int id, string country)
        {
            Name = name;
            ID = id;
            Country = country;
                 
        }
    }
}
