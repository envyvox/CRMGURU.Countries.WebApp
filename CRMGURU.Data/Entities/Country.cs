using System;
using CRMGURU.Data.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRMGURU.Data.Entities
{
    public class Country : IUniqueIdentifiedEntity, INamedEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Area { get; set; }
        public uint Population { get; set; }

        public Guid CapitalId { get; set; }
        public City Capital { get; set; }

        public Guid RegionId { get; set; }
        public Region Region { get; set; }
    }

    public class CountyConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Area).IsRequired();
            builder.Property(x => x.Population).IsRequired();

            builder
                .HasOne(x => x.Capital)
                .WithMany()
                .HasForeignKey(x => x.CapitalId);

            builder
                .HasOne(x => x.Region)
                .WithMany()
                .HasForeignKey(x => x.RegionId);
        }
    }
}
