using API.Accounts.Domain.SagaMachineDatas.UserSoftDelete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Accounts.Infrastructure.Features.UserSoftDeleteSagaDatas
{
    internal class SagaDataConfig : IEntityTypeConfiguration<UserSoftDeleteSagaData>
    {
        public void Configure(EntityTypeBuilder<UserSoftDeleteSagaData> builder)
        {
            builder.ToTable("user_soft_delete_sagas");
            builder.HasKey(x => x.CorrelationId);

            builder
                .HasIndex(x => x.UserId)
                .IsUnique();

            builder
                .HasIndex(x => x.Email)
                .IsUnique();
        }
    }
}
