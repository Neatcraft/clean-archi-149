using Microsoft.AspNetCore.Mvc;
using WebApplication1.Domain.Application.Presenter;
using WebApplication1.Domain.Application.Query;
using WebApplication1.Domain.Port.Primary.Command;
using WebApplication1.Presentation.Primary.Presenter;
using WebApplication1.Presentation.Primary.Resource;

namespace WebApplication1.Presentation.Primary;

[ApiController]
[Route("api/books")]
public class BookController(
    ICommandHandler<CreateBookCommand, ICreateBookPresenter> createBookCommandHandler,
    IQueryHandler<FindBookByISBNQuery, BookReadModel?> findBookByISBNQueryHandler
    ) : ControllerBase
{
    [HttpPost]
    public IActionResult Create(BookResource bookResource)
    {
        var command = CreateBookCommand.Builder
            .WithTitle(bookResource.title)
            .WithIsbn(bookResource.isbn)
            .Build();
        
        var presenter = new CreateBookPresenter();
        
        createBookCommandHandler.Handle(command, presenter);
        
        if (!presenter.IsSuccess)
        {
            return Conflict(presenter.Error);
        }

        return Ok();
    }

    [HttpGet("/{isbn}")]
    public IActionResult FindByISBN(string isbn)
    {
        var bookReadModel = findBookByISBNQueryHandler.Handle(new FindBookByISBNQuery(isbn));

        if (bookReadModel is null) 
        {
            return NotFound();
        }

        return Ok(bookReadModel);
    }
}