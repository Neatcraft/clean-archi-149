using Microsoft.AspNetCore.Mvc;
using WebApplication1;
using WebApplication1.Adpater.Secondary;
using WebApplication1.Adpater.Secondary.Provider;
using WebApplication1.Presentation.Primary;
using WebApplication1.Presentation.Primary.Resource;

namespace TestProject1;

public class CreateBookTest
{
    private BookController init(IBookDao dao)
    {
        var repository = new BookRepository(dao);
        var service = new CreateBookCommandHandler(repository);
        return new (service, null);
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
        var result = sut.Create(bookResource) as ConflictObjectResult;
        
        Assert.NotNull(result);
        
        var error = result.Value as ISBNAlreadyExistError;
        
        Assert.NotNull(error);
        Assert.Equal("ISBN already exist", error.Message);
    }
}