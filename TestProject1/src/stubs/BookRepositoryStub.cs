using WebApplication1;

namespace TestProject1;

public class BookRepositoryStub : IBookRepository
{
    public static IList<Book> Books { get; set; } = new List<Book>();
}
