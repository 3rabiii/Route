namespace Shared;

public record PaginatedResult<TEntity>(int PageSize,int PageIndex,int TotalCount,IEnumerable<TEntity> Data)
{
}