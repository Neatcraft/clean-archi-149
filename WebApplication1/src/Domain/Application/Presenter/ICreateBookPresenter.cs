namespace WebApplication1.Domain.Application.Presenter;

public interface ICreateBookPresenter
{
    void HandleSuccess();
    void HandleFailure(IError error);
}