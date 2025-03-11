using AM.ApplicationCore.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        // Configuration du type d'entité détenu FullName
        builder.OwnsOne(p => p.FullName, fullName =>
        {
            fullName.Property(f => f.FirstName)
                .HasMaxLength(30)
                .HasColumnName("PassFirstName");

            fullName.Property(f => f.LastName)
                .IsRequired()
                .HasColumnName("PassLastName");
        });
    }
}
