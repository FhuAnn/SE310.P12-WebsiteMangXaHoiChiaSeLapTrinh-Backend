using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Migrations
{
    /// <inheritdoc />
    public partial class updatedb1411 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileDescription",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "FileSizeInBytes",
                table: "Images",
                newName: "fileSizeInBytes");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Images",
                newName: "filePath");

            migrationBuilder.RenameColumn(
                name: "FileExtension",
                table: "Images",
                newName: "fileExtension");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Images",
                newName: "id");

            migrationBuilder.AddColumn<Guid>(
                name: "postId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "userId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_postId",
                table: "Images",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_userId",
                table: "Images",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_posts_postId",
                table: "Images",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_users_userId",
                table: "Images",
                column: "userId",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_posts_PostId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_users_userId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_PostId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_userId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "fileSizeInBytes",
                table: "Images",
                newName: "FileSizeInBytes");

            migrationBuilder.RenameColumn(
                name: "filePath",
                table: "Images",
                newName: "FilePath");

            migrationBuilder.RenameColumn(
                name: "fileExtension",
                table: "Images",
                newName: "FileExtension");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Images",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "FileDescription",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
