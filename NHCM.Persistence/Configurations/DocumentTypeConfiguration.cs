using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NHCM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHCM.Persistence.Configurations
{
   public  class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ToTable("DocumentType", "look");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .HasDefaultValueSql("nextval('look.\"DocumentType_ID_seq\"'::regclass)");

            builder.Property(e => e.Description).HasMaxLength(200);

            builder.Property(e => e.Name).HasMaxLength(200);

            builder.Property(e => e.ScreenId).HasColumnName("ScreenID");
        }
    }
}
