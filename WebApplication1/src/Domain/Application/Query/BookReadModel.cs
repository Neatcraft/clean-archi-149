namespace WebApplication1.Domain.Application.Query;

public record BookReadModel(string ISBN, string Title)
{
    public T To<T>(IBookReadModelBuilder<T> builder)
    {
        return builder
            .withISBN(ISBN)
            .withTitle(Title)
            .Build();
    }
}

public interface IBookReadModelBuilder<T>
{
    IBookReadModelBuilder<T> withISBN(string isbn);
    IBookReadModelBuilder<T> withTitle(string title);
    T Build();
}