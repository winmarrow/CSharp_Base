using System;
using System.Collections.Generic;
using System.Linq;

namespace L_2_4.Task1
{
    public class BookSorter
    {
        public static List<Book> SortByTitle(IEnumerable<Book> books)
        {
            var result = books.ToList();
            result.Sort((book1, book2) => String.Compare(book1.Title, book2.Title, StringComparison.Ordinal));
            return result;
        }
        public static List<Book> SortByDoP(IEnumerable<Book> books)
        {
            var result = books.ToList();
            result.Sort((book1, book2) => book1.DoP.CompareTo(book2.DoP));
            return result;
        }

        public static bool IsBookBefore85Year(Book book)
        {
            return book.DoP.Year < 1985;
        }

        public static bool IsContainsWordWoldInTitle(Book book)
        {
            return book.Title.Contains("world");
        }
    }
}