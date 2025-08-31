using API.Accounts.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Accounts.Infrastructure.Features.EmailVerificationTokens
{
    internal class EmailVerificationTokenConfig : IEntityTypeConfiguration<EmailVerificationToken>
    {
        public void Configure(EntityTypeBuilder<EmailVerificationToken> builder)
        {
            builder.ToTable("email-verification-tokens");

            builder
                .HasIndex(x => x.Token)
                .IsUnique();
        }
    }
}
