namespace WebApplication1.Adpater.Secondary.Provider;

public class CreateBookEntityBuilder(string isbn = "", string title = "")
    : IBookTransformer<BookEntity>
{
    public BookEntity Build(Book book)
    {
        return new BookEntity { ISBN = isbn, Title = title };
    }

    public IBookTransformer<BookEntity> WithISBN(string isbn)
    {
        return new CreateBookEntityBuilder(isbn, title);
    }

    public IBookTransformer<BookEntity> WithTitle(string title)
    {
        return new CreateBookEntityBuilder(isbn, title);
    }
}