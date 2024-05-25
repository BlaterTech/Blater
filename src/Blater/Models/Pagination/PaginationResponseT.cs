using Blater.JsonUtilities;

namespace Blater.Models.Pagination;

public class PaginationResponse<T> : BasePaginationResponse
{
    public List<T> Items { get;  }

    public PaginationResponse(BasePaginationResponse response)
    {
        Page = response.Page;
        PageSize = response.PageSize;
        TotalPages = response.TotalPages;
        TotalItems = response.TotalItems;
        HasNextPage = response.HasNextPage;
        HasPreviousPage = response.HasPreviousPage;
        NextPage = response.NextPage;
        PreviousPage = response.PreviousPage;
        
        Items = [];
        
        if (response is PaginationResponse<T> paginationResponse)
        {
            Items = paginationResponse.Items;
        }
        
        if (response is PaginationResponse<string> stringPaginationResponse)
        {
            foreach (var item in stringPaginationResponse.Items)
            {
                var obj = item.FromJson<T>();
                if (obj != null)
                {
                    Items.Add(obj);
                }
            }
        }
    }
}