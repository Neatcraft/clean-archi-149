using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Adpater.Secondary.Provider;

public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
{
    public DbSet<BookEntity> Books => Set<BookEntity>();
}
