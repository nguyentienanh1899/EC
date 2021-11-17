using EC.CORE.BaseEnumeration;
using EC.CORE.BusinessDomain;
using EC.INFRASTRUCTURE.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class PromotionConfiguration : ConfigurationBase<Promotion>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Promotion> builder)
        {
            builder.ToTable("Promotions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseMySqlIdentityColumn();

            builder.Property(x => x.Name).IsRequired();
        }
    }
}
