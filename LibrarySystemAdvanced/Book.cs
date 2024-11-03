using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdvanced
{
    public class Book
    {
        public string Title { get; set; }
        
        public string Author { get; set; }

        public int PublishingYear { get; set; }

        public int ISBN {  get; set; }



        public Book(string title,string author, int publishingYear, int isbn )
        {
            Title = title;
            Author = author;
            PublishingYear = publishingYear;
            ISBN = isbn;

        }
    }
}
