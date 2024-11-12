using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Migrations.StackOverflowDB
{
    /// <inheritdoc />
    public partial class AddWatchedTagAndIgnoredTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            
            migrationBuilder.CreateTable(
                name: "ignored_tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tag_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ignored_tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ignored_tag__tag",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ignored_tag__user",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                   
                });

           

            

            migrationBuilder.CreateTable(
                name: "watched_tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tag_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_watched_tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK__watched_tag__tag",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__watched_tag__user",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                   
                });

            



            migrationBuilder.CreateIndex(
                name: "IX_ignored_tags_tag_id",
                table: "ignored_tags",
                column: "tag_id");

        

            migrationBuilder.CreateIndex(
                name: "IX_ignored_tags_user_id",
                table: "ignored_tags",
                column: "user_id");

           
            migrationBuilder.CreateIndex(
                name: "IX_watched_tags_tag_id",
                table: "watched_tags",
                column: "tag_id");

         
            migrationBuilder.CreateIndex(
                name: "IX_watched_tags_user_id",
                table: "watched_tags",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answers");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "ignored_tags");

            migrationBuilder.DropTable(
                name: "posttag");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "watched_tags");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
