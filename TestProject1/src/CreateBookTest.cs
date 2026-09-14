using WebApplication1;

namespace TestProject1;

public class CreateBookTest
{
    [Fact]
    public void WhenCreatingBook_ThenISBNIsRegistred()
    {
        String isbn = "1234567890";
        BookService bookService = new BookService(new BookRepositoryStub());
        
        bookService.Create(isbn);
        
        Assert.Equal(isbn, BookRepositoryStub.Books[0].ISBN);
        
    }
}