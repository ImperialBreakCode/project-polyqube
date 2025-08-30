using API.Accounts.Domain.SagaMachineDatas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Accounts.Infrastructure.Features.UserSagaDatas
{
    internal class EraseUserSagaDataConfig : IEntityTypeConfiguration<EraseUserSagaData>
    {
        public void Configure(EntityTypeBuilder<EraseUserSagaData> builder)
        {
            builder.ToTable("erase_user_sagas");
            builder.HasKey(x => x.CorrelationId);

            builder
                .HasIndex(x => x.UserId)
                .IsUnique();
        }
    }
}
