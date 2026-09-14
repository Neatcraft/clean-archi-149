using WebApplication1;

namespace TestProject1;

public class BookRepositoryStub : IBookRepository
{
    public bool isAlreadyExist { get; init; } = false;
    public IList<Book> Books { get; init; } = new List<Book>();
    public void Create(Book book)
    {
        Books.Add(book);
    }

    public bool IsAlreadyExist(string isbn)
    {
        return isAlreadyExist;
    }
}
