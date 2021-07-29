using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sensores.Radix.Domain.Entity;

namespace Sensores.Radix.Infra.Data.Mappings
{
    public class SensorEventMapping : IEntityTypeConfiguration<SensorEvent>
    {
        public void Configure(EntityTypeBuilder<SensorEvent> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Timestamp)
                .HasColumnName("Timestamp")
                .IsRequired();

            builder.Property(e => e.SensorName)
                .HasColumnName("SensorName")
                .HasColumnType("VARCHAR(200)")
                .IsRequired();

            builder.Property(e => e.Valor)
               .HasColumnName("Valor")
               .HasColumnType("VARCHAR(200)")
               .IsRequired();

            builder.Property(e => e.Country)
               .HasColumnName("Country")
               .HasColumnType("VARCHAR(50)")
               .IsRequired();

            builder.Property(e => e.Region)
               .HasColumnName("Region")
               .HasColumnType("VARCHAR(50)")
               .IsRequired();

            builder.Ignore(e => e.Tag);
            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("tblSensorEvents");
        }
    }
}
