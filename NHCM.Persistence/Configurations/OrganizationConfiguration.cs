using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NHCM.Domain.Entities;

namespace NHCM.Persistence.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organization", "dbo");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .HasDefaultValueSql("nextval('dbo.organization_id_seq'::regclass)");

            builder.Property(e => e.AndssectorId).HasColumnName("ANDSSectorID");

            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.CreatedOn)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("now()");

            builder.Property(e => e.Dari)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.KeyOutComeDari).HasColumnName("KeyOutCome_Dari");

            builder.Property(e => e.ModifiedBy)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.ModifiedOn)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("now()");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.OrganizationTypeId).HasColumnName("OrganizationTypeID");

            builder.Property(e => e.ParentId)
                .HasColumnName("ParentID")
                .HasColumnType("numeric");

            builder.Property(e => e.Pashto)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.ReferenceNo).HasMaxLength(200);

            builder.Property(e => e.Sorter).HasMaxLength(50);

            builder.Property(e => e.StatusId).HasColumnName("StatusID");

            builder.Property(e => e.StrategicObject).HasMaxLength(2000);
        }
    }
}
