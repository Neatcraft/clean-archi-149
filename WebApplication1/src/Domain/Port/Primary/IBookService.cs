using WebApplication1.Domain.Port.Primary.Command;

namespace WebApplication1.Domain.Port.Primary;

public interface IBookService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="isbn"></param>
    /// <param name="title"></param>
    /// <exception cref="AlreadyExistsException"></exception>
    void Create(CreateBookCommand command);
}