namespace WebApplication1.Presentation.Primary.Resource;

public record BookResource(string title, string isbn)
{
    public static BookReourceBuilder Builder => new();

    public class BookReourceBuilder(string isbn = "", string title = "")
    {
        public BookReourceBuilder WithTitle(string pTitle) => new(isbn, pTitle);
        public BookReourceBuilder WithIsbn(string pIsbn) => new (pIsbn, title);
        public BookResource Build() => new(title, isbn);
    }
}