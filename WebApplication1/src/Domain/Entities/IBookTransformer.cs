namespace WebApplication1;

public interface IBookTransformer<T>
{
    T Build(Book book);
    IBookTransformer<T> WithISBN(string isbn);
    IBookTransformer<T> WithTitle(string title);
}