using WebApplication1.Adpater.Secondary.Provider;
using WebApplication1.Domain.Application.Presenter;
using WebApplication1.Domain.Application.UseCase;
using WebApplication1.Domain.Port.Primary.Command;

namespace WebApplication1;

public class CreateBookUseCaseTransaction(CreateBookUseCase useCase,  LibraryDbContext dbContext) : ICreateBookUseCase
{
    public void Execute(CreateBookCommand command, ICreateBookPresenter presenter)
    {
        using (var transaction = dbContext.Database.BeginTransaction())
        {
            useCase.Execute(command, presenter);
            transaction.Commit();
        }
    }
}