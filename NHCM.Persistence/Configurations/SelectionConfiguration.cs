using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NHCM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHCM.Persistence.Configurations
{
    class SelectionConfiguration : IEntityTypeConfiguration<Selection>
    {
        public void Configure(EntityTypeBuilder<Selection> builder)
        {
           
                builder.ToTable("Selection", "pol");

                builder.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('pol.selection_id_seq'::regclass)");

                builder.Property(e => e.CategoryId).HasColumnName("CategoryID");

                builder.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                builder.Property(e => e.EffectiveDate).HasColumnType("date");

                builder.Property(e => e.EventId)
                    .HasColumnName("EventID")
                    .HasColumnType("numeric");

                builder.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

                builder.Property(e => e.FinalNo).HasMaxLength(20);

                builder.Property(e => e.ModifiedBy).HasMaxLength(200);

                builder.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                builder.Property(e => e.OldPosition).HasMaxLength(200);

                builder.Property(e => e.OrganizationId)
                    .HasColumnName("OrganizationID")
                    .HasColumnType("numeric");

                builder.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                builder.Property(e => e.PositionId)
                    .HasColumnName("PositionID")
                    .HasColumnType("numeric");

                builder.Property(e => e.RankId).HasColumnName("RankID");

                builder.Property(e => e.ReferenceNo).HasMaxLength(200);

                builder.Property(e => e.Remarks).HasMaxLength(400);

                builder.Property(e => e.VerdictDate).HasColumnType("timestamp with time zone");

                builder.Property(e => e.VerdictRegNo).HasMaxLength(20);

                builder.HasOne(d => d.Organization)
                    .WithMany(p => p.Selection)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("fk_selection_organization");

                builder.HasOne(d => d.Position)
                    .WithMany(p => p.Selection)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_selection_position");
            
        }
    }
}
