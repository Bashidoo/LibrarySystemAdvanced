using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemAdvanced
{
    public class Menu
    {
        bool running = true;

        private Library _library;
        

        public Menu(Library library) 
        { 
            _library = library;
            
        }

        public void Show()
        {
            while (running)
            {
                Console.WriteLine("1. AddBook");
                Console.WriteLine("2. Add author");
                Console.WriteLine("3. Update book details.");
                Console.WriteLine("4. Update author details");
                Console.WriteLine("5. Remove book");
                Console.WriteLine("6. Remove Author");
                Console.WriteLine("7. Display All books and its Authors");
                Console.WriteLine("8. Search and filter books");
                Console.WriteLine("9. Exit and Save Data");

                char? choice = Convert.ToString(Console.ReadLine())[0];

                switch(choice)
                {

                    case '1':
                        AskforInfoToAddBook();
                        break;
                    case '2':
                        AskforInfoToAddAuthor();
                        break;
                    case '3':
                        
                        int isbn = _library.GetValidatedNumberInput("\nPlease Enter Book ISBN\n");
                        _library.UpdateBook(isbn);
                        
                        break;
                    case '4':
                        
                        int id = _library.GetValidatedNumberInput("\nPlease Enter Author ID\n");
                        _library.UpdateAuthor(id);
                        
                        break;
                    case '5':
                        AskforInfoToRemoveBook();
                        break;
                    case '6':
                        AskforInfoToRemoveAuthor();


                        break;
                    case '7':
                        _library.DisplayAllBooks();
                        _library.DisplayAllAuthors();
                        
                        break;
                    case '8':
                        Console.WriteLine("Enter the search criteria (leave blank to skip):");

                        Console.Write("Author: ");
                        string? author = Console.ReadLine(); // no validator as its optional

                        // Get the publishing year using GetValidatedNumberInput
                        Console.Write("Publishing Year (optional, press Enter to skip): ");
                        int? publishingYear = null;
                        string? input = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input))
                        {
                            publishingYear = null;
                        }

                        Console.WriteLine("How would you like to sort the results?");
                        Console.WriteLine("1. By Title");
                        Console.WriteLine("2. By Author");
                        Console.WriteLine("3. By Year of Publication");
                        
                        string sortOption = _library.GetValidatedStringInput("Enter your choice (1-3): ");

                        string sortBy = sortOption switch
                        {
                            "1" => "title",
                            "2" => "author",
                            "3" => "year",
                            _ => "title" // Default sort by title
                        };

                        _library.SearchAndFilterBooks(author, publishingYear, sortBy);
                        break;
                      
                    case '9':
                        Console.WriteLine();
                        running = false;
                        break;

                }
            }
        }

        private void AskforInfoToAddBook()
        {
            int isbn = _library.GetValidatedNumberInput("Enter Book ISBN");

            
            string? title = _library.GetValidatedStringInput("Enter Book Title");

            string? genre = _library.GetValidatedStringInput("Enter Book Genre");

            
            string? authorName = _library.GetValidatedStringInput("Enter Authors Name");
            

            int publishingYear = _library.GetValidatedNumberInput("Enter Book Publishing Year"); 

            var book = new Book(title, authorName, publishingYear, isbn,genre);

            _library.AddBook(book);

        }
        private void AskforInfoToRemoveBook()
        {
            int isbn = _library.GetValidatedNumberInput("Enter Book ISBN.");
            _library.RemoveBook(isbn);
        }

        private void AskforInfoToAddAuthor()
        {
           
            string? authorName = _library.GetValidatedStringInput("Enter Author name:");
           
            string? authorCountry = _library.GetValidatedStringInput("\nEnter Author Country:");
            
            int authorID = _library.GetValidatedNumberInput("Enter Author ID.");
            var auhtor = new Author(authorName, authorID, authorCountry);
            _library.Authors.Add(auhtor);

        }
        private void AskforInfoToRemoveAuthor()
        {
           
            string? nameOfAuthor = _library.GetValidatedStringInput("Enter the Authors name to Remove him.");
           _library.RemoveAuthor(nameOfAuthor);
        }

    }
}
