using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bernadette_Alvarado_Exercise02
{
    public class Program
    {
        public static BooksEntities book = new BooksEntities();

        static void Main(string[] args)
        {

            // 1. Get a list of all the titles and the authors who wrote them. Sort the results by title.
            var bookSortTitle = from book in book.Titles
                           from author in book.Authors
                           orderby book.Title1
                           select new { book.Title1, author.FirstName, author.LastName };

            Console.WriteLine("Book List sorted by Title:\n");
            foreach (var item in bookSortTitle)
            {
                Console.WriteLine($"{item.Title1,-60}{item.FirstName,-10}{item.LastName,-10}");
            }

            Console.WriteLine("\n\n");

            // 2. Get a list of all the titles and the authors who wrote them. Sort the results by title. Each title sort the authors 
            // alphabetically by last name, then first name

            Console.WriteLine("Book List sorted by Title and Author:\n");
            var bookSortAuthor = from book in book.Titles
                                         from author in book.Authors
                                         orderby book.Title1, author.LastName, author.FirstName
                                         select new { author.FirstName, author.LastName, book.Title1 };

            foreach (var item in bookSortAuthor)
            {
                Console.WriteLine($"{item.Title1,-60}{item.FirstName,-10}{item.LastName,-10}");
            }

            Console.WriteLine("\n\n");

            // 3.  Get a list of all the authors grouped by title, sorted by title; for a given title sort the author names 
            // alphabetically by last name then first name.

            Console.WriteLine("Book List grouped by Title, sorted by Title and Author:\n");
            var bookGroupTitleSortAuthor = from book in book.Titles
                                           orderby book.Title1 ascending
                                           select new
                                           { book.Title1, Authors = from author in book.Authors
                                                         orderby author.LastName, author.FirstName
                                                         select author };

            foreach (var item in bookGroupTitleSortAuthor)
            {
                Console.WriteLine($"{item.Title1,-60}");
                foreach (var authorItem in item.Authors)
                {
                    Console.WriteLine($"{authorItem.FirstName,-5}{authorItem.LastName}");
                }
                Console.WriteLine("\n");
            }

        }
    }
}
