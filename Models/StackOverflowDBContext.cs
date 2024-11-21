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
    public DbSet<Image> Images { get; set; }


    /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
         => optionsBuilder.UseSqlServer("Data Source=DESKTOP-7R66M1N;Initial Catalog=stackoverflow;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
 */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WatchedTag>()
    .HasKey(wt => new { wt.UserId, wt.TagId }); // Khóa chính là UserId và TagId
        modelBuilder.Entity<WatchedTag>()
            .HasOne(wt => wt.User) // Liên kết với bảng User
            .WithMany(u => u.WatchedTags) // Mỗi User có thể có nhiều WatchedTags
            .HasForeignKey(wt => wt.UserId); // Khóa ngoại đến User
        modelBuilder.Entity<WatchedTag>()
            .HasOne(wt => wt.Tag) // Liên kết với bảng Tag
            .WithMany(t => t.WatchedByUsers) // Mỗi Tag có thể được nhiều User theo dõi
            .HasForeignKey(wt => wt.TagId); // Khóa ngoại đến Tag

        // Cấu hình mối quan hệ N:N với bảng ignoredtags
        modelBuilder.Entity<IgnoredTag>()
            .HasKey(it => new { it.UserId, it.TagId }); // Khóa chính là UserId và TagId
        modelBuilder.Entity<IgnoredTag>()
            .HasOne(it => it.User) // Liên kết với bảng User
            .WithMany(u => u.IgnoredTags) // Mỗi User có thể bỏ qua nhiều Tags
            .HasForeignKey(it => it.UserId); // Khóa ngoại đến User
        modelBuilder.Entity<IgnoredTag>()
            .HasOne(it => it.Tag) // Liên kết với bảng Tag
            .WithMany(t => t.IgnoredByUsers) // Mỗi Tag có thể bị bỏ qua bởi nhiều User
            .HasForeignKey(it => it.TagId); // Khóa ngoại đến Tag

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__answers__3213E83FE1097BC8");

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

            // Thêm quan hệ với Comment
            entity.HasMany(a => a.Comments)
                .WithOne(c => c.Answer)
                .HasForeignKey(c => c.EntityId) // Đảm bảo bạn có trường AnswerId trong Comment
                .HasConstraintName("FK_answers_comments")
                .HasAnnotation("EntityType", 2);


        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__comments__3214EC07778DEF1C");

            entity.ToTable("comments");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");


            // Quan hệ với Post
            entity.HasOne(d => d.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK_comments_Post")
                .HasAnnotation("EntityType", 1);

            // Quan hệ với Answer
            entity.HasOne(d => d.Answer)
                .WithMany(a => a.Comments) // Đảm bảo rằng Answer có thể có nhiều Comment
                .HasForeignKey(d => d.EntityId) // Đảm bảo bạn có trường AnswerId trong Comment
                .HasConstraintName("FK_comments_Answer")
                .HasAnnotation("EntityType", 2);


            // Quan hệ với User
            entity.HasOne(d => d.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_comments_User");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__posts__3213E83FC31609ED");

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
                .HasConstraintName("FK__posts__user_id__3F466844");

            entity.HasMany(d => d.Comments)
               .WithOne(c => c.Post)
               .HasForeignKey(c => c.EntityId)
               .HasConstraintName("FK__comments__post_id")
                .HasAnnotation("EntityType", 1);

            // Quan hệ với Answers
            entity.HasMany(d => d.Answers)
                .WithOne(a => a.Post)
                .HasForeignKey(a => a.PostId)
                .HasConstraintName("FK__answers__post_id");
        });

        modelBuilder.Entity<Posttag>(entity =>
        {
            entity.HasKey(e => new { e.PostId, e.TagId }).HasName("PK__posttag__4AFEED4DCB06682C");

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

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83F7C8F4E7D");

            entity.ToTable("roles");

            entity.HasIndex(e => e.RoleName, "UQ__roles__783254B1A1E68E64").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PK__tags__3213E83FBA903079");

            entity.ToTable("tags");

            entity.HasIndex(e => e.Tagname, "UQ__tags__D48789A096682B15").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FBCCF8E10");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "UQ__users__F3DBC572F8E7BB1A").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email).HasDefaultValue("");
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
            entity.HasKey(e => new { e.UserId, e.RoleId }).HasName("PK__user_rol__6EDEA1538F9D6585");

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
                .HasConstraintName("FK__user_role__user___6383C8BA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
