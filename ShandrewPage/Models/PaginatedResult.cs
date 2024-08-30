namespace ShandrewPage.Models
{
    public class PaginatedResult<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public int totalPage { get; set; }
        public int totalRecord { get; set; }
    }
}
