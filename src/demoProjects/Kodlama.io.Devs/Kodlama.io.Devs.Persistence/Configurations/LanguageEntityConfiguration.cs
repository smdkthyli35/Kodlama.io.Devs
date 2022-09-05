using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistence.Configurations
{
    public class LanguageEntityConfiguration : BaseEntityConfiguration<Language>
    {
        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.Name).HasColumnName("Name");
            builder.Property(i => i.Name).HasMaxLength(100);
            builder.Property(i => i.Name).IsRequired();
            builder.ToTable("Languages");
        }
    }
}
