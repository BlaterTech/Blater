namespace Blater.Models.Pagination;

public class BasePaginationResponse
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }
    public int NextPage { get; set; }
    public int PreviousPage { get; set; }
}