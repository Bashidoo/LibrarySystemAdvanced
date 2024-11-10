using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibrarySystemAdvanced
{
    public class Author
    {
         
        public string Name { get; set; }

      
        public int ID { get; set; }

      
        public string Country { get; set; }



        

        public Author(string name,int id, string country)
        {
            Name = name;
            ID = id;
            Country = country;
                 
        }

        public override string ToString()
        {
            return ($"ID: {ID}, Name: {Name}, Country: {Country}");
        }
    }
}
