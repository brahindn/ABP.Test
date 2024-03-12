using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebsiteParsing.Domain.Entities;

namespace WebsiteParsing.DataAccess.EntityConfiguration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasIndex(c => new { c.ModelName, c.ModelCode, c.DateRange }).IsUnique();
        }
    }
}
