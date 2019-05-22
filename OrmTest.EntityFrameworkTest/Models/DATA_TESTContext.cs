using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OrmTest.EntityFrameworkTest.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TeBaseField> TeBaseFields { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=127.0.0.1;User ID=sa;Password=1qazxsw23edC;Initial Catalog=Data_Test;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeBaseField>(entity =>
            {
                entity.ToTable("Te_BaseField");

                entity.Property(e => e.BigDataField).IsRequired();

                entity.Property(e => e.DateTimeField).HasColumnType("datetime");

                entity.Property(e => e.DateTimeFieldNull).HasColumnType("datetime");

                entity.Property(e => e.DecimalField).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.DecimalFieldNull).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.TextField)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.TextFieldNull).HasColumnType("text");

                entity.Property(e => e.Uint16Field).HasColumnName("UInt16Field");

                entity.Property(e => e.Uint16FieldNull).HasColumnName("UInt16FieldNull");

                entity.Property(e => e.Uint32Field).HasColumnName("UInt32Field");

                entity.Property(e => e.Uint32FieldNull).HasColumnName("UInt32FieldNull");

                entity.Property(e => e.Uint64Field)
                    .HasColumnName("UInt64Field")
                    .HasColumnType("decimal(20, 0)");

                entity.Property(e => e.Uint64FieldNull)
                    .HasColumnName("UInt64FieldNull")
                    .HasColumnType("decimal(20, 0)");

                entity.Property(e => e.VarcharField)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.VarcharFieldNull)
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });
        }
    }
}
