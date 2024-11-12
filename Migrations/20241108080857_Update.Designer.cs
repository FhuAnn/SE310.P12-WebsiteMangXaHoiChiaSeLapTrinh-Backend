﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;

#nullable disable

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Migrations
{
    [DbContext(typeof(StackOverflowAuthDBContext))]
    [Migration("20241108080857_Update")]
    partial class Update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("body");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<int>("Downvote")
                        .HasColumnType("int")
                        .HasColumnName("downvote");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("post_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.Property<int>("Upvote")
                        .HasColumnType("int")
                        .HasColumnName("upvote");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK__answers__3213E83F376D8E7A");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("answers", (string)null);
                });

            modelBuilder.Entity("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("body");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("post_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK__comments__3213E83F2401F5AB");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("body");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<int>("Downvote")
                        .HasColumnType("int")
                        .HasColumnName("downvote");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.Property<int>("Upvote")
                        .HasColumnType("int")
                        .HasColumnName("upvote");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.Property<int>("Views")
                        .HasColumnType("int")
                        .HasColumnName("views");

                    b.HasKey("Id")
                        .HasName("PK__posts__3213E83F57D81F9F");

                    b.HasIndex("UserId");

                    b.ToTable("posts", (string)null);
                });

            modelBuilder.Entity("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain.Posttag", b =>
                {
                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("post_id");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("tag_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("PostId", "TagId")
                        .HasName("PK__posttag__4AFEED4DC067451F");

                    b.HasIndex("TagId");

                    b.ToTable("posttag", (string)null);
                });

            modelBuilder.Entity("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("description");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("role_name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("PK__roles__3213E83F79CC5BDF");

                    b.HasIndex(new[] { "RoleName" }, "UQ__roles__783254B10E1D0E3F")
                        .IsUnique();

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Tagname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("tagname");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("PK__tags__3213E83F865609AA");

                    b.HasIndex(new[] { "Tagname" }, "UQ__tags__D48789A0064EDE44")
                        .IsUnique();

                    b.ToTable("tags", (string)null);
                });

            modelBuilder.Entity("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<string>("Gravatar")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("gravatar");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("password");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("username");

                    b.Property<int>("Views")
                        .HasColumnType("int")
                        .HasColumnName("views");

                    b.HasKey("Id")
                        .HasName("PK__users__3213E83F1998A5B6");

                    b.HasIndex(new[] { "Username" }, "UQ__users__F3DBC5726DF6499A")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("role_id");

                    b.Property<DateTime>("AssignedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("assigned_at");

                    b.HasKey("UserId", "RoleId")
                        .HasName("PK__user_rol__6EDEA15368399088");

                    b.HasIndex("RoleId");

                    b.ToTable("user_roles", (string)null);
                });

            modelBuilder.Entity("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain.Answer", b =>
                {
                    b.HasOne("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain.Post", "Post")
                        .WithMany("Answers")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK__answers__post_id__4AB81AF0");

                    b.HasOne("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.User", "User")
                        .WithMany("Answers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__answers__user_id__49C3F6B7");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain.Comment", b =>
                {
                    b.HasOne("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK__comments__post_i__46E78A0C");

                    b.HasOne("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__comments__user_i__45F365D3");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain.Post", b =>
                {
                    b.HasOne("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__posts__user_id__3F466844");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain.Posttag", b =>
                {
                    b.HasOne("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain.Post", "Post")
                        .WithMany("Posttags")
                        .HasForeignKey("PostId")
                        .IsRequired()
                        .HasConstraintName("FK__posttag__post_id__4222D4EF");

                    b.HasOne("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Tag", "Tag")
                        .WithMany("Posttags")
                        .HasForeignKey("TagId")
                        .IsRequired()
                        .HasConstraintName("FK__posttag__tag_id__4316F928");

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.UserRole", b =>
                {
                    b.HasOne("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK__user_role__role___5535A963");

                    b.HasOne("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__user_role__user___5441852A");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain.Post", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Comments");

                    b.Navigation("Posttags");
                });

            modelBuilder.Entity("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Tag", b =>
                {
                    b.Navigation("Posttags");
                });

            modelBuilder.Entity("SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.User", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Comments");

                    b.Navigation("Posts");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
