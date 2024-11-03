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

        public string Genre { get; set; }

        public int PublishingYear { get; set; }

        public int ISBN {  get; set; }



        public Book(string title,string author, int publishingYear, int isbn, string genre)
        {
            Title = title;
            Author = author;
            PublishingYear = publishingYear;
            ISBN = isbn;
            Genre = genre;
        }
        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Genre: {Genre}, Year: {PublishingYear}, ISBN: {ISBN}"; // search result were not showing up. this was likely the cause.
        }
    }
}
