namespace WebApplication1.Domain.Port.Primary.Command;

public record CreateBookCommand(string Isbn, string Title)
{
    public static CreateBookCommandBuilder Builder => new();

    public record CreateBookCommandBuilder(string isbn = "", string title = "Non Renseigné")
    {
        public CreateBookCommandBuilder WithIsbn(string isbn)
        {
            return new (isbn: isbn, title);
        }

        public CreateBookCommandBuilder WithTitle(string title)
        {
            return new (isbn, title);
        }

        public CreateBookCommand Build()
        {
            return new CreateBookCommand(isbn, title);
        }
    }
}