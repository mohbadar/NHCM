﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NHCM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHCM.Persistence.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Documents>
    {
        public void Configure(EntityTypeBuilder<Documents> builder)
        {

                builder.ToTable("Documents", "dbo");

                builder.Property(e => e.Id)
                    .HasColumnName("ID")

                    .HasDefaultValueSql("nextval('dbo.\"Documents_ID_seq\"'::regclass)");


                builder.Property(e => e.ContentType)
                    .IsRequired()
                    .HasMaxLength(150);

                builder.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                builder.Property(e => e.Description).HasMaxLength(500);

                builder.Property(e => e.EncryptionKey).HasMaxLength(120);


                builder.Property(e => e.Item).HasMaxLength(50);

                builder.Property(e => e.LastDownloadDate).HasColumnType("timestamp with time zone");

                builder.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");


                builder.Property(e => e.Module).HasMaxLength(50);


                builder.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(300);

                builder.Property(e => e.RecordId)
                    .IsRequired()
                    .HasColumnName("RecordID")
                    .HasMaxLength(200);

                builder.Property(e => e.ReferenceNo).HasMaxLength(14);


                builder.Property(e => e.Root).HasMaxLength(100);


                builder.Property(e => e.StatusId).HasColumnName("StatusID");

                builder.Property(e => e.UploadDate).HasColumnType("timestamp with time zone");

        }
    }
}
