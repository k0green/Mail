using System;
using System.Collections.Generic;
using Mail.Context.IContext;
using Mail.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mail.Context;

public partial class Task6Context : DbContext, ITask6Context
{
    public Task6Context()
    {
    }

    public Task6Context(DbContextOptions<Task6Context> options)
        : base(options)
    {
    }

    public virtual DbSet<MessagesInfo> MessagesInfos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SQL8002.site4now.net;Initial Catalog=db_a935ed_task6;User Id=db_a935ed_task6_admin;Password=4704egor");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MessagesInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Messages__3214EC07F5B05C19");

            entity.ToTable("MessagesInfo");

            entity.Property(e => e.Body).HasColumnType("text");
            entity.Property(e => e.DispatchTime).HasColumnType("datetime");
            entity.Property(e => e.RecipientId).HasColumnName("Recipient_Id");
            entity.Property(e => e.SenderId).HasColumnName("Sender_Id");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Recipient).WithMany(p => p.MessagesInfoRecipients)
                .HasForeignKey(d => d.RecipientId)
                .HasConstraintName("recipient_fk");

            entity.HasOne(d => d.Sender).WithMany(p => p.MessagesInfoSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("sender_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07DEA6E04B");

            entity.HasIndex(e => e.Name, "UQ__Users__737584F6CD3D2362").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
