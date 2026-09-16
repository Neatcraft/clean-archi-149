using WebApplication1.Domain.Application.Presenter;

namespace WebApplication1.Presentation.Primary.Presenter;

public class CreateBookPresenter : ICreateBookPresenter
{
    public bool IsSuccess { get; private set; }
    
    public IError Error { get; private set; }
    
    public void HandleSuccess()
    {
        IsSuccess = true;
    }

    public void HandleFailure(IError error)
    {
        IsSuccess = false;
        Error = error;
    }

}