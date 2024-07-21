using Microsoft.EntityFrameworkCore;

namespace Libraty.Data
{
    public class DefaultContext : DbContext
    {
        private const string Schema = "Library";

        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
            if (!Database.IsInMemory())
                Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DefaultContext).Assembly);
        }
    }
}
