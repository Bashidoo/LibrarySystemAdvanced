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

        public List<int> Grades { get; set; } = new List<int>();



        public Book(string title,string author, int publishingYear, int isbn, string genre)
        {
            Title = title;
            Author = author;
            PublishingYear = publishingYear;
            ISBN = isbn;
            Genre = genre;
            
        }

        public void AddGrade(int grade)
        {

            Console.WriteLine("Add Grade too book (1-5).");

            if (grade < 1 || 5 < grade)
            {
                Console.WriteLine("Please type grade from 1 to 5");
            }
            else
            {
                Grades.Add(grade);
                Console.WriteLine($"Grade : {grade} has been added to {Title}");
            }

        }

        public double AverageGrades
        {
            get
            {
            
            if (Grades.Count == 0) return 0;
            return Grades.Average();

            }
        }
        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Genre: {Genre}, Year: {PublishingYear}, ISBN: {ISBN}"; // search result were not showing up. this was likely the cause.
        }
    }
}
