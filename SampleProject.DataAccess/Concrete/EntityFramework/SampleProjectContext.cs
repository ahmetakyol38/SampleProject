using System.Data.Entity;
using SampleProject.DataAccess.Concrete.EntityFramework.Mappings;
using SampleProject.Entities.Concrete;

namespace SampleProject.DataAccess.Concrete.EntityFramework
{
    public class SampleProjectContext : DbContext
    {
        public SampleProjectContext()
        {
            Database.SetInitializer<SampleProjectContext>(null);
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}
