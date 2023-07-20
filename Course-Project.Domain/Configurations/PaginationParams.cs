namespace Course_Project.Domain.Configurations;

public class PaginationParams
{
    private const int _maxPageSize = 10;
    private int _pageSize = 1;
    public int PageSize
    {
        get => _pageSize == 0 ? 10 : _pageSize;
        set => _pageSize = value > _maxPageSize ? _maxPageSize : value;
    }
    public int PageIndex { get; set; } = 1;
}
