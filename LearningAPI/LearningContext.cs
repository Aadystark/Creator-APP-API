using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace LearningAPI;

public partial class LearningContext : DbContext
{
    public LearningContext()
    {
    }

    public LearningContext(DbContextOptions<LearningContext> options)
        : base(options)
    {
    }

    public DbSet<Datum> Data { get; set; }
    public DbSet<TableData> TableData { get; set; }
    public DbSet<SPData> SPData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LEGION;Initial Catalog=Learning;Integrated Security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Datum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__data__3213E83FE250DB56");

            entity.ToTable("data");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ExpiryDate)
                .HasColumnType("date")
                .HasColumnName("Expiry_date");
            entity.Property(e => e.Gender)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TableData>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK_Table_1");

            entity.ToTable("Table_1");

            entity.Property(e => e.TableId).HasColumnName("TableId");
            entity.Property(e => e.TableName)
                .HasColumnType("varchar")
                .HasColumnName("TableName");
            entity.Property(e => e.TablePKName)
                .HasColumnType("varchar")
                .HasColumnName("TablePKName");
            entity.Property(e => e.TableColumns)
                .HasColumnType("varchar")
                .HasColumnName("TableColumns");
            entity.Property(e => e.SchemaName)
                .HasColumnType("varchar")
                .HasColumnName("SchemaName");
            entity.Property(e => e.IsActive)
                .HasColumnType("bit")
                .HasColumnName("IsActive");
        });
        

        modelBuilder.Entity<SPData>(entity =>
        {
            entity.HasKey(e => e.SPId).HasName("PK_SPMappingTable");

            entity.ToTable("SPMappingTable");

            entity.Property(e => e.SPId).HasColumnName("SPId");
            entity.Property(e => e.SPName)
                .HasColumnType("varchar")
                .HasColumnName("SPName");
            entity.Property(e => e.SchemaName)
                .HasColumnType("varchar")
                .HasColumnName("SchemaName");
            entity.Property(e => e.IsActive)
                .HasColumnType("bit")
                .HasColumnName("IsActive");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
