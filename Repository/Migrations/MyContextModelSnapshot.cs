// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Repository.Context;

namespace Repository.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Domain.Entities.AnnouncementEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnName("marca")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<int>("Mileage")
                        .HasColumnName("quilometragem")
                        .HasColumnType("integer");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnName("model")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnName("observaoca")
                        .HasColumnType("text");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnName("version")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<int>("Year")
                        .HasColumnName("ano")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Announcements");
                });
#pragma warning restore 612, 618
        }
    }
}
