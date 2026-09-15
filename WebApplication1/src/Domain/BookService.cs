using WebApplication1.Domain.Port.Primary;
using WebApplication1.Domain.Port.Primary.Command;

namespace WebApplication1;

public class BookService(IBookRepository bookRepository) : IBookService
{
    public void Create(CreateBookCommand command)
    {
        if (bookRepository.IsAlreadyExist(command.Isbn))
        {
            throw new AlreadyExistException();
        }
        
        bookRepository.Create(new Book
        {
            ISBN = command.Isbn,
            Title = command.Title
        });
    }
}