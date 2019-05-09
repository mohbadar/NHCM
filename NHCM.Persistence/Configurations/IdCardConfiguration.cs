using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NHCM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHCM.Persistence.Configurations
{
    public class IdCardConfiguration : IEntityTypeConfiguration<IdCard>
    {
        public void Configure(EntityTypeBuilder<IdCard> builder)
        {
            builder.ToTable("IdCard", "rec");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .HasColumnType("numeric")
                .HasDefaultValueSql("nextval('rec.idcard_id_seq'::regclass)");

            builder.Property(e => e.CardClassType).HasMaxLength(50);

            builder.Property(e => e.CreatedOn)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("now()");

            builder.Property(e => e.ExpiryDate).HasColumnType("date");

            builder.Property(e => e.IssueDate).HasColumnType("date");

            builder.Property(e => e.ModifiedBy)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.ModifiedOn)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("now()");

            builder.Property(e => e.PersonId)
                .HasColumnName("PersonID")
                .HasColumnType("numeric");

            builder.Property(e => e.ReferenceNo).HasMaxLength(200);

            builder.Property(e => e.StatusId).HasColumnName("StatusID");

            builder.HasOne(d => d.Person)
                .WithMany(p => p.IdCard)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_idcard_person");
        }
    }
}
