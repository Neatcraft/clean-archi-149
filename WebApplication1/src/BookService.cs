namespace WebApplication1;

public class BookService(IBookRepository bookRepository)
{
    public void Create(string isbn, string title)
    {
        if (bookRepository.IsAlreadyExist(isbn))
        {
            throw new AlreadyExistException();
        }
        
        bookRepository.Create(new Book
        {
            ISBN = isbn,
            Title = title
        });
    }
}