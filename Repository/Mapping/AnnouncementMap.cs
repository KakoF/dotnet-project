using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Mapping
{
    public class AnnouncementMap : IEntityTypeConfiguration<AnnouncementEntity>
    {
        public void Configure(EntityTypeBuilder<AnnouncementEntity> builder)
        {
            builder.ToTable("Announcements");
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.Brand).IsRequired().HasMaxLength(45);
            builder.Property(u => u.Model).IsRequired().HasMaxLength(45);
            builder.Property(u => u.Version).IsRequired().HasMaxLength(45);
            builder.Property(u => u.Year).IsRequired();
            builder.Property(u => u.Mileage).IsRequired();
            builder.Property(u => u.Note).IsRequired();
        }
    }
}