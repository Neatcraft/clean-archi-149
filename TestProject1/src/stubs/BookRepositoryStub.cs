using WebApplication1;
using WebApplication1.Adpater.Secondary.Provider;

namespace TestProject1;

public class BookRepositoryStub : IBookDao
{
    public bool isAlreadyExist { get; init; } = false;
    public IList<BookEntity> Books { get; init; } = new List<BookEntity>();

    public void Add(BookEntity bookEntity)
    {
        Books.Add(bookEntity);
    }

    public BookEntity FindByIsbn(string isbn)
    {
        throw new NotImplementedException();
    }

    public bool IsAlreadyExist(string isbn)
    {
        return isAlreadyExist;
    }
}
