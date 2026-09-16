namespace WebApplication1;

public interface ICanCheckISBN
{
    bool IsAlreadyExist(string isbn);
}

public interface IBookRepository : ICanCheckISBN
{
    public void Create(Book book);
}

