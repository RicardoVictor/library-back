namespace Library.Domain.Entities
{
    public class Author
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public virtual ICollection<Book> Books { get; private set; }

        public Author(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}