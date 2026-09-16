using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Domain.Port.Primary.Command;
using WebApplication1.Presentation.Primary.Presenter;
using WebApplication1.Presentation.Primary.Resource;

namespace WebApplication1.Presentation.Primary;

[ApiController]
[Route("api/books")]
public class BookController(CreateBookUseCase bookService) : ControllerBase
{
    [HttpPost]
    public IActionResult Create(BookResource bookResource)
    {
        var command = CreateBookCommand.Builder
            .WithTitle(bookResource.title)
            .WithIsbn(bookResource.isbn)
            .Build();
        var presenter = new CreateBookPresenter();
        
        bookService.Execute(command, presenter);
        
        if (!presenter.IsSuccess)
        {
            return Conflict(presenter.Error);
        }

        return Ok();
    }
}