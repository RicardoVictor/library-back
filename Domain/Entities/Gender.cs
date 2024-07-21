namespace Library.Domain.Entities
{
    public class Gender
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public virtual ICollection<Book> Books { get; private set; }

        public Gender(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}