using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace LibrarySystemAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var library = new Library(); // Library object with the following added lists which are Book and Authors

            string dataJsonFilePath = "data.json"; //json file name


            try
            {
                // Read and deserialize JSON file into MyDB object
                string allDatafromJsonType = File.ReadAllText(dataJsonFilePath);
                MyDB myDB = JsonSerializer.Deserialize<MyDB>(allDatafromJsonType)!;

                // Add deserialized books to the library
                library.Books.AddRange(myDB.AllBooksFromDB); // Library.Books.Add is not working, AddRange is working maybe because it has a list of books so it considers it as a range.
                Console.WriteLine("Books successfully added from JSON.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
            }
            //string allDatafromJsonType = File.ReadAllText(dataJsonFilePath);

            //MyDB myDB = JsonSerializer.Deserialize<MyDB>(allDatafromJsonType)!;

            //List<Book> allBooksFromJson = myDB.AllBooksFromDB;



            var author1 = new Author("Busherino",123456, "Syria"); 
            
            var book1 = new Book("Niggalations", "Busher Abo Dan", 2002, 268242444, "Action"); 


            library.AddAuthor(author1);
            library.Books.Add(book1);
            

            var menu = new Menu(library);
            menu.Show();
            
        }
    }
}
