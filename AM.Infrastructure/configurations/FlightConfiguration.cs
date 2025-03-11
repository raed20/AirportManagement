using AM.ApplicationCore.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.configurations
{
    class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {

        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //configure *-* relationship
            builder.HasMany(f => f.Passengers)
                .WithMany(p => p.flights)
                .UsingEntity(t => t.ToTable("Reservations"));

            //configure 1-* relationship
            builder.HasOne(f => f.plane)
                .WithMany(p => p.flights)
                .HasForeignKey(f => f.PlaneFK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
