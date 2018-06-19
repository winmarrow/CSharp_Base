namespace L_1_7.Entities
{
    public class Book
    {
        public string Title;
        public BookGenge Genre;
        public Author Author;

        public bool IsAvailable;

        public override bool Equals(object obj)
        {
            return obj is Book book 
                   && book.Title == this.Title 
                   && book.Genre == this.Genre
                   && book.Author == this.Author;
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