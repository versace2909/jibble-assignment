namespace Application.Models
{
    public class DataSourceRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 20;
    }
}