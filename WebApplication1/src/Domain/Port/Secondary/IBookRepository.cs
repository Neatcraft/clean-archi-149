namespace WebApplication1;

public interface IBookRepository
{
    public void Create(Book book);
    bool IsAlreadyExist(string isbn);
}

