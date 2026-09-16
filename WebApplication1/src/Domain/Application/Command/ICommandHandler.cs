namespace WebApplication1.Domain.Port.Primary.Command;

public interface ICommandHandler<TCommand, TPresenter>
{
    void Handle(TCommand command, TPresenter presenter);
}