using WebApplication1.Domain.Application.Presenter;
using WebApplication1.Domain.Port.Primary.Command;

namespace WebApplication1.Domain.Application.UseCase;

public interface ICreateBookUseCase
{
    void Execute(CreateBookCommand command, ICreateBookPresenter presenter);
}