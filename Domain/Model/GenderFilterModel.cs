namespace Library.Domain.Model
{
    public class BookFilterModel
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Authors { get; set; } = new();
        public List<string> Genders { get; set; } = new();
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
