using WebApplication1.Adpater.Secondary.Provider;
using WebApplication1.Domain.Application.Query;

namespace WebApplication1;

public class FindBookByISBNQueryHandler(LibraryDbContext libraryDbContext) : IQueryHandler<FindBookByISBNQuery, BookReadModel?>
{
    public BookReadModel? Handle(FindBookByISBNQuery queryHandler)
    {
        return libraryDbContext.Books
                .Where(x => x.ISBN == queryHandler.ISBN)
                .Select(x => new BookReadModel(x.ISBN, x.Title))
                .FirstOrDefault();
    }
}