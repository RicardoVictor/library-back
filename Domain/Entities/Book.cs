namespace Library.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public Guid GenderId { get; set; }
        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual Gender Gender { get; set; }

        public Book(string name, Guid genderId, Guid authorId)
        {
            SetGuid();
            Name = name;
            GenderId = genderId;
            AuthorId = authorId;
        }

        public void SetGuid()
        {
            Id = Guid.NewGuid();
        }
    }
}