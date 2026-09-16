using WebApplication1.Adpater.Secondary.Provider;
using WebApplication1.Domain.Port.Primary.Command;

namespace WebApplication1;

public class TransactionalCommandHandler<TCommand, TPresenter>(ICommandHandler<TCommand, TPresenter> commandHandler,  LibraryDbContext dbContext) 
    : ICommandHandler<TCommand, TPresenter>
{
    public void Handle(TCommand command, TPresenter presenter)
    {
        using (var transaction = dbContext.Database.BeginTransaction())
        {
            commandHandler.Handle(command, presenter);
            transaction.Commit();
        }
    }
}