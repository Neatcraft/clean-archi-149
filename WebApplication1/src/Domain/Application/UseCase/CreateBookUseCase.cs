using WebApplication1.Domain.Application.Presenter;
using WebApplication1.Domain.Application.UseCase;
using WebApplication1.Domain.Port.Primary;
using WebApplication1.Domain.Port.Primary.Command;

namespace WebApplication1;

public class CreateBookUseCase(IBookRepository bookRepository) : ICreateBookUseCase
{
    public void Execute(CreateBookCommand command, ICreateBookPresenter presenter)
    {
        Book book = new Book();

        if (bookRepository.IsAlreadyExist(command.Isbn))
        {
            presenter.HandleFailure(new ISBNAlreadyExistError());
            return;
        }
        
        bookRepository.Create(new Book
        {
            ISBN = command.Isbn,
            Title = command.Title
        });
        
        presenter.HandleSuccess();
    }
}