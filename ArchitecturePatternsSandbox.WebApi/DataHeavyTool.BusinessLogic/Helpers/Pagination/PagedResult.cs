namespace DataHeavyTool.BusinessLogic.Helpers.Pagination
{
    public class PagedResult<T>
    {
        public List<T> Data { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }
}
