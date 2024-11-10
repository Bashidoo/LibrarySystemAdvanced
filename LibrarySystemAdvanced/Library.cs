using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibrarySystemAdvanced
{
    public class Library
    {

        public List<Book> Books { get; set; } = new List<Book>(); // To get the list of book from menu and set the information.
        public List<Author> Authors { get; set; } = new List<Author>(); // To get the list of author from menu and set the information
        

        public void AddBook(Book book)
        {

            Books.Add(book);
            Console.WriteLine($"{book.Title} by {book.Author}");
        }

        public void RemoveBook(int isbn) // Parameter for asking the isbn,
        {
            var booktoRemove = Books.Where(b => b.ISBN == isbn).ToList(); // Where to select the Book.

         
            
            if (booktoRemove.Any()) // If there is any book with the following ISBN.   ****************Add Logic If there is two books with the title******************
            {

                foreach (var book in booktoRemove)
                {
                    Books.Remove(book); // No try catch since it came from the GetValidatedNumberInput method. 
                    Console.WriteLine($"Book {book.Title} by {book.Author} has been removed from the library.");                      
                }
            }
            else
            {
                Console.WriteLine("Book not found, please try again.");
            }
               
            }


        public void UpdateBook(int isbn)
        {
            var bookToUpdate = Books.Where(b => b.ISBN == isbn).ToList();

            if (bookToUpdate.Any())
            {
                foreach (var book in bookToUpdate)
                {
                    Console.WriteLine($"{book.Title} by {book.Author} is now selected to update its details.");
                    Console.WriteLine("Enter new title for the book");
                    string? bookNewTitle = Convert.ToString(Console.ReadLine());
                    if (bookNewTitle != null)
                    {
                        book.Title = bookNewTitle;
                        Console.WriteLine($"Book Title updated. New book title is {book.Title}");

                    }
                    else if (string.IsNullOrEmpty(bookNewTitle))
                    {
                        Console.WriteLine("You have entered nothing.");
                    }
                    else
                    {
                        Console.WriteLine("Please enter a book title");
                    }


                }


            }
            else
            {
                Console.WriteLine("Book title not found");
            }
        }



        public void RemoveAuthor(string authorName)
        {

            var authorToRemove = Authors.Where(b => b.Name == authorName).ToList();
            Console.WriteLine("------------"); // Debugging of the authors in the list. They are two seperate lists.
            if (authorToRemove.Any())
            {
               foreach(var author in authorToRemove)
                {
                    Authors.Remove(author);
                    Console.WriteLine($"Author: {author.Name}  Removed successfully.");
                }
            }
            else
            {
                Console.WriteLine("Author not found with this name.");
            }
        }

        public void AddAuthor(Author author)
        {

            Console.WriteLine($"Author: {author.Name}, has been added"); // Debugging line.
            if (!Authors.Any(a => a.ID == author.ID || a.Name == author.Name))
            {
              Authors.Add(author);
              Console.WriteLine($"The Author {author.Name} has been added.");
            }
            else 
            { 
                Console.WriteLine($"Author: {author.Name}, is already added. Try another "); 
            }
         
        }


        public void UpdateAuthor(int ID)
        {
            var authorToUpdate = Authors.Where(a => a.ID == ID).ToList();

            if (authorToUpdate.Any())
            {              
                foreach (var author in authorToUpdate)
                {
                    Console.WriteLine($"Author: {author.Name} is now selected, with ID {author.ID}");
                    Console.WriteLine("Enter new Name for author.");
                    string? authorNewTitle = Convert.ToString(Console.ReadLine());
                    if (authorNewTitle != null)
                    {
                        author.Name = authorNewTitle;
                        Console.WriteLine($"Author name has been updated successfully, new author name is {author.Name}");
                    }
                    else if (string.IsNullOrEmpty(authorNewTitle))
                    {
                        Console.WriteLine("You have entered nothing.");
                    }
                    else
                    {
                        Console.WriteLine("Enter valid input");
                    }
                }

            }
            else
            {
                Console.WriteLine("Author not found. Try another ID");
            }

        }





        public void DisplayAllBooks()
        {
            if (Books.Any())
            {

                foreach (var bookWithoutAuthor in Books)
                {
                    string nulledAuthorName = "null";
                    if (bookWithoutAuthor.Author == null)
                    {
                        bookWithoutAuthor.Author = nulledAuthorName;
                    }

                }

            }

            Console.WriteLine("All Books in Library.");
            foreach (var book in Books)
            {

                Console.WriteLine($" ID: {book.ISBN}, Title: {book.Title}, Genre: {book.Genre}, Author : {book.Author}, Year : {book.PublishingYear}. AverageGrade :{book.AverageGrades:F2}");
            }
        }
        public void DisplayAllAuthors()
        {
            if (Authors.Any())
            {
                foreach (var author in Authors)
                {
                    Console.WriteLine($"Author: {author.Name} ID: {author.ID} Country: {author.Country}");
                }
            }
            else
            {
                Console.WriteLine("No Authors Found.");
            }
        }
        public void SearchAndFilterBooks(
               string? author = null,
               int? publishingYear = null,
              string sortBy = "title") // Default sorting by title
        {
            var filteredBooks = Books.AsQueryable();

            // Apply filters if values are provided
            if (!string.IsNullOrEmpty(author))
            {
                filteredBooks = filteredBooks.Where(b => b.Author == author);
            }

            if (publishingYear.HasValue)
            {
                filteredBooks = filteredBooks.Where(b => b.PublishingYear == publishingYear.Value);
            }

            // Sort based on the provided criteria
            switch (sortBy.ToLower())
            {
                case "year":
                    filteredBooks = filteredBooks.OrderBy(b => b.PublishingYear);
                    break;
                case "author":
                    filteredBooks = filteredBooks.OrderBy(b => b.Author);
                    break;
                case "title":
                default:
                    filteredBooks = filteredBooks.OrderBy(b => b.Title);
                    break;
            }

            // Display results
            Console.WriteLine("Search Results: ↓. Press 1 to reverse order ↑ or leave blank to continue");
            if (filteredBooks.Any())
            {
                string? input = Console.ReadLine();

                if (input != "1")
                {
                    filteredBooks.Reverse();
                    foreach (var book in filteredBooks)
                    {
                        Console.WriteLine(book);
                    }
                }
                else if (string.IsNullOrEmpty(input) || input == null)
                {
                foreach (var book in filteredBooks)
                    {
                    Console.WriteLine(book); 
                    }
                }
            }
            else
            {
                Console.WriteLine("No books found matching the criteria.");
            }
        }

        public int GetValidatedNumberInput(string prompt)
        {
            int number;
            while (true)
            {
                Console.Write(prompt);

                string? input = Console.ReadLine();
                try
                {

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have entered nothing.");
                        Console.ResetColor();
                    }
                    else
                    {
                        number = Convert.ToInt32(input);
                        return number;
                    }

                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter a valid input.");
                    Console.ResetColor();
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Number is too large.");
                    Console.ResetColor();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {e.Message}");
                    Console.ResetColor();
                }

            }

        }

        public string GetValidatedStringInput(string prompt)
        {

            string convertedString;      
            while (true) 
            {
                Console.Write(prompt);

                string? input = Console.ReadLine();
                try
                {

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have entered nothing.");
                        Console.ResetColor();
                    }
                    else
                    {
                        convertedString = Convert.ToString(input);
                        return convertedString;
                    }

                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter a valid input.");
                    Console.ResetColor();
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Number is too large.");
                    Console.ResetColor();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {e.Message}");
                    Console.ResetColor();
                }

            }

        }
    }
} 
