namespace Library.Domain.Entities
{
    public class Author
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public Author(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}