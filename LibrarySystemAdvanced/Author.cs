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
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("country")]
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
