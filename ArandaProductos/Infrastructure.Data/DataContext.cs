using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var cascadeFKs = modelBuilder.Model
            //  .G­etEntityTypes()
            //  .SelectMany(t => t.GetForeignKeys())
            //  .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            //foreach (var fk in cascadeFKs)
            //{
            //    fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            //}

            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
