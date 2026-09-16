namespace WebApplication1.Adpater.Secondary.Provider;

public interface IBookDao
{
    public void Add(BookEntity bookEntity);
    BookEntity FindByIsbn(string isbn);
    bool IsAlreadyExist(string isbn);
}