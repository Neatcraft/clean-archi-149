namespace WebApplication1.Domain.Application.Query;

public interface IQueryHandler<TQuery, TReturn>
{
    TReturn Handle(TQuery query);
}