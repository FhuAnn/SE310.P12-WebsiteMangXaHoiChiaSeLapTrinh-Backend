using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

public partial class Stackoverflow1511Context : DbContext
{
    public Stackoverflow1511Context()
    {
    }

    public Stackoverflow1511Context(DbContextOptions<Stackoverflow1511Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Posttag> Posttags { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<WatchedTag> WatchedTags { get; set; }
    public virtual DbSet<IgnoredTag> IgnoredTags { get; set; }
    public virtual DbSet<Vote> Votes { get; set; }

    public DbSet<Report> Reports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__answers");

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
                .HasConstraintName("FK__answers__post_id");

            entity.HasOne(d => d.User).WithMany(p => p.Answers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__answers__user_id");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__comments");

            entity.ToTable("comments");

            entity.HasIndex(e => e.PostId, "IX_comments_PostId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Answer).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK_comments_answers");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_comments_Post");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_comments_User");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasIndex(e => e.PostId, "IX_Images_postId");

            entity.HasIndex(e => e.UserId, "IX_Images_userId");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FileExtension).HasColumnName("fileExtension");
            entity.Property(e => e.FilePath).HasColumnName("filePath");
            entity.Property(e => e.FileSizeInBytes).HasColumnName("fileSizeInBytes");
            entity.Property(e => e.PostId).HasColumnName("postId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Post).WithMany(p => p.Images).HasForeignKey(d => d.PostId);

            entity.HasOne(d => d.User).WithMany(p => p.Images).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__posts");

            entity.ToTable("posts");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Detailproblem)
                .HasDefaultValue("")
                .HasColumnName("detailproblem");
            entity.Property(e => e.Downvote).HasColumnName("downvote");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .HasColumnName("title");
            entity.Property(e => e.Tryandexpecting).HasColumnName("tryandexpecting");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Upvote).HasColumnName("upvote");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Views).HasColumnName("views");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__posts__user_id");
        });

        modelBuilder.Entity<Posttag>(entity =>
        {
            entity.HasKey(e => new { e.PostId, e.TagId }).HasName("PK__posttag");

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
                .HasConstraintName("FK__posttag__post_id");

            entity.HasOne(d => d.Tag).WithMany(p => p.Posttags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__posttag__tag_id");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles");

            entity.ToTable("roles");

            entity.HasIndex(e => e.RoleName, "UQ__roles").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PK__tags");

            entity.ToTable("tags");

            entity.HasIndex(e => e.Tagname, "UQ__tags").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PK__users");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "UQ__users").IsUnique();

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
            entity.HasKey(e => new { e.UserId, e.RoleId }).HasName("PK__user_role");

            entity.ToTable("user_roles");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.AssignedAt)
                .HasColumnType("datetime")
                .HasColumnName("assigned_at");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_role__role");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_role__user");
        });

        modelBuilder.Entity<WatchedTag>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.TagId });

            entity.ToTable("watchedtags");

            entity.HasIndex(e => e.TagId).HasDatabaseName("IX_watchedtags_TagId");

            entity.HasOne(e => e.User)
                .WithMany(u => u.WatchedTags)
                .HasForeignKey(e => e.UserId);

            entity.HasOne(e => e.Tag)
                .WithMany(t => t.WatchedTags)
                .HasForeignKey(e => e.TagId);
        });

        modelBuilder.Entity<IgnoredTag>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.TagId });

            entity.ToTable("ignoredtags");

            entity.HasIndex(e => e.TagId).HasDatabaseName("IX_ignoredtags_TagId");

            entity.HasOne(e => e.User)
                .WithMany(u => u.IgnoredTags)
                .HasForeignKey(e => e.UserId);

            entity.HasOne(e => e.Tag)
                .WithMany(t => t.IgnoredTags)
                .HasForeignKey(e => e.TagId);
        });

        //modelBuilder.Entity<Report>()
        //    .HasOne(r => r.User)
        //    .WithMany(u => u.Reports)
        //    .HasForeignKey(r => r.UserId)
        //    .OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<Report>()
        //   .HasOne(r => r.Post)
        //   .WithMany(p => p.Reports)
        //   .HasForeignKey(r => r.PostId)    
        //   .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Vote>()
       .HasOne(v => v.User)
       .WithMany(u => u.Votes)
       .HasForeignKey(v => v.UserId);

        modelBuilder.Entity<Vote>()
            .HasOne(v => v.Post)
            .WithMany(p => p.Votes)
            .HasForeignKey(v => v.PostId);

        // Đảm bảo mỗi người dùng chỉ vote 1 lần trên 1 bài viết
        modelBuilder.Entity<Vote>()
            .HasIndex(v => new { v.UserId, v.PostId })
            .IsUnique();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
