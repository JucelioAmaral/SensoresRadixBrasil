// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sensores.Radix.Infra.Data.DbContexts;

namespace Sensores.Radix.Infra.Data.Migrations
{
    [DbContext(typeof(SensorEventContext))]
    [Migration("20210519015920_MigracaoInitial")]
    partial class MigracaoInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sensores.Radix.Domain.Entity.SensorEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnName("Country")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnName("Region")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("SensorName")
                        .IsRequired()
                        .HasColumnName("SensorName")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<long>("Timestamp")
                        .HasColumnName("Timestamp")
                        .HasColumnType("bigint");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnName("Valor")
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("Id");

                    b.ToTable("tblSensorEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
