using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;

public partial class StackOverflowDBContext : DbContext
{
    public StackOverflowDBContext()
    {
    }

    public StackOverflowDBContext(DbContextOptions<StackOverflowDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Posttag> Posttags { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<WatchedTag> WatchedTags { get; set; }
    public virtual DbSet<IgnoredTag> IgnoredTags { get; set; }

   /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-7R66M1N;Initial Catalog=stackoverflow; Integrated Security=True;Trust Server Certificate=True");*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Posttag>(entity =>
{
    entity.HasKey(e => new { e.PostId, e.TagId }).HasName("PK__posttag__4AFEED4DC067451F");

    entity.ToTable("posttag");

    entity.Property(e => e.PostId).HasColumnName("post_id");
    entity.Property(e => e.TagId).HasColumnName("tag_id");
    entity.Property(e => e.CreatedAt)
        .HasColumnType("datetime")
        .HasColumnName("created_at");
    entity.Property(e => e.UpdatedAt)
        .HasColumnType("datetime")
        .HasColumnName("updated_at");

    entity.HasOne(d => d.Post).WithMany(p => p.Posttags)
        .HasForeignKey(d => d.PostId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK__posttag__post_id__4222D4EF");

    entity.HasOne(d => d.Tag).WithMany(p => p.Posttags)
        .HasForeignKey(d => d.TagId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK__posttag__tag_id__4316F928");
});

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__answers__3213E83F376D8E7A");

            entity.ToTable("answers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Body).HasColumnName("body");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Downvote).HasColumnName("downvote");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Upvote).HasColumnName("upvote");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Post).WithMany(p => p.Answers)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__answers__post_id__4AB81AF0");

            entity.HasOne(d => d.User).WithMany(p => p.Answers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__answers__user_id__49C3F6B7");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__comments__3213E83F2401F5AB");

            entity.ToTable("comments");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Body).HasColumnName("body");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__comments__post_i__46E78A0C");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__comments__user_i__45F365D3");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__posts__3213E83F57D81F9F");

            entity.ToTable("posts");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DetailProblem).HasColumnName("detailproblem");
            entity.Property(e => e.TryAndExpecting).HasColumnName("tryandexpecting");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Downvote).HasColumnName("downvote");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Upvote).HasColumnName("upvote");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Views).HasColumnName("views");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__posts__user_id__3F466844");
        });

      

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83F79CC5BDF");

            entity.ToTable("roles");

            entity.HasIndex(e => e.RoleName, "UQ__roles__783254B10E1D0E3F").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tags__3213E83F865609AA");

            entity.ToTable("tags");

            entity.HasIndex(e => e.Tagname, "UQ__tags__D48789A0064EDE44").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Tagname)
                .HasMaxLength(255)
                .HasColumnName("tagname");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F1998A5B6");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "UQ__users__F3DBC5726DF6499A").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Gravatar)
                .HasMaxLength(255)
                .HasColumnName("gravatar");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
            entity.Property(e => e.Views).HasColumnName("views");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId }).HasName("PK__user_rol__6EDEA15368399088");

            entity.ToTable("user_roles");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.AssignedAt)
                .HasColumnType("datetime")
                .HasColumnName("assigned_at");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_role__role___5535A963");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_role__user___5441852A");
        });
        modelBuilder.Entity<WatchedTag>(entity =>
        {
            // Define composite primary key for WatchedTag
            entity.HasKey(wt => new { wt.UserId, wt.TagId });

            // Configure User-Tag relationship for WatchedTag
            entity.HasOne(wt => wt.User)
                  .WithMany(u => u.WatchedTags)
                  .HasForeignKey(wt => wt.UserId);

            entity.HasOne(wt => wt.Tag)
                  .WithMany(t => t.WatchedTags)
                  .HasForeignKey(wt => wt.TagId);
        });

        // Configure IgnoredTag
        modelBuilder.Entity<IgnoredTag>(entity =>
        {
            // Define composite primary key for IgnoredTag
            entity.HasKey(it => new { it.UserId, it.TagId });

            // Configure User-Tag relationship for IgnoredTag
            entity.HasOne(it => it.User)
                  .WithMany(u => u.IgnoredTags)
                  .HasForeignKey(it => it.UserId);

            entity.HasOne(it => it.Tag)
                  .WithMany(t => t.IgnoredTags)
                  .HasForeignKey(it => it.TagId);
        });

        

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
