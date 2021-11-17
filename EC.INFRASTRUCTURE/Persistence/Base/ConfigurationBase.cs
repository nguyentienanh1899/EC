using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EC.CORE.BaseEntity;
using EC.CORE.BaseEnumeration;

namespace EC.INFRASTRUCTURE.Persistence.Base
{
    public abstract class ConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntityWithDateModified
    {
        /// <summary>
        /// Configures the entity.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            ConfigureEntity(builder);

            builder.Property(e => e.DeleteFlag)
                .IsRequired()
                .HasConversion(
                    e => e.Value,
                    e => DeleteFlag.FromValue(e))
                .HasDefaultValueSql(DeleteFlag.Available.Value.ToString());
        }
    }
}