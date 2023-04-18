using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Entities;

public partial class HelpdeskSbContext : DbContext
{
    public HelpdeskSbContext()
    {
    }

    public HelpdeskSbContext(DbContextOptions<HelpdeskSbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblContact> TblContacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=appserver300032.database.windows.net;Database=Helpdesk_sb;User ID=sqladmin;Password=Azure@123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblContact>(entity =>
        {
            entity.HasKey(e => e.ContactId);

            entity.ToTable("tblContacts");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
