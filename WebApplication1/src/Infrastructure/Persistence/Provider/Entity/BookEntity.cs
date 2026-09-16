using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Adpater.Secondary.Provider;

public class BookEntity
{
    [Key]
    public string ISBN { get; set; }
    public string Title { get; set; }
}
