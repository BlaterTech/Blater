using Blater.Extensions;

namespace Blater.Models.Pagination;

public class PaginationRequest<T> : PaginationRequest
{
    public PaginationRequest()
    {
        TableName = typeof(T).Name.ToSnakeCase();
    }
}