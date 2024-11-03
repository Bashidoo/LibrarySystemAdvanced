using System;
using System.Linq;
namespace LibrarySystemAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var library = new Library();

            
            
            var author1 = new Author("Busherino",123456, "Syria"); 
            
            var book1 = new Book("Niggalations", "Busher Abo Dan", 2002, 2682424); 


            library.AddAuthor(author1);
            library.Books.Add(book1);
            

            var menu = new Menu(library);
            menu.Show();
            
        }
    }
}
