namespace L_1_7.Entities
{
    public class Book
    {
        public Author Author;
        public BookGenge Genre;

        public bool IsAvailable;
        public string Title;

        public override bool Equals(object obj)
        {
            return obj is Book book
                   && book.Title == Title
                   && book.Genre == Genre
                   && book.Author == Author;
        }

        //Static
        public static bool IsBookValid(Book book)
        {
            return book != null
                   && !string.IsNullOrWhiteSpace(book.Title)
                   && book.Author != null;
        }
    }
}