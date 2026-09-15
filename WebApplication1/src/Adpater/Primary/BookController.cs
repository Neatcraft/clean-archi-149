using Microsoft.AspNetCore.Components.Web;
using WebApplication1.Adpater.Primary.Resource;
using WebApplication1.Domain.Port.Primary;
using WebApplication1.Domain.Port.Primary.Command;

namespace WebApplication1.Adpater.Primary;

public class BookController(IBookService bookService)
{
    public void Create(BookResource bookResource)
    {
        bookService.Create(
            CreateBookCommand.Builder
                .WithTitle(bookResource.title)
                .WithIsbn(bookResource.isbn)
                .Build()
        );
    }
}