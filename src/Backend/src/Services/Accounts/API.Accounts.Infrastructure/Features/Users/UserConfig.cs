using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Aggregates.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Accounts.Infrastructure.Features.Users
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder
                .HasIndex(u => u.Username)
                .IsUnique();

            builder.OwnsOne(u => u.UserDetails, ownedBuilder =>
            {
                ownedBuilder.ToTable("user_details");
            });

            builder.OwnsMany(u => u.Emails, ownedBuilder =>
            {
                ownedBuilder
                    .HasIndex(u => u.Email)
                    .IsUnique();

                ownedBuilder.ToTable("user_emails");
            });

            builder
                .HasOne<UserDeletionToken>()
                .WithOne(x => x.User)
                .HasForeignKey<UserDeletionToken>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany<EmailVerificationToken>()
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
