namespace WebApplication1;

public interface IError
{
    int Code { get; }
    string Message { get; }
}