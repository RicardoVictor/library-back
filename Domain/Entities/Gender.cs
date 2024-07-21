namespace Library.Domain.Entities
{
    public class Gender
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Gender(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}