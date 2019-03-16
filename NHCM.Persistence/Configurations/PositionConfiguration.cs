using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NHCM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHCM.Persistence.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {

            builder.ToTable("Position", "org");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .HasColumnType("numeric")
                .HasDefaultValueSql("nextval('org.position_id_seq'::regclass)");

            builder.Property(e => e.Code).HasMaxLength(20);

            builder.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

            builder.Property(e => e.DirectorateId).HasColumnName("DirectorateID");

            builder.Property(e => e.EducationLevelId).HasColumnName("EducationLevelID");

            builder.Property(e => e.Kadr).HasMaxLength(50);

            builder.Property(e => e.LocationId).HasColumnName("LocationID");

            builder.Property(e => e.ModifiedBy)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.OrganoGramId).HasColumnName("OrganoGramID");

            builder.Property(e => e.OrgunitId)
                .HasColumnName("OrgunitID")
                .HasColumnType("numeric");

            builder.Property(e => e.ParentId)
                .HasColumnName("ParentID")
                .HasColumnType("numeric");

            builder.Property(e => e.PlanTypeId).HasColumnName("PlanTypeID");

            builder.Property(e => e.PositionResponsibilityAndPurpose).HasMaxLength(600);

            builder.Property(e => e.PositionTypeId).HasColumnName("PositionTypeID");

            builder.Property(e => e.Profession).HasMaxLength(50);

            builder.Property(e => e.RankId).HasColumnName("RankID");

            builder.Property(e => e.ReferenceNo).HasMaxLength(14);

            builder.Property(e => e.Remarks).HasMaxLength(300);

            builder.Property(e => e.SalaryTypeId).HasColumnName("SalaryTypeID");

            builder.Property(e => e.Sorter).HasMaxLength(300);

            builder.Property(e => e.StatusId)
                .HasColumnName("StatusID")
                .HasDefaultValueSql("21");

            builder.Property(e => e.TransferPositionId)
                .HasColumnName("TransferPositionID")
                .HasColumnType("numeric");

            builder.HasOne(d => d.Parent)
                .WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("fk_position_position");

        }
    }
}
