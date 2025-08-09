using API.Accounts.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Accounts.Infrastructure.Features.UserDeletionTokens
{
    internal class UserDeletionTokenConfig : IEntityTypeConfiguration<UserDeletionToken>
    {
        public void Configure(EntityTypeBuilder<UserDeletionToken> builder)
        {
            builder.ToTable("user_deletion_tokens");
        }
    }
}
