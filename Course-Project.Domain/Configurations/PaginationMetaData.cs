namespace Course_Project.Domain.Configurations;

public class PaginationMetaData
{
    private int usersCount;
    private int pg;
    private int pageSize;
    private int v;
    private PaginationParams @params;

    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public PaginationMetaData(int totalCount, int pg, PaginationParams @params)
    {
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)@params.PageSize);
        CurrentPage = @params.PageIndex;

    }

    public PaginationMetaData(int v, PaginationParams @params)
    {
        this.v = v;
        this.@params = @params;
    }

    //public PaginationMetaData(int usersCount, int pg, int pageSize)
    //{
    //    this.usersCount = usersCount;
    //    this.pg = pg;
    //    this.pageSize = pageSize;
    //}
}
