using WebApplication1;

namespace TestProject1;

public class CreateBookTest
{
    [Fact]
    public void WhenCreatingBook_ThenISBNIsRegistred()
    {
        String isbn = "1234567890";
        var repository = new BookRepositoryStub();
        BookService bookService = new BookService(repository);
        
        bookService.Create(isbn, "");
        
        Assert.Equal(isbn, repository.Books[0].ISBN);
    }
    
    [Fact]
    public void WhenCreatingBook_ThenTitleIsRegistred()
    {
        String isbn = "1234567890";
        String title = "Title";
        var repository = new BookRepositoryStub();
        BookService bookService = new BookService(repository);
        
        bookService.Create(isbn, title);
        
        Assert.Equal(title, repository.Books[0].Title);
    }

    [Fact]
    public void WhenCreatingBookAndISNAlreadyExist_ThenError()
    {
        String isbn = "ALREADY_EXIST";
        String title = "Title";
        var repository = new BookRepositoryStub()
        {
            isAlreadyExist = true
        };
        BookService bookService = new BookService(repository);
        
        Assert.Throws<AlreadyExistException>(() => bookService.Create(isbn, title));
    }
}