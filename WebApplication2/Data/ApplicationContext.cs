using Microsoft.EntityFrameworkCore;
using WebApplication2.Builders;
using WebApplication2.Services;

namespace WebApplication2.Data
{
   
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CustomerBuilder(modelBuilder.Entity<Customer>());
                
        }
    }
    
}
