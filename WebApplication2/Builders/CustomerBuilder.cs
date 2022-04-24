using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.Services;

namespace WebApplication2.Builders
{
    public class CustomerBuilder
    {
        public CustomerBuilder(EntityTypeBuilder<Customer> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Username).IsRequired();
            entityBuilder.Property(t => t.Password).IsRequired();
        }
    }
}
