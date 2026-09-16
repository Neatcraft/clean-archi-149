using WebApplication1.Adpater.Secondary.Provider;

namespace WebApplication1.Adpater.Secondary;

public class BookRepository(IBookDao bookDao) : IBookRepository
{
    public void Create(Book book)
    {
        BookEntity bookEntity = book.To(new CreateBookEntityBuilder());
        
        bookDao.Add(bookEntity);
    }

    public void Update(Book book)
    {
        BookEntity initialState = bookDao.FindByIsbn(book.ISBN);
        
        book.To(new UpdateBookEntityMapper(initialState));
    }

    public bool IsAlreadyExist(string isbn)
    {
        return bookDao.IsAlreadyExist(isbn);
    }
}

public class UpdateBookEntityMapper : IBookTransformer<BookEntity>
{
    private readonly BookEntity _initialState;

    public UpdateBookEntityMapper(BookEntity initialState)
    {
        _initialState = initialState;
    }

    public BookEntity Build(Book book)
    {
        return _initialState;
    }

    public IBookTransformer<BookEntity> WithISBN(string isbn)
    {
        return this;
    }

    public IBookTransformer<BookEntity> WithTitle(string title)
    {
        _initialState.Title = title;
        return this;
    }
}