using System.Collections.Generic;

namespace L_1_7.Entities
{
    public class BookLibrary
    {
        private readonly Dictionary<Author, List<Book>> _booksByAuthor;

        //Public part

        public BookLibrary()
        {
            _booksByAuthor = new Dictionary<Author, List<Book>>();
        }

        //Add
        public bool AddAuthor(Author author)
        {
            if (!Author.IsAuthorValid(author) || ContainsAuthor(author)) return false;

            _booksByAuthor.Add(author, new List<Book>());

            return true;
        }
        public bool AddBook(Book book)
        {
            if (!Book.IsBookValid(book) || !Author.IsAuthorValid(book.Author)) return false;

            if (ContainsAuthor(book.Author))
                if (ContainsBook(book))
                    return false;
                else
                    AddAuthor(book.Author);

            _booksByAuthor[book.Author].Add(book);

            return true;
        }

        //SetBookAvailable & SetBookUnavailable in single method
        public void SetBookAvailability(Book book, bool availability)
        {
            if (!ContainsAuthor(book.Author) && !ContainsBook(book)) return;
            var authorBooks = _booksByAuthor[book.Author];
            var bookIndex = authorBooks.IndexOf(book);
            authorBooks[bookIndex].IsAvailable = availability;
        }

        //Private part

        //Contains
        private bool ContainsBook(Book book)
        {
            return _booksByAuthor[book.Author].Contains(book);
        }

        private bool ContainsAuthor(Author author)
        {
            return _booksByAuthor.ContainsKey(author);
        }
    }
}
