using WebApplication1.Adpater.Secondary.Provider;

namespace WebApplication1;

public class Book()
{
    public string ISBN;
    public string Title;

    public T To<T>(IBookTransformer<T> bookTransformer)
    {
        return bookTransformer
            .WithISBN(ISBN)
            .WithTitle(Title)
            .Build(this);
    }
}