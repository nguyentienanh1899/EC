
using EC.CORE.BaseEnumeration;
using EC.CORE.BusinessDomain;
using EC.INFRASTRUCTURE.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EC.INFRASTRUCTURE.Configurations
{ 
    public class TransactionConfiguration : ConfigurationBase<Transaction>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseMySqlIdentityColumn();

            builder.HasOne(x => x.AppUser).WithMany(x => x.Transactions).HasForeignKey(x => x.UserId);
        }
    }
}
