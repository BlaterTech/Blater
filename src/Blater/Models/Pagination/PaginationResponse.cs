namespace Blater.Models.Pagination;

public class PaginationResponse : BasePaginationResponse
{
    public required IEnumerable<string> Items { get; set; }
}