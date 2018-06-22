using System.Collections.Generic;

namespace L_2_4.Task1
{
    public delegate bool BookSelectorDelegate(Book book);

    public class Catalog
    {
        public List<Book> Books { get; set; }

        public List<Book> SelectBooks(BookSelectorDelegate bookSelector)
        {
            var result = new List<Book>();

            foreach (var book in Books)
                if (bookSelector(book))
                    result.Add(book);

            return result;
        }
    }
}