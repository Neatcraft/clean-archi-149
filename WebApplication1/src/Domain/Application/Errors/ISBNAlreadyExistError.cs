namespace WebApplication1;

public record ISBNAlreadyExistError() : IError
{
    public int Code { get; } = 1;
    public string Message { get; } = "ISBN already exist";
}