using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WebsiteParsing.Domain.Entities;

namespace WebsiteParsing.DataAccess.EntityConfiguration
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasIndex(e => e.EquipmentName).IsUnique();
        }
    }
}
