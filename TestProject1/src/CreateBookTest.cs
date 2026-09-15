using WebApplication1;
using WebApplication1.Adpater.Primary;
using WebApplication1.Adpater.Primary.Resource;

namespace TestProject1;

public class CreateBookTest
{
    private BookController init(BookRepositoryStub repository)
    {
        var service = new BookService(repository);
        return new (service);
    }
    
    [Fact]
    public void WhenCreatingBook_ThenISBNIsRegistred()
    {
        var bookResource = BookResource
            .Builder
            .WithIsbn("1234567890")
            .Build();
        
        var repository = new BookRepositoryStub();
        var sut = init(repository);
        
        sut.Create(bookResource);
        
        Assert.Equal(bookResource.isbn, repository.Books[0].ISBN);
    }
    
    [Fact]
    public void WhenCreatingBook_ThenTitleIsRegistred()
    {
        var bookResource = BookResource
            .Builder
            .WithIsbn("123344")
            .WithTitle("Title")
            .Build();
        
        var repository = new BookRepositoryStub();
        var sut = init(repository);
        
        sut.Create(bookResource);
        
        Assert.Equal(bookResource.title, repository.Books[0].Title);
    }

    [Fact]
    public void WhenCreatingBookAndISNAlreadyExist_ThenError()
    {
        var bookResource = BookResource
            .Builder
            .WithIsbn("123344")
            .WithTitle("Title")
            .Build();
        
        var repository = new BookRepositoryStub()
        {
            isAlreadyExist = true
        };
        var sut = init(repository);
        
        Assert.Throws<AlreadyExistException>(() => sut.Create(bookResource));
    }
}