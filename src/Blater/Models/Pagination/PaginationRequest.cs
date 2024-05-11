namespace Blater.Models.Pagination;

public class PaginationRequest
{
    public required string TableName { get; set; }
    public required int Page { get; set; }
    public required int PageSize { get; set; }
    public required string ConditionText { get; set; }
    public string? OrderBy { get; set; }
}