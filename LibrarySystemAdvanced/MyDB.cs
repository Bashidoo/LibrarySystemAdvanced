using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibrarySystemAdvanced
{
    public class MyDB
    {
        [JsonPropertyName("books")]
        public List<Book> AllBooksFromDB { get; set; } 

    }
}
